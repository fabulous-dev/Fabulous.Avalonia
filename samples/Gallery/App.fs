namespace Gallery

open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module App =
    let program =
        Program.statefulWithCmdMsg Root.State.init Root.State.update Root.View.view Root.State.mapCmdMsgToCmd
        |> Program.withThemeAwareness
#if DEBUG
        |> Program.withLogger
            { ViewHelpers.defaultLogger() with
                MinLogLevel = LogLevel.Debug }
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
#endif
