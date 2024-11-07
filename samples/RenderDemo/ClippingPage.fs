namespace RenderDemo

open System
open System.Diagnostics
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ClippingPage =
    type Model = { IsChecked: bool; BrushColor: IBrush }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs
        | CheckChanged of bool

    let init () =
        { IsChecked = false
          BrushColor = Brushes.Yellow },
        Cmd.none

    let update msg model =
        match msg with
        | OnPointerEnter _ ->
            { model with
                BrushColor = Brushes.Crimson },
            Cmd.none
        | OnPointerExited _ ->
            { model with
                BrushColor = Brushes.Yellow },
            Cmd.none
        | CheckChanged isChecked -> { model with IsChecked = isChecked }, Cmd.none

    let clip =
        """
 M 58.625 0.07421875
 C 50.305778 0.26687364 42.411858 7.0346526 41.806641 15.595703
 C 42.446442 22.063923 39.707425 13.710754 36.982422 12.683594
 C 29.348395 6.1821635 16.419398 8.4359222 11.480469 17.195312
 C 6.0935256 25.476803 9.8118851 37.71125 18.8125 41.6875
 C 9.1554771 40.62945 -0.070876925 49.146842 0.21679688 58.857422 
 C 0.21545578 60.872512 0.56758794 62.88911 1.2617188 64.78125 
 C 4.3821886 74.16708 16.298268 78.921772 25.03125 74.326172 
 C 28.266843 72.062552 26.298191 74.214838 25.414062 76.398438
 C 21.407348 85.589198 27.295992 97.294293 37.097656 99.501953 
 C 46.864883 102.3541 57.82177 94.726518 58.539062 84.580078 
 C 58.142158 79.498998 59.307538 83.392694 61.207031 85.433594 
 C 67.532324 93.056874 80.440232 93.192029 86.882812 85.630859 
 C 93.836392 78.456939 92.396838 65.538666 84.115234 60.009766 
 C 79.783641 57.904836 83.569793 58.802369 86.375 58.193359 
 C 96.383335 56.457569 102.87506 44.824101 99.083984 35.394531 
 C 95.963498 26.008711 84.047451 21.254079 75.314453 25.849609
 C 72.078834 28.113269 74.047517 25.960974 74.931641 23.777344 
 C 78.93827 14.586564 73.049722 2.8815081 63.248047 0.67382812
 C 61.721916 0.22817968 60.165597 0.038541919 58.625 0.07421875 z 
"""

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

    let view () =
        Component("ClippingPage") {
            let! model = Context.Mvu program

            (Grid(coldefs = [ Auto ], rowdefs = [ Auto; Auto ]) {
                let widgetBuilder =
                    Border(
                        Border(
                            TextBlock("Avalonia")
                                .opacity(0.9)
                                .verticalAlignment(VerticalAlignment.Center)
                        )
                            .name("clipChild")
                            .margin(4.)
                            .background(Brushes.Red)
                            .width(100.)
                            .height(100.)
                            .renderTransform(RotateTransform())
                            .animation(
                                Animation(KeyFrame(RotateTransform.AngleProperty, 360.).cue(1.), TimeSpan.FromSeconds(2.))
                                    .repeatForever()
                            )
                    )
                        .name("clipped")
                        .background(model.BrushColor)
                        .onPointerEntered(OnPointerEnter)
                        .onPointerExited(OnPointerExited)
                        .width(100.)
                        .height(100.)

                if model.IsChecked then
                    widgetBuilder.clip(PathGeometry(clip, FillRule.EvenOdd))
                else
                    widgetBuilder

                CheckBox(model.IsChecked, CheckChanged, TextBlock("Apply Geometry Clip"))
                    .gridRow(1)
            })
                .centerHorizontal()
        }
