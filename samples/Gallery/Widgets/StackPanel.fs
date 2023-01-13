namespace Gallery

open Avalonia.Media
open Avalonia.Layout
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module StackPanel =
    type Model =
        { Reversed: bool
          Spacing: Option<decimal> }

    type Msg =
        | Reverse of bool
        | SetSpacing of Option<decimal>

    let init () =
        { Reversed = true
          Spacing = Option<decimal>.Some (50M) }

    let update msg model =
        match msg with
        | Reverse reversed -> { model with Reversed = reversed }
        | SetSpacing spacing -> { model with Spacing = spacing }

    let view model =
        (VStack(15.) {

            HStack(10.) {
                TextBlock("Reversed:").verticalAlignment (VerticalAlignment.Center)

                ToggleSwitch(model.Reversed, Reverse)
                    .verticalAlignment (VerticalAlignment.Center)

                TextBlock("Item Spacing:")
                    .margin(100, 0, 0, 0)
                    .verticalAlignment (VerticalAlignment.Center)

                NumericUpDown(model.Spacing, SetSpacing)
                    .increment(10)
                    .formatString("0")
                    .verticalAlignment (VerticalAlignment.Center)
            }

            Separator().background(SolidColorBrush(Colors.Gray)).margin (0, 30, 0, 0)

            TextBlock("HStack:").fontWeight (FontWeight.Bold)

            let spacing: float =
                match model.Spacing with
                | Some value -> float value
                | None -> 0.

            HStack(spacing, model.Reversed) {
                TextBlock("Item 1")
                TextBlock("Item 2")
                TextBlock("Item 3")
            }

            Separator().background(SolidColorBrush(Colors.Gray)).margin (0, 30, 0, 0)

            TextBlock("VStack:").fontWeight (FontWeight.Bold)

            VStack(spacing, model.Reversed) {
                TextBlock("Item 1")
                TextBlock("Item 2")
                TextBlock("Item 3")
            }
        })

    let sample =
        { Name = "StackPanel"
          Description = "The StackPanel control is a Panel which lays out its children in the listed order."
          Program = Helper.createProgram init update view }
