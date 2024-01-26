namespace Gallery

open System
open System.Diagnostics
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous
open Avalonia.Controls.Notifications

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
    type Model = { Nothing: string }

    type Msg =
        | ShowManagedNotification
        | ShowCustomManagedNotification
        | ShowNativeNotification
        | YesCommand
        | NoCommand

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let notificationManager () =
        FabApplication.Current.WindowNotificationManager

    let init () = { Nothing = "" }, []

    let update msg model =
        match msg with
        | ShowManagedNotification ->
            notificationManager().Position <- NotificationPosition.BottomRight

            notificationManager()
                .Show(Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information))

            model, []
        | ShowCustomManagedNotification ->
            notificationManager()
                .Show(NotificationViewModel("Hey There!", "Did you know that Avalonia now supports Custom In-Window Notifications?"))

            model, []
        | ShowNativeNotification ->
            notificationManager()
                .Show(Notification("Error", "Native Notifications are not quite ready. Coming soon.", NotificationType.Error))

            model, []
        | YesCommand ->
            notificationManager()
                .Show(Notification("Avalonia Notifications", "Start adding notifications to your app today."))

            model, []

        | NoCommand ->
            notificationManager()
                .Show(Notification("Avalonia Notifications", "Start adding notifications to your app today. To find out more visit..."))

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

            (VStack(4.) {
                Button("Show Standard Managed Notification", ShowManagedNotification)

                Button("Show Custom Managed Notification", ShowCustomManagedNotification)
                Button("Show Native Notification", ShowNativeNotification)

                CustomNotification("Avalonia Notifications", "Start adding notifications to your app today.", YesCommand, NoCommand)
            })
                .horizontalAlignment(HorizontalAlignment.Left)
        }
