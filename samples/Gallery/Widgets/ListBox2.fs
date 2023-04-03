namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ListBox2 =

    type Model = {
        Items: int list
        SelectedIndex: int
    }

    type Msg = SelectedIndexChanged of int

    let init () =
        { Items = [ 1..1000 ]
          SelectedIndex = 0 }

    let update msg model =
        match msg with
        | SelectedIndexChanged index ->
            { model with SelectedIndex = index }

    let view model =
        VStack(spacing = 15.) {
            TextBlock("ListBox with 1.000 items with recycling").fontWeight(FontWeight.Bold)

            ListBox(model.Items, (fun x -> TextBlock($"Row {x}")))
                .onSelectedIndexChanged(model.SelectedIndex, SelectedIndexChanged)
        }

    let sample =
        { Name = "ListBox2"
          Description = "A list box control with 1.000 items with recycling"
          Program = Helper.createProgram init update view }
