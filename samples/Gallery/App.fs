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
    let program =
#if MOBILE
        Program.statefulWithCmdMsg State.init State.update MainView.view State.mapCmdMsgToCmd
#else
        Program.statefulWithCmdMsg State.init State.update MainWindow.view State.mapCmdMsgToCmd
#endif
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
#else
#endif
        )
#endif
