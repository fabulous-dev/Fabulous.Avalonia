namespace Gallery.Pages

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module StylesPage =
    type Model = { IsOpen: bool }

    type Msg = | Open

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { IsOpen = false }, []

    let update msg model =
        match msg with
        | Open -> { model with IsOpen = not model.IsOpen }, []

    let view _ =
        UserControl(
            (VStack(spacing = 15.) {
                TextBlock("I'm a Heading1!").classes([ "h1" ])

                TextBlock("I'm a Heading2!").classes([ "h2" ])

                TextBlock("I'm a Heading3!").classes([ "h3" ])

                TextBlock("I'm a Heading4!").classes([ "h4" ])

                TextBlock("I'm a Heading5!").classes([ "h5" ])

                TextBlock("I'm a Heading6!").classes([ "h6" ])

                TextBlock("I'm a Body1!").classes([ "h7" ])

                TextBlock("I'm a Body2!").classes([ "h8" ])

                TextBlock("I'm a Body3!").classes([ "h9" ])

                TextBlock("I'm just a text")

            })
        )
            .styles([ "avares://Gallery/Styles/TextStyles.xaml" ])
