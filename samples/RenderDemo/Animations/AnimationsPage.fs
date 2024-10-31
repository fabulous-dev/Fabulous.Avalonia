namespace RenderDemo

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open Fabulous.Avalonia.Mvu

open type Fabulous.Avalonia.Mvu.View

module AnimationsPage =
    let borderTest1 (this: WidgetBuilder<'msg, IFabMvuBorder>) =
        this.child(
            Path(Paths.Path1)
                .fill(SolidColorBrush(Colors.White))
                .stretch(Stretch.Uniform)
        )

    let borderTest2 (this: WidgetBuilder<'msg, IFabMvuBorder>) =
        this.child(
            Path(Paths.Path2)
                .fill(SolidColorBrush(Colors.Red))
                .stretch(Stretch.Uniform)
        )

    let view () =
        ScrollViewer(
            VStack() {
                Grid() {
                    (VStack() {
                        (HStack(20.) {
                            TextBlock("Hover to activate Keyframe Animations.")
                                .verticalAlignment(VerticalAlignment.Center)
                        })
                            .verticalAlignment(VerticalAlignment.Center)

                        UserControl(
                            HWrap() {
                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect1" ])
                                    .background(Brushes.DarkRed)

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect2" ])
                                    .background(Brushes.Magenta)

                                EmptyBorder()
                                    .style(borderTest2)
                                    .classes([ "Test"; "Rect3" ])

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect4" ])
                                    .background(Brushes.Navy)

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect5" ])
                                    .background(Brushes.SeaGreen)

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect6" ])
                                    .background(Brushes.Red)

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Shadow" ])
                                    .cornerRadius(CornerRadius(10.))

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Shadow" ])
                                    .cornerRadius(CornerRadius(0., 30., 60., 0.))

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect7" ])

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect8" ])

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect9" ])

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect10" ])

                                EmptyBorder()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Blur" ])
                                    .background(Brushes.AliceBlue)
                                    .borderThickness(Thickness(4.))
                                    .borderBrush(Brushes.Yellow)
                                    .padding(Thickness(10.))

                                Border(
                                    TextBlock("Drop Shadow")
                                        .verticalAlignment(VerticalAlignment.Center)
                                        .horizontalAlignment(HorizontalAlignment.Center)
                                )
                                    .style(borderTest1)
                                    .classes([ "Test"; "DropShadow" ])
                                    .background(Brushes.Transparent)
                                    .borderThickness(Thickness(4.))
                                    .borderBrush(Brushes.Yellow)
                                    .child(
                                        TextBlock("Drop Shadow")
                                            .verticalAlignment(VerticalAlignment.Center)
                                            .horizontalAlignment(HorizontalAlignment.Center)
                                    )
                            }
                        )
                            .styleInclude([ "avares://RenderDemo/Styles/Animations.xaml" ])
                    })
                        .horizontalAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Center)
                        .clipToBounds(false)
                }
            }
        )
