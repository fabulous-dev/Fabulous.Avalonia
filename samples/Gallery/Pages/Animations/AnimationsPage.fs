namespace Gallery.Pages

open Avalonia.Animation
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

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

    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NoMsg -> Navigation.goBack nav

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
                Animations1 = transitions1 }

        | Animations2 msg ->
            let transitions2 = Animations2.update msg model.Animations2

            { model with
                Animations2 = transitions2 }

        | Animations3 msg ->
            let transitions3 = Animations3.update msg model.Animations3

            { model with
                Animations3 = transitions3 }


    let view model =
        (VStack(32.) {
            View.map Animations1 (Animations1.view model)
            View.map Animations2 (Animations2.view model)
            View.map Animations3 (Animations3.view model)
        })
            .clock(Clock())
