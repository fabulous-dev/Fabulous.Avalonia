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
        })

    let sample =
        { Name = "Styles"
          Description = "Styles are applied to the view"
          Program = Helper.createProgram init update view }
