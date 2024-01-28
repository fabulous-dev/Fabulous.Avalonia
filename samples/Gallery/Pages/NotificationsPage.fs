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
        | YesCommand
        | NoCommand
        | AttachedToVisualTreeChanged of VisualTreeAttachmentEventArgs
        | ControlNotificationsShow

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let controlNotificationsRef = ViewRef<WindowNotificationManager>()

    let init () = { NotificationManager = null }, []

    let update msg model =
        match msg with
        | ShowManagedNotification ->

            model.NotificationManager.Position <- NotificationPosition.BottomRight

            model.NotificationManager.Show(Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information))

            model, []
        | ShowCustomManagedNotification ->
            model.NotificationManager.Show(NotificationViewModel("Hey There!", "Did you know that Avalonia now supports Custom In-Window Notifications?"))

            model, []
        | ShowNativeNotification ->
            model.NotificationManager.Show(Notification("Error", "Native Notifications are not quite ready. Coming soon.", NotificationType.Error))

            model, []
        | YesCommand ->
            model.NotificationManager.Show(Notification("Avalonia Notifications", "Start adding notifications to your app today."))

            model, []

        | NoCommand ->
            model.NotificationManager.Show(Notification("Avalonia Notifications", "Start adding notifications to your app today. To find out more visit..."))

            model, []

        | AttachedToVisualTreeChanged args -> { NotificationManager = FabApplication.Current.WindowNotificationManager }, []

        | ControlNotificationsShow ->
            controlNotificationsRef.Value.Show(Notification("Control Notifications", "This notification is shown by the control itself."))
            model, []

    let program =
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
                .onAttachedToVisualTree(AttachedToVisualTreeChanged)
        }
