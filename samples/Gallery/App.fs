namespace Gallery

open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Gallery
open Gallery.Root.Types

open type Fabulous.Avalonia.View

module App =
    let navigationController = NavigationController()

    let navigationSubscription _model =
        Cmd.ofSub(fun dispatch ->
            navigationController.NavigationRequested.Add(fun route -> dispatch(NavigationMsg route))
            navigationController.BackNavigationRequested.Add(fun () -> dispatch BackButtonPressed))

    let program =
        Program.statefulWithCmdMsg Root.State.init Root.State.update Root.View.view (Root.State.mapCmdMsgToCmd navigationController)
        |> Program.withSubscription navigationSubscription
        |> Program.withThemeAwareness
#if DEBUG
        |> Program.withLogger
            { ViewHelpers.defaultLogger() with
                MinLogLevel = LogLevel.Debug }
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
#endif
