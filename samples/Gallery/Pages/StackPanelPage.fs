namespace Gallery.Pages

open Avalonia.Media
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module StackPanelPage =
    type Model =
        { Reversed: bool
          Spacing: float option }

    type Msg =
        | Reverse of bool
        | SetSpacing of float option

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Reversed = true; Spacing = Some(50.) }, []

    let update msg model =
        match msg with
        | Reverse reversed -> { model with Reversed = reversed }
        | SetSpacing spacing -> { model with Spacing = spacing }

    let view model =
        (VStack(15.) {
            HStack(10.) {
                TextBlock("Reversed:").verticalAlignment(VerticalAlignment.Center)

                ToggleSwitch(model.Reversed, Reverse)
                    .verticalAlignment(VerticalAlignment.Center)

                TextBlock("Item Spacing:")
                    .margin(100, 0, 0, 0)
                    .verticalAlignment(VerticalAlignment.Center)

                NumericUpDown(model.Spacing, SetSpacing)
                    .increment(10)
                    .formatString("0")
                    .verticalAlignment(VerticalAlignment.Center)
            }

            Separator().background(SolidColorBrush(Colors.Gray)).margin(0, 30, 0, 0)

            TextBlock("HStack:").fontWeight(FontWeight.Bold)

            let spacing: float =
                match model.Spacing with
                | Some value -> float value
                | None -> 0.

            HStack(spacing, model.Reversed) {
                TextBlock("Item 1")
                TextBlock("Item 2")
                TextBlock("Item 3")
            }

            Separator().background(SolidColorBrush(Colors.Gray)).margin(0, 30, 0, 0)

            TextBlock("VStack:").fontWeight(FontWeight.Bold)

            VStack(spacing, model.Reversed) {
                TextBlock("Item 1")
                TextBlock("Item 2")
                TextBlock("Item 3")
            }
        })
