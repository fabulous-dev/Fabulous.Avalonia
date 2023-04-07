namespace Gallery

open Avalonia.Layout
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

// TODO https://github.com/AvaloniaUI/Avalonia/blob/6ad2f2a2f4a5ab183f5f125de9df197281eb9720/samples/ControlCatalog/Pages/NumericUpDownPage.xaml

module NumericUpDown =
    type Model = { Number: decimal option }

    type Msg = Increment of decimal option

    let init () = { Number = Some(1M) }

    let update msg model =
        match msg with
        | Increment args -> { model with Number = args }

    let view model =
        VStack(spacing = 15.) {
            NumericUpDown(model.Number, Increment)
                .increment(10)
                .formatString("0")
                .verticalAlignment(VerticalAlignment.Center)
        }

    let sample =
        { Name = "NumericUpDown"
          Description =
            "The NumericUpDown is an editable numeric input field. The control has a up and down button spinner attached, used to increment and decrement the value in the input field. The value can also be incremented or decremented using the arrow keys or the mouse wheel when the control is selected."
          Program = Helper.createProgram init update view }
