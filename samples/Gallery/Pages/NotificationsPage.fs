namespace Gallery.Pages

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous
open Avalonia.Controls.Notifications

open type Fabulous.Avalonia.View
open Gallery

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
        { WindowNotificationManager: WindowNotificationManager }

    type Msg =
        | ShowManagedNotification
        | ShowCustomManagedNotification
        | ShowNativeNotification
        | YesCommand
        | NoCommand
        | Loaded of bool

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { WindowNotificationManager = Unchecked.defaultof<_> }, []

    let update msg model =
        match msg with
        | Loaded _ ->
#if MOBILE
            let mainView = (Application.Current :?> FabApplication).MainView
            let topLevel = TopLevel.GetTopLevel(mainView)
#else
            let mainWindow = (Application.Current :?> FabApplication).MainWindow
            let topLevel = TopLevel.GetTopLevel(mainWindow)
#endif
            { model with
                WindowNotificationManager = WindowNotificationManager(topLevel) },
            []
        | ShowManagedNotification ->
            model.WindowNotificationManager.Position <- NotificationPosition.BottomRight
            model.WindowNotificationManager.Show(Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information))
            model, []
        | ShowCustomManagedNotification ->
            model.WindowNotificationManager.Show(NotificationViewModel("Hey There!", "Did you know that Avalonia now supports Custom In-Window Notifications?"))
            model, []
        | ShowNativeNotification ->
            model.WindowNotificationManager.Show(Notification("Error", "Native Notifications are not quite ready. Coming soon.", NotificationType.Error))
            model, []

        | YesCommand ->
            model.WindowNotificationManager.Show(Notification("Avalonia Notifications", "Start adding notifications to your app today."))

            model, []

        | NoCommand ->
            model.WindowNotificationManager.Show(
                Notification("Avalonia Notifications", "Start adding notifications to your app today. To find out more visit...")
            )

            model, []

    let view _ =
        (VStack(4.) {
            Button("Show Standard Managed Notification", ShowManagedNotification)
                .onLoaded(Loaded)

            Button("Show Custom Managed Notification", ShowCustomManagedNotification)
            Button("Show Native Notification", ShowNativeNotification)

            CustomNotificationView.view "Avalonia Notifications" "Start adding notifications to your app today." YesCommand NoCommand
        })
            .horizontalAlignment(HorizontalAlignment.Left)
