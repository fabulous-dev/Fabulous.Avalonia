namespace Gallery

open Avalonia.Controls
open Avalonia.Input
open Avalonia.Input.GestureRecognizers
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

// https://github.com/AvaloniaUI/Avalonia/blob/master/samples/ControlCatalog/Pages/GesturePage.cs
module Gestures =
    type Model = { CurrentScale: float }

    type Msg = | Reset

    let init () = { CurrentScale = 0 }

    let topBallBorderRef = ViewRef<Border>()

    let update msg model =
        match msg with
        | Reset -> model

    let view _ =
        VStack(spacing = 4.) {
            TextBlock("Pull Gexture (Touch / Pen)").fontSize(18.).margin(5.)
            TextBlock("Pull from colored rectangles").margin(5.)

            Border(
                (Dock() {
                    Border(
                        Border()
                            .width(10.)
                            .height(10.)
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .cornerRadius(5.)
                            .name("TopBall")
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Top)
                        .margin(2.)
                        .name("TopPullZone")
                        .reference(topBallBorderRef)
                        .background(SolidColorBrush(Colors.Transparent))
                        .borderBrush(SolidColorBrush(Colors.Red))
                        .horizontalAlignment(HorizontalAlignment.Stretch)
                        .height(50.)
                        .borderThickness(1.)
                        .gestureRecognizers([ PullGestureRecognizer(PullDirection.TopToBottom) ])

                    Border(
                        Border()
                            .width(10.)
                            .name("BottomBall")
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .height(10.)
                            .cornerRadius(5.)
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Bottom)
                        .borderBrush(SolidColorBrush(Colors.Green))
                        .margin(2.)
                        .background(SolidColorBrush(Colors.Transparent))
                        .name("BottomPullZone")
                        .horizontalAlignment(HorizontalAlignment.Stretch)
                        .height(50.)
                        .borderThickness(1.)
                        .gestureRecognizers([ PullGestureRecognizer(PullDirection.BottomToTop) ])

                    Border(
                        Border()
                            .width(10.)
                            .height(10.)
                            .name("RightBall")
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .cornerRadius(5.)
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Right)
                        .margin(2.)
                        .background(SolidColorBrush(Colors.Transparent))
                        .name("RightPullZone")
                        .borderBrush(SolidColorBrush(Colors.Blue))
                        .horizontalAlignment(HorizontalAlignment.Right)
                        .verticalAlignment(VerticalAlignment.Stretch)
                        .width(50.)
                        .borderThickness(1.)
                        .gestureRecognizers([ PullGestureRecognizer(PullDirection.RightToLeft) ])

                    Border(
                        Border()
                            .width(10.)
                            .height(10.)
                            .name("LeftBall")
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .cornerRadius(5.)
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Left)
                        .margin(2.)
                        .background(SolidColorBrush(Colors.Transparent))
                        .name("LeftPullZone")
                        .borderBrush(SolidColorBrush(Colors.Orange))
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .verticalAlignment(VerticalAlignment.Stretch)
                        .width(50.)
                        .borderThickness(1.)
                        .gestureRecognizers([ PullGestureRecognizer(PullDirection.LeftToRight) ])
                })
                    .horizontalAlignment(HorizontalAlignment.Stretch)
                    .clipToBounds(true)
                    .margin(5.)
                    .height(200.)
            )

            TextBlock("Pinch/Zoom Gexture (Multi Touch)")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)
                .margin(5.)

            Border(
                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .size(100., 100.)
                    .gestureRecognizers([ PinchGestureRecognizer(); ScrollGestureRecognizer() ])
            )
                .clipToBounds(true)

            Button("Reset", Reset)
                .horizontalAlignment(HorizontalAlignment.Center)
                .name("ResetButton")
        }

    let sample =
        { Name = "Gestures"
          Description = "Gestures sample"
          Program = Helper.createProgram init update view }
