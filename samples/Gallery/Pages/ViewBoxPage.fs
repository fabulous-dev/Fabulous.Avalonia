namespace Gallery

open System.Diagnostics
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ViewBoxPage =
    type Model = { Width: float; Height: float }

    type Msg =
        | HeightChanged of float
        | WidthChanged of float

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Width = 300.; Height = 300. }, []

    let update msg model =
        match msg with
        | HeightChanged height -> { model with Height = height }, []
        | WidthChanged width -> { model with Width = width }, []

    let program =
        Program.statefulWithCmdMsg init update mapCmdMsgToCmd
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component(program) {
            let! model = Mvu.State

            Grid(coldefs = [ Pixel(300.); Star ], rowdefs = [ Pixel(300.) ]) {
                Border(
                    ViewBox(
                        Ellipse()
                            .size(50., 50.)
                            .fill(SolidColorBrush(Colors.CornflowerBlue))
                    )
                        .size(model.Width, model.Height)
                        .stretch(Stretch.Uniform)
                )
                    .borderBrush(SolidColorBrush(Colors.Black))
                    .borderThickness(1.)
                    .gridRow(0)
                    .gridColumn(0)

                (VStack() {
                    TextBlock($"Height: {model.Height}")
                    Slider(0., 300., model.Height, HeightChanged)
                    TextBlock($"Width: {model.Width}")
                    Slider(0., 300., model.Width, WidthChanged)
                })
                    .gridRow(0)
                    .gridColumn(1)
            }
        }
