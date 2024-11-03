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

open Fabulous.Avalonia
open type Fabulous.Avalonia.View

type NotificationViewModel(title, message) =

    interface INotification with
        member this.Title = title
        member this.Message = message
        member this.Expiration = TimeSpan.FromSeconds(5.)
        member this.OnClick = Action(fun _ -> Console.WriteLine("Clicked"))
        member this.OnClose = Action(fun _ -> Console.WriteLine("Closed"))
        member this.Type = NotificationType.Error


module NotificationsPage =
    type Model =
        { NotificationManager: INotificationManager
          NotificationPosition: NotificationPosition }

    type Msg =
        | ShowManagedNotification
        | ShowCustomManagedNotification
        | ShowNativeNotification
        | ShowAsyncCompletedNotification
        | ShowAsyncStatusNotifications
        | NotifyInfo of string
        | YesCommand
        | NoCommand
        | AttachedToVisualTreeChanged of VisualTreeAttachmentEventArgs // event after which WindowNotificationManager is available
        | ControlNotificationsShow
        | NotificationShown
        | PositionChanged of SelectionChangedEventArgs

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

    let showNotification (notificationManager: INotificationManager) notification =
        Cmd.ofEffect(fun dispatch ->
            Dispatcher.UIThread.Post(fun () ->
                notificationManager.Show(notification)
                dispatch(NotificationShown)))

    let controlNotificationsRef = ViewRef<WindowNotificationManager>()

    let init () =
        { NotificationManager = null
          NotificationPosition = NotificationPosition.TopRight },
        []

    let update msg model =
        match msg with
        | ShowManagedNotification ->
            model, showNotification model.NotificationManager (Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information))

        | ShowCustomManagedNotification ->
            model,
            showNotification
                model.NotificationManager
                (NotificationViewModel("Hey There!", "Did you know that Avalonia now supports Custom In-Window Notifications?"))

        | ShowNativeNotification ->
            model,
            showNotification model.NotificationManager (Notification("Error", "Native Notifications are not quite ready. Coming soon.", NotificationType.Error))

        | ShowAsyncCompletedNotification -> model, notifyOneAsync()
        | ShowAsyncStatusNotifications -> model, notifyAsyncStatusUpdates()

        | NotifyInfo message -> model, showNotification model.NotificationManager (Notification(message, "", NotificationType.Information))
        | YesCommand ->
            model, showNotification model.NotificationManager (Notification("Avalonia Notifications", "Start adding notifications to your app today."))

        | NoCommand ->
            model, showNotification model.NotificationManager (Notification("Avalonia Notifications", "Start adding notifications to your app today."))
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
        Component("", program) {
            let! model = Mvu.State

            (Grid() {
                Dock() {
                    TextBlock("TopLevel bound notification manager.")
                        .dock(Dock.Top)
                        .margin(2.)
                        .classes([ "h2" ])
                        .textWrapping(TextWrapping.Wrap)

                    Button("Show Standard Managed Notification", ShowManagedNotification)
                        .dock(Dock.Top)

                    Button("Show Custom Managed Notification", ShowCustomManagedNotification)
                        .dock(Dock.Top)

                    Button("Notify async operation completed", ShowAsyncCompletedNotification)
                        .dock(Dock.Top)

                    Button("Notify status updates from async operation", ShowAsyncStatusNotifications)
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

                    CustomNotification("Avalonia Notifications", "Start adding notifications to your app today.", YesCommand, NoCommand)
                        .dock(Dock.Top)

                    NotificationCard(false, "This is a notification card.")
                        .size(200., 100.)
                        .dock(Dock.Top)
                        .padding(10)
                        .borderBrush(SolidColorBrush(Colors.Blue))
                }

                // We can use the WindowNotificationManager a widget to be able to have a different WindowNotificationManager than FabApplication.Current.WindowNotificationManager
                // Allowing you control ie the Position of a single notification
                WindowNotificationManager(controlNotificationsRef)
                    .position(model.NotificationPosition)
                    .dock(Dock.Top)
                    .maxItems(3)

            })
                .onAttachedToVisualTree(AttachedToVisualTreeChanged)
        }
