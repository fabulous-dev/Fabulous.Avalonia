namespace Gallery

open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Gallery
open Avalonia.Threading
open System

open type Fabulous.Avalonia.View


module App =
    let subscription (_model: Root.Types.Model) =
        Cmd.ofSub(fun dispatch ->
            DispatcherTimer.Run(
                Func<bool>(fun _ ->
                    dispatch(Root.Types.Msg.Update(DateTime.Now))
                    true),
                TimeSpan.FromMilliseconds 1000.0
            )
            |> ignore)

    let program =
        Program.statefulWithCmdMsg Root.State.init Root.State.update Root.View.view Root.State.mapCmdMsgToCmd
        |> Program.withSubscription subscription
        |> Program.withThemeAwareness
#if DEBUG
        |> Program.withLogger
            { ViewHelpers.defaultLogger() with
                MinLogLevel = LogLevel.Debug }
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#endif
        )
#endif
