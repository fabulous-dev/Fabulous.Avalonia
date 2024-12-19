namespace Gallery

open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module GesturesPage =
    type Model = { CurrentScale: float }

    type Msg =
        | Reset
        | OnPullGesture of PullGestureEventArgs
        | OnPinchGesture of PinchEventArgs
        | OnScrollGesture of ScrollGestureEventArgs
        | OnAttachedToVisualTree of VisualTreeAttachmentEventArgs
        | OnTapGesture of TappedEventArgs

    let init () = { CurrentScale = 0 }, Cmd.none

    let update msg model =
        match msg with
        | Reset -> model, []
        | OnPullGesture args -> model, []
        | OnScrollGesture args -> model, []
        | OnAttachedToVisualTree args -> model, []
        | OnTapGesture tappedEventArgs -> model, []
        | OnPinchGesture pinchEventArgs -> model, []
        
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
        Component("GesturesPage") {
            let! model = Context.Mvu program
            VStack() {
                TextBlock("Pull from colored rectangles").margin(5.)
            }
        }

        //     Border(
        //         (Dock() {
        //             Border(
        //                 Border()
        //                     .width(10.)
        //                     .height(10.)
        //                     .horizontalAlignment(HorizontalAlignment.Center)
        //                     .verticalAlignment(VerticalAlignment.Center)
        //                     .cornerRadius(5.)
        //                     .name("TopBall")
        //                     .background(SolidColorBrush(Colors.Green))
        //             )
        //                 .dock(Dock.Top)
        //                 .margin(2.)
        //                 .name("TopPullZone")
        //                 .reference(topBallBorderRef)
        //                 .background(SolidColorBrush(Colors.Transparent))
        //                 .borderBrush(SolidColorBrush(Colors.Red))
        //                 .horizontalAlignment(HorizontalAlignment.Stretch)
        //                 .height(50.)
        //                 .borderThickness(1.)
        //                 .gestureRecognizers() {
        //                 PullGestureRecognizer(OnPullGesture)
        //                     .pullDirection(PullDirection.TopToBottom)
        //             }
        //
        //
        //             Border(
        //                 Border()
        //                     .width(10.)
        //                     .name("BottomBall")
        //                     .horizontalAlignment(HorizontalAlignment.Center)
        //                     .verticalAlignment(VerticalAlignment.Center)
        //                     .height(10.)
        //                     .cornerRadius(5.)
        //                     .background(SolidColorBrush(Colors.Green))
        //             )
        //                 .dock(Dock.Bottom)
        //                 .borderBrush(SolidColorBrush(Colors.Green))
        //                 .margin(2.)
        //                 .background(SolidColorBrush(Colors.Transparent))
        //                 .name("BottomPullZone")
        //                 .horizontalAlignment(HorizontalAlignment.Stretch)
        //                 .height(50.)
        //                 .borderThickness(1.)
        //                 .gestureRecognizers() {
        //                 PullGestureRecognizer(OnPullGesture)
        //                     .pullDirection(PullDirection.BottomToTop)
        //             }
        //
        //             Border(
        //                 Border()
        //                     .width(10.)
        //                     .height(10.)
        //                     .name("RightBall")
        //                     .horizontalAlignment(HorizontalAlignment.Center)
        //                     .verticalAlignment(VerticalAlignment.Center)
        //                     .cornerRadius(5.)
        //                     .background(SolidColorBrush(Colors.Green))
        //             )
        //                 .dock(Dock.Right)
        //                 .margin(2.)
        //                 .background(SolidColorBrush(Colors.Transparent))
        //                 .name("RightPullZone")
        //                 .borderBrush(SolidColorBrush(Colors.Blue))
        //                 .horizontalAlignment(HorizontalAlignment.Right)
        //                 .verticalAlignment(VerticalAlignment.Stretch)
        //                 .width(50.)
        //                 .borderThickness(1.)
        //                 .gestureRecognizers() {
        //                 PullGestureRecognizer(OnPullGesture)
        //                     .pullDirection(PullDirection.RightToLeft)
        //             }
        //
        //             Border(
        //                 Border()
        //                     .width(10.)
        //                     .height(10.)
        //                     .name("LeftBall")
        //                     .horizontalAlignment(HorizontalAlignment.Center)
        //                     .verticalAlignment(VerticalAlignment.Center)
        //                     .cornerRadius(5.)
        //                     .background(SolidColorBrush(Colors.Green))
        //             )
        //                 .dock(Dock.Left)
        //                 .margin(2.)
        //                 .background(SolidColorBrush(Colors.Transparent))
        //                 .name("LeftPullZone")
        //                 .borderBrush(SolidColorBrush(Colors.Orange))
        //                 .horizontalAlignment(HorizontalAlignment.Left)
        //                 .verticalAlignment(VerticalAlignment.Stretch)
        //                 .width(50.)
        //                 .borderThickness(1.)
        //                 .gestureRecognizers() {
        //                 PullGestureRecognizer(OnPullGesture)
        //                     .pullDirection(PullDirection.LeftToRight)
        //             }
        //         })
        //             .horizontalAlignment(HorizontalAlignment.Stretch)
        //             .clipToBounds(true)
        //             .margin(5.)
        //
        //         TextBlock("Pull from colored rectangles").margin(5.)
        //
        //     Border(
        //         Image(ImageSource.fromString "avares://Gallery/Assets/Icons/delicate-arch-896885_640.jpg", Stretch.UniformToFill)
        //             .gestureRecognizers() {
        //             PinchGestureRecognizer(OnPinchGesture)
        //
        //             ScrollGestureRecognizer(OnScrollGesture)
        //                 .canHorizontallyScroll(true)
        //                 .canVerticallyScroll(true)
        //         }
        //
        //     )
        //         .clipToBounds(true)
        //
        //     Button("Reset", Reset)
        //         .horizontalAlignment(HorizontalAlignment.Center)
        //         .name("ResetButton")
        // })
        //     .onAttachedToVisualTree(OnAttachedToVisualTree)
