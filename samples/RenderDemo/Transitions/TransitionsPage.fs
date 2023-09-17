namespace RenderDemo

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TransitionsPage =
    type Msg =
        | Transition1Msg of Transitions1.Msg
        | Transition2Msg of Transitions2.Msg
        | Transition3Msg of Transitions3.Msg
        | Transition4Msg of Transitions4.Msg
        | Transition5Msg of Transitions5.Msg
        | Transition6Msg of Transitions6.Msg
        | Transition7Msg of Transitions7.Msg
        | Transition8Msg of Transitions8.Msg
        | Transition9Msg of Transitions9.Msg
        | Transition10Msg of Transitions10.Msg
        | Transition11Msg of Transitions11.Msg
        | Transition12Msg of Transitions12.Msg

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    type Model =
        { Transitions1: Transitions1.Model
          Transitions2: Transitions2.Model
          Transitions3: Transitions3.Model
          Transitions4: Transitions4.Model
          Transitions5: Transitions5.Model
          Transitions6: Transitions6.Model
          Transitions7: Transitions7.Model
          Transitions8: Transitions8.Model
          Transitions9: Transitions9.Model
          Transitions10: Transitions10.Model
          Transitions11: Transitions11.Model
          Transitions12: Transitions12.Model }

    let init () =
        { Transitions1 = Transitions1.init()
          Transitions2 = Transitions2.init()
          Transitions3 = Transitions3.init()
          Transitions4 = Transitions4.init()
          Transitions5 = Transitions5.init()
          Transitions6 = Transitions6.init()
          Transitions7 = Transitions7.init()
          Transitions8 = Transitions8.init()
          Transitions9 = Transitions9.init()
          Transitions10 = Transitions10.init()
          Transitions11 = Transitions11.init()
          Transitions12 = Transitions12.init() },
        []

    let update msg model =
        match msg with
        | Transition1Msg msg ->
            let transitions1 = Transitions1.update msg model.Transitions1

            { model with
                Transitions1 = transitions1 },
            []

        | Transition2Msg msg ->
            let transitions2 = Transitions2.update msg model.Transitions2

            { model with
                Transitions2 = transitions2 },
            []

        | Transition3Msg msg ->
            let transitions3 = Transitions3.update msg model.Transitions3

            { model with
                Transitions3 = transitions3 },
            []

        | Transition4Msg msg ->
            let transitions4 = Transitions4.update msg model.Transitions4

            { model with
                Transitions4 = transitions4 },
            []

        | Transition5Msg msg ->
            let transitions5 = Transitions5.update msg model.Transitions5

            { model with
                Transitions5 = transitions5 },
            []

        | Transition6Msg msg ->
            let transitions6 = Transitions6.update msg model.Transitions6

            { model with
                Transitions6 = transitions6 },
            []

        | Transition7Msg msg ->
            let transitions7 = Transitions7.update msg model.Transitions7

            { model with
                Transitions7 = transitions7 },
            []

        | Transition8Msg msg ->
            let transitions8 = Transitions8.update msg model.Transitions8

            { model with
                Transitions8 = transitions8 },
            []

        | Transition9Msg msg ->
            let transitions9 = Transitions9.update msg model.Transitions9

            { model with
                Transitions9 = transitions9 },
            []

        | Transition10Msg msg ->
            let transitions10 = Transitions10.update msg model.Transitions10

            { model with
                Transitions10 = transitions10 },
            []

        | Transition11Msg msg ->
            let transitions11 = Transitions11.update msg model.Transitions11

            { model with
                Transitions11 = transitions11 },
            []

        | Transition12Msg msg ->
            let transitions12 = Transitions12.update msg model.Transitions12

            { model with
                Transitions12 = transitions12 },
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

    let view model =
        Grid() {
            (VStack() {
                (HStack(20.) {
                    TextBlock("Hover to activate Transitions.")
                        .verticalAlignment(VerticalAlignment.Center)
                })
                    .verticalAlignment(VerticalAlignment.Center)

                UserControl(
                    (HWrap() {
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
                            .background(Brushes.Orange)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect7" ])
                            .background(Brushes.Gold)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect8" ])
                            .background(Brushes.Gray)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect9" ])
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
                            .classes([ "Test"; "Shadow" ])
                            .cornerRadius(CornerRadius(0., 30., 60., 0.))
                            .child(null)

                        Border().style(borderTest1).classes([ "Test"; "Rect10" ])


                        Border().style(borderTest1).classes([ "Test"; "Rect11" ])

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect12" ])
                            .child(null)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect13" ])
                            .child(null)

                        Border()
                            .style(borderTest1)
                            .classes([ "Test"; "Rect14" ])
                            .child(null)

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])

                        Border().style(borderTest1).classes([ "Test"; "Rect14" ])
                    })
                        .clipToBounds(false)
                )
                    .styles([ "avares://RenderDemo/Styles/Transitions.xaml" ])

            })
                .horizontalAlignment(HorizontalAlignment.Center)
                .verticalAlignment(VerticalAlignment.Center)
                .clipToBounds(false)
        }
