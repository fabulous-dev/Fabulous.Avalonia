namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls.Notifications
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
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
        { NotificationManager: WindowNotificationManager }

    type Msg =
        | ShowManagedNotification
        | ShowCustomManagedNotification
        | ShowNativeNotification
        | ShowAsyncCompletedNotification
        | ShowAsyncStatusNotifications
        | NotifyInfo of string
        | YesCommand
        | NoCommand
        | AttachedToVisualTreeChanged of VisualTreeAttachmentEventArgs
        | ControlNotificationsShow

    //TODO What is this about?
    type CmdMsg = | NotifyAsyncCompleted | NotifyAsyncStatusUpdates

    let private notifyOneAsync =
        async {
            do! Async.Sleep 1000
            return NotifyInfo "async operation completed"
        }

    let private notifyAsyncStatusUpdates dispatch =
        async {
            dispatch(NotifyInfo "started")
            do! Async.Sleep 1000
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
        } |> Async.Start

    //TODO What is this about?
    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NotifyAsyncCompleted -> Cmd.OfAsync.msg notifyOneAsync
        | NotifyAsyncStatusUpdates -> Cmd.ofEffect notifyAsyncStatusUpdates

    let controlNotificationsRef = ViewRef<WindowNotificationManager>()

    let init () = { NotificationManager = null }, []

    let update msg model =
        match msg with
        | ShowManagedNotification ->

            //TODO this changes global state! i.e. after receiving this message, all notifications appear bottom right. is that intended?
            model.NotificationManager.Position <- NotificationPosition.BottomRight

            model.NotificationManager.Show(Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information))

            model, []
        | ShowCustomManagedNotification ->
            model.NotificationManager.Show(NotificationViewModel("Hey There!", "Did you know that Avalonia now supports Custom In-Window Notifications?"))

            model, []
        | ShowNativeNotification ->
            model.NotificationManager.Show(Notification("Error", "Native Notifications are not quite ready. Coming soon.", NotificationType.Error))

            model, []

        | ShowAsyncCompletedNotification -> model, [NotifyAsyncCompleted]
        | ShowAsyncStatusNotifications -> model, [NotifyAsyncStatusUpdates]

        | NotifyInfo message ->
            model.NotificationManager.Show(Notification(message, "", NotificationType.Information))
            model, []

        | YesCommand ->
            model.NotificationManager.Show(Notification("Avalonia Notifications", "Start adding notifications to your app today."))

            model, []

        | NoCommand ->
            model.NotificationManager.Show(Notification("Avalonia Notifications", "Start adding notifications to your app today. To find out more visit..."))

            model, []

        //TODO What is this about?
        | AttachedToVisualTreeChanged args -> { NotificationManager = FabApplication.Current.WindowNotificationManager }, []

        | ControlNotificationsShow ->
            controlNotificationsRef.Value.Show(Notification("Control Notifications", "This notification is shown by the control itself."))
            model, []

    let program =
        //TODO What is this about? What's the diff to Program.statefulWithCmd and Program.stateful? When to use which?
        Program.statefulWithCmdMsg init update mapCmdMsgToCmd
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
        Component(program) {
            //TODO What is this about?
            let! model = Mvu.State

            (Dock() {
                TextBlock("TopLevel bound notification manager.")
                    .dock(Dock.Top)
                    .margin(2.)
                    .classes([ "h2" ])
                    .textWrapping(TextWrapping.Wrap)

                (VStack(4.) {
                    Button("Show Standard Managed Notification", ShowManagedNotification)
                    Button("Show Custom Managed Notification", ShowCustomManagedNotification)
                    Button("Notify async operation completed", ShowAsyncCompletedNotification)
                    Button("Notify status updates from async operation", ShowAsyncStatusNotifications)
                })
                    .dock(Dock.Top)
                    .horizontalAlignment(HorizontalAlignment.Left)

                TextBlock("Widget only notification manager.")
                    .dock(Dock.Top)
                    .margin(2.)
                    .classes([ "h2" ])
                    .textWrapping(TextWrapping.Wrap)

                Button("Show Widget only notification", ControlNotificationsShow)
                    .dock(Dock.Top)
                    .horizontalAlignment(HorizontalAlignment.Left)

                Border(
                    WindowNotificationManager(controlNotificationsRef)
                        .position(NotificationPosition.BottomRight)
                        .maxItems(3)
                )
                    .padding(10)
                    .borderBrush(SolidColorBrush(Colors.Yellow))

                CustomNotification("Avalonia Notifications", "Start adding notifications to your app today.", YesCommand, NoCommand)
                    .dock(Dock.Top)

                Border(
                    NotificationCard(false, "This is a notification card.")
                        .size(200., 100.)
                )
                    .dock(Dock.Top)
                    .padding(10)
                    .borderBrush(SolidColorBrush(Colors.Blue))

            })
                //TODO What is this about?
                .onAttachedToVisualTree(AttachedToVisualTreeChanged)
        }
