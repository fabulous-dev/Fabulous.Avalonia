namespace RenderDemo

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TransitionsPage =
    let borderTest1 (this: WidgetBuilder<'msg, IFabBorder>) =
        this.child(
            Path(Paths.Path1)
                .fill(SolidColorBrush(Colors.White))
                .stretch(Stretch.Uniform)
        )

    let borderTest2 (this: WidgetBuilder<'msg, IFabBorder>) =
        this.child(
            Path(Paths.Path2)
                .fill(SolidColorBrush(Colors.Red))
                .stretch(Stretch.Uniform)
        )

    let view () =
        Grid() {
            (VStack() {
                (HStack(20.) {
                    TextBlock("Hover to activate Transitions.")
                        .verticalAlignment(VerticalAlignment.Center)
                })
                    .verticalAlignment(VerticalAlignment.Center)

                UserControl(
                    (HWrap() {
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
                            .background(Brushes.Orange)
                            .transition(
                                TransformOperationsTransition(Border.RenderTransformProperty, TimeSpan.FromMilliseconds(500.))
                                    .delay(TimeSpan.FromMilliseconds(1000.))
                            )

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect7" ])
                            .background(Brushes.Gold)

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect8" ])
                            .background(Brushes.Gray)

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect9" ])
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
                            .classes([ "Test"; "Shadow" ])
                            .cornerRadius(CornerRadius(0., 30., 60., 0.))

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect10" ])


                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect11" ])

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect12" ])

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect13" ])

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect14" ])

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect14" ])

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect14" ])

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect14" ])

                        EmptyBorder()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect14" ])
                    })
                        .clipToBounds(false)
                )
                    .styleInclude([ "avares://RenderDemo/Styles/Transitions.xaml" ])

            })
                .horizontalAlignment(HorizontalAlignment.Center)
                .verticalAlignment(VerticalAlignment.Center)
                .clipToBounds(false)
        }
