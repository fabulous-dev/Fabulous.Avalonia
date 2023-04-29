namespace Gallery

open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module App =

#if MOBILE || BROWSER
    let app model = Root.MainView.view model
#else
    let app model = Root.MainWindow.view model
#endif

    let program =
        Program.statefulWithCmd Root.State.init Root.State.update app
        |> Program.withThemeAwareness
#if DEBUG
        |> Program.withLogger
            { ViewHelpers.defaultLogger() with
                MinLogLevel = LogLevel.Debug }
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
#endif
