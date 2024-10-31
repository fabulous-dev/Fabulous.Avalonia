namespace RenderDemo

open System
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open Fabulous

open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View

module MainView =
    type Model = { Details: DetailPage option }

    type Msg =
        | SelectControl of RoutedEventArgs
        | GoBack

    let init () = { Details = None }, Cmd.none

    let update msg model =
        match msg with
        | SelectControl args ->
            args.Handled <- true
            let control = args.Source :?> TextBlock

            let detailPage =
                match control.Text with
                | CurrentPage page -> Some page
                | _ -> None

            { Details = detailPage }, Cmd.none
        | GoBack -> { Details = None }, Cmd.none

    let controlNames =
        [ "Implicit Animations"
          "Draw Line Animation"
          "Compositor Animations"
          "Animations"
          "Spring Animations"
          "Transitions"
          "Render Transform"
          "Brushes"
          "Clipping"
          "Drawing"
          "Line Bounds"
          "Transform3D"
          "Writable Bitmap"
          "Render Target Bitmap"
          "Path Measurement"
          "Custom Animator"
          "SkCanvas"
          "GlyphRun"
          "FormattedText"
          "TextFormatter" ]

    let view model =
        SingleViewApplication() {
            ScrollViewer(
                match model.Details with
                | Some(CurrentWidget page) ->
                    AnyView(
                        VStack(16.) {
                            Button("Go back", GoBack)
                            page
                        }
                    )
                | _ ->
                    AnyView(
                        Grid() {
                            UniformGrid(cols = 2, rows = 37) {
                                for i in 0 .. controlNames.Length - 1 do
                                    CardItem(controlNames[i])
                                        .onTapped(SelectControl)
                                        .gridRow(i / 2)
                            }
                        }
                    )
            )
        }

    let create () =
        let theme () =
            StyleInclude(baseUri = null, Source = Uri("avares://RenderDemo/App.xaml"))

        let program =
            Program.statefulWithCmd init update
            |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
            |> Program.withExceptionHandler(fun ex ->
#if DEBUG
                printfn $"Exception: %s{ex.ToString()}"
                false
#else
                true
#endif
            )
            |> Program.withView view

        FabulousAppBuilder.Configure(theme, program)
