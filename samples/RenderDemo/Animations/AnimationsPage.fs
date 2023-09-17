namespace RenderDemo

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module AnimationsPage =
    type Model =
        { Animations1: Animations1.Model
          Animations2: Animations2.Model
          Animations3: Animations3.Model }

    type Msg =
        | Animations1 of Animations1.Msg
        | Animations2 of Animations2.Msg
        | Animations3 of Animations3.Msg

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Animations1 = Animations1.init()
          Animations2 = Animations2.init()
          Animations3 = Animations3.init() },
        []

    let update msg model =
        match msg with
        | Animations1 msg ->
            let transitions1 = Animations1.update msg model.Animations1

            { model with
                Animations1 = transitions1 },
            []

        | Animations2 msg ->
            let transitions2 = Animations2.update msg model.Animations2

            { model with
                Animations2 = transitions2 },
            []

        | Animations3 msg ->
            let transitions3 = Animations3.update msg model.Animations3

            { model with
                Animations3 = transitions3 },
            []

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

    let view (model: Model) =
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
                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect1" ])
                                    .background(Brushes.DarkRed)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect2" ])
                                    .background(Brushes.Magenta)

                                Border().style(borderTest2).classes([ "Test"; "Rect3" ])

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect4" ])
                                    .background(Brushes.Navy)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect5" ])
                                    .background(Brushes.SeaGreen)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect6" ])
                                    .background(Brushes.Red)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Shadow" ])
                                    .cornerRadius(CornerRadius(10.))
                                    .child(null)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Shadow" ])
                                    .cornerRadius(CornerRadius(0., 30., 60., 0.))
                                    .child(null)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect7" ])
                                    .child(null)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect8" ])
                                    .child(null)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect9" ])
                                    .child(null)

                                Border()
                                    .style(borderTest1)
                                    .classes([ "Test"; "Rect10" ])
                                    .child(null)

                                Border()
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
                            .styles([ "avares://RenderDemo/Styles/Animations.xaml" ])
                    })
                        .horizontalAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Center)
                        .clipToBounds(false)
                }

                View.map Animations1 (Animations1.view model.Animations1)
                View.map Animations2 (Animations2.view model.Animations2)
                View.map Animations3 (Animations3.view model)
            }
        )
