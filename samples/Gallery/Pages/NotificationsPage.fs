namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls.Notifications
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View


module NotificationsPage =
    type Model =
        { NotificationManager: WindowNotificationManager
          NotificationPosition: NotificationPosition
          ShowInlined: bool }

    type Msg =
        | ShowPlainNotification
        | ShowCustomPlainNotification
        | ShowCustomManagedNotification
        | ShowNativeNotification
        | ShowAsyncCompletedNotification
        | ShowAsyncStatusNotifications
        | ToggleInlinedNotification
        | NotifyInfo of string
        | AttachedToVisualTreeChanged of VisualTreeAttachmentEventArgs // event after which WindowNotificationManager is available
        | ControlNotificationsShow
        | NotificationShown
        | PositionChanged of SelectionChangedEventArgs

    type WindowNotificationManager with
        member this.Show(content: WidgetBuilder<'msg, 'marker>) =
            let widget = content.Compile()
            let widgetDef = WidgetDefinitionStore.get widget.Key
            let logger = ProgramDefaults.defaultLogger()
            let syncAction = ViewHelpers.defaultSyncAction

            let treeContext: ViewTreeContext =
                { CanReuseView = ViewHelpers.canReuseView
                  GetViewNode = ViewNode.get
                  GetComponent = Component.get
                  SetComponent = Component.set
                  SyncAction = syncAction
                  Logger = logger
                  Dispatch = ignore }

            let envContext = new EnvironmentContext(logger)

            let struct (_node, view) =
                widgetDef.CreateView(widget, envContext, treeContext, ValueNone)

            this.Show(view)

    let notifyOneAsync () =
        Cmd.OfAsync.msg(
            async {
                do! Async.Sleep 1000
                return NotifyInfo "async operation completed"
            }
        )

    let notifyAsyncStatusUpdates () =
        Cmd.ofEffect(fun dispatch ->
            async {
                // This will queue up msgs/notifications that will be dispatched by the Fabulous runner
                dispatch(NotifyInfo "started")
                do! Async.Sleep(1000)
                dispatch(NotifyInfo "5")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "4")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "3")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "2")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "1")
                do! Async.Sleep 1000
                dispatch(NotifyInfo "completed")
            }
            |> Async.Start)

    let showNotification (notificationManager: WindowNotificationManager) notification =
        Cmd.ofEffect(fun dispatch ->
            Dispatcher.UIThread.Post(fun () ->
                notificationManager.Show(notification)
                dispatch(NotificationShown)))

    let showNotificationContent<'msg, 'marker when 'msg: equality>
        (notificationManager: WindowNotificationManager)
        (content: WidgetBuilder<'msg, 'marker>)
        : Cmd<'msg> =
        Cmd.ofEffect(fun dispatch ->
            Dispatcher.UIThread.Post(fun () ->
                // Compile with the real dispatcher so events inside the notification can send messages
                let widget = content.Compile()
                let widgetDef = WidgetDefinitionStore.get widget.Key
                let logger = ProgramDefaults.defaultLogger()
                let syncAction = ViewHelpers.defaultSyncAction

                let treeContext: ViewTreeContext =
                    { CanReuseView = ViewHelpers.canReuseView
                      GetViewNode = ViewNode.get
                      GetComponent = Component.get
                      SetComponent = Component.set
                      SyncAction = syncAction
                      Logger = logger
                      Dispatch = (fun m -> dispatch(unbox m)) }

                let envContext = new EnvironmentContext(logger)

                let struct (_node, view) =
                    widgetDef.CreateView(widget, envContext, treeContext, ValueNone)

                notificationManager.Show(view)))

    let controlNotificationsRef = ViewRef<WindowNotificationManager>()

    let notification title message =
        { new INotification with
            member this.Title = title
            member this.Message = message
            member this.Expiration = TimeSpan.FromSeconds(5.)
            member this.OnClick = Action(fun _ -> Console.WriteLine("Clicked"))
            member this.OnClose = Action(fun _ -> Console.WriteLine("Closed"))
            member this.Type = NotificationType.Error }


    let init () =
        { NotificationManager = null
          NotificationPosition = NotificationPosition.TopRight
          ShowInlined = false },
        []

    type QuestionLocalMsg =
        | LocalYes
        | LocalNo

    let questionInit () = (), Cmd.none

    let questionUpdate (msg: QuestionLocalMsg) (model: unit) =
        let show (title: string) (message: string) : Cmd<QuestionLocalMsg> =
            Cmd.ofEffect(fun _ -> Dispatcher.UIThread.Post(fun () -> FabApplication.Current.WindowNotificationManager.Show(Notification(title, message))))

        match msg with
        | LocalYes -> model, show "Wise choice." "You better!"
        | LocalNo -> model, show "What?" "Why wouldn't you?"

    let questionProgram = Program.statefulWithCmd questionInit questionUpdate

    let questionContent title question =
        Component("QuestionContent") {
            let! _ = Context.Mvu questionProgram
            InlinedYesNoQuestion(title, question, QuestionLocalMsg.LocalYes, QuestionLocalMsg.LocalNo)
        }

    let update msg model =
        match msg with
        | ShowPlainNotification ->
            model, showNotification model.NotificationManager (Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information))

        | ShowCustomPlainNotification ->
            model,
            showNotification model.NotificationManager (notification "Hey There!" "Did you know that Avalonia now supports Custom In-Window Notifications?")

        | ShowCustomManagedNotification ->
            model, showNotificationContent model.NotificationManager (questionContent "Can you dig it?" "You can use standard widgets in notifications!")

        | ShowNativeNotification ->
            model,
            showNotification model.NotificationManager (Notification("Error", "Native Notifications are not quite ready. Coming soon.", NotificationType.Error))

        | ShowAsyncCompletedNotification -> model, notifyOneAsync()
        | ShowAsyncStatusNotifications -> model, notifyAsyncStatusUpdates()
        | ToggleInlinedNotification ->
            { model with
                ShowInlined = not model.ShowInlined },
            Cmd.none

        | NotifyInfo message -> model, showNotification model.NotificationManager (Notification(message, "", NotificationType.Information))

        (*  WindowNotificationManager can't be used immediately after creating it,
            so we need to wait for it to be attached to the visual tree.
            See https://github.com/AvaloniaUI/Avalonia/issues/5442 *)
        | AttachedToVisualTreeChanged args ->
            { model with
                NotificationManager = FabApplication.Current.WindowNotificationManager },
            Cmd.none

        | ControlNotificationsShow ->
            model, showNotification controlNotificationsRef.Value (Notification("Control Notifications", "This notification is shown by the control itself."))


        | NotificationShown -> model, Cmd.none

        | PositionChanged args ->
            let control = args.Source :?> ComboBox
            let selectedItem = control.SelectedItem :?> ComboBoxItem
            let position = Enum.Parse<NotificationPosition>(selectedItem.Content.ToString())

            { model with
                NotificationPosition = position },
            Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("NotificationsPage") {
            let! model = Context.Mvu program

            (Grid() {
                Dock() {
                    TextBlock("TopLevel bound notification manager.")
                        .dock(Dock.Top)
                        .margin(2.)
                        .classes([ "h2" ])
                        .textWrapping(TextWrapping.Wrap)

                    Button("A plain Notification", ShowPlainNotification)
                        .dock(Dock.Top)

                    Button("A custom plain Notification", ShowCustomPlainNotification)
                        .dock(Dock.Top)

                    Button("A Managed Notification with custom content", ShowCustomManagedNotification)
                        .dock(Dock.Top)

                    Button("Notify async operation completed", ShowAsyncCompletedNotification)
                        .dock(Dock.Top)

                    Button("Notify status updates from async operation", ShowAsyncStatusNotifications)
                        .dock(Dock.Top)

                    Button("Toggle inlined notifications", ToggleInlinedNotification)
                        .dock(Dock.Top)

                    TextBlock("Widget-only notification manager.")
                        .dock(Dock.Top)
                        .margin(2.)
                        .classes([ "h2" ])
                        .textWrapping(TextWrapping.Wrap)

                    (HStack(5) {
                        Button("Show widget-only notification", ControlNotificationsShow)
                            .horizontalAlignment(HorizontalAlignment.Left)

                        Label "on the"

                        (ComboBox() {
                            ComboBoxItem(nameof(NotificationPosition.TopRight))
                            ComboBoxItem(nameof(NotificationPosition.TopLeft))
                            ComboBoxItem(nameof(NotificationPosition.BottomRight))
                            ComboBoxItem(nameof(NotificationPosition.BottomLeft))
                        })
                            .selectedIndex(0)
                            .onSelectionChanged(PositionChanged)
                    })
                        .dock(Dock.Top)

                    (questionContent "Can you believe it?" "You can also roll your own inlined dialogs using standard widgets.")
                        .isVisible(model.ShowInlined)
                        .dock(Dock.Top)

                    // Demonstrate NotificationCard controlled solely via its IsClosed flag. Avoid .isVisible, which masks the effect.
                    NotificationCard(not model.ShowInlined, "I was here all along, just hidden!")
                        .size(300., 70.)
                        .dock(Dock.Top)
                        .padding(10)
                        .borderBrush(SolidColorBrush(Colors.Blue))
                }

                // We can use the WindowNotificationManager a widget to be able to have a different WindowNotificationManager than FabApplication.Current.WindowNotificationManager
                // Allowing you to control ie the Position of a single notification
                WindowNotificationManager(controlNotificationsRef)
                    .position(model.NotificationPosition)
                    .dock(Dock.Top)
                    .maxItems(3)

            })
                .onAttachedToVisualTree(AttachedToVisualTreeChanged)
        }
