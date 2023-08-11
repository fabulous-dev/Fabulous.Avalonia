namespace Gallery

open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Gallery
open Avalonia.Threading
open System

open type Fabulous.Avalonia.View
open Gallery.Root


module App =
    let subscription (_model: Types.Model) =
        Cmd.ofSub(fun dispatch ->
            DispatcherTimer.Run(
                Func<bool>(fun _ ->
                    dispatch(Types.Msg.Update(DateTime.Now))
                    true),
                TimeSpan.FromMilliseconds 1000.0
            )
            |> ignore)

    let program =
#if MOBILE
        Program.statefulWithCmdMsg State.init State.update MainView.view State.mapCmdMsgToCmd
#else
        Program.statefulWithCmdMsg State.init State.update MainWindow.view State.mapCmdMsgToCmd
#endif
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
