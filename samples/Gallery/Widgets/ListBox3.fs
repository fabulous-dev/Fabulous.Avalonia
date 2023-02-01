namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ListBox3 =

    type Model = { SelectedIndex: int }

    type Msg = SelectedIndexChanged of int

    let init () = { SelectedIndex = -1 }

    let update msg model =
        match msg with
        | SelectedIndexChanged index -> { model with SelectedIndex = index }

    let view model =
        VStack(spacing = 15.) {
            TextBlock("ListBox with 1.000 items with recycling").fontWeight(FontWeight.Bold)

            ListBox(Seq.init 1000 id, (fun x -> TextBlock($"Row {x}")))
                .onSelectedIndexChanged(model.SelectedIndex, SelectedIndexChanged)
        }

    let sample =
        { Name = "ListBox"
          Description = "A list box control with 1.000 items with recycling"
          Program = Helper.createProgram init update view }
