namespace Gallery

open System
open Avalonia.Markup.Xaml.Styling
open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module App =
    let theme = StyleInclude(baseUri = null, Source = Uri("avares://Gallery/App.xaml"))

    let program =
#if MOBILE
        Program.statefulWithCmdMsg State.init State.update State.mapCmdMsgToCmd
#else
        Program.statefulWithCmdMsg State.init State.update State.mapCmdMsgToCmd
#endif
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )
        |> Program.withView MainWindow.view
