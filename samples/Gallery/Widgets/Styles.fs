namespace Gallery

open Avalonia.Controls
open Avalonia.Styling
open Fabulous.Avalonia
open Avalonia.Media

open type Fabulous.Avalonia.View

module Styles =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
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

    let sample =
        { Name = "Styles"
          Description = "Styles are applied to the view"
          Program = Helper.createProgram init update view }
