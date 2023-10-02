namespace Gallery

open System.Diagnostics
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module App =
    let program =
#if MOBILE
        Program.statefulWithCmdMsg State.init State.update MainView.view State.mapCmdMsgToCmd
#else
        Program.statefulWithCmdMsg State.init State.update MainWindow.view State.mapCmdMsgToCmd
#endif
        |> Program.withThemeAwareness
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )
