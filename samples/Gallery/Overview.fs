namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module OverViewPage =
    type Model = { Text: string }

    type Msg = | ShowText

    let init () : Model = { Text = "" }

    let update msg model =
        match msg with
        | ShowText -> model, Cmd.none

    let view model =
        (VStack(16.) {
            TextBlock("Fabulous Gallery")
                .centerHorizontal()
                .fontSize(30.)
                .fontWeight(FontWeight.Bold)
                .margin(Thickness(0., 20., 0., 0.))

            TextBlock("A collection of work in progress code samples to help speed up your multi-platform development.")
            TextBlock("Available on:")
            TextBlock("iOS").centerHorizontal()
            TextBlock("Android").centerHorizontal()
            TextBlock("Windows").centerHorizontal()
            TextBlock("macOS").centerHorizontal()
        })
            .margin(Thickness(32.))
