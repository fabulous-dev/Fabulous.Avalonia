namespace Gallery

open System
open Avalonia.Markup.Xaml.Styling
open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module App =
    let create () =
        let theme () =
            StyleInclude(baseUri = null, Source = Uri("avares://Gallery/App.xaml"))

        let program =
            Program.statefulWithCmdMsg State.init State.update State.mapCmdMsgToCmd
            |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
            |> Program.withExceptionHandler(fun ex ->
#if DEBUG
                printfn $"Exception: %s{ex.ToString()}"
                false
#else
                true
#endif
            )

#if MOBILE
            |> Program.withView MainView.view
#else
            |> Program.withView MainWindow.view
#endif

        FabulousAppBuilder.Configure(theme, program)
