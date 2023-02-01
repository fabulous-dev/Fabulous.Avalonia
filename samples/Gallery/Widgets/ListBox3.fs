namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ListBox3 =

    type Model = { SelectedIndex: int }

    type Msg = SelectedChanged of SelectionChangedEventArgs

    let init () = { SelectedIndex = -1 }

    let update msg model =
        match msg with
        | SelectedChanged args ->
            let control = args.Source :?> ListBox

            { model with
                SelectedIndex = control.SelectedIndex }

    let view model =
        VStack(spacing = 15.) {
            TextBlock("ListBox with 1.000 items with recycling").fontWeight(FontWeight.Bold)

            ListBox(Seq.init 1000 id, (fun x -> TextBlock($"Row {x}")))
                .onSelectionChanged(SelectedChanged)
        }

    let sample =
        { Name = "ListBox"
          Description = "A list box control with 1.000 items with recycling"
          Program = Helper.createProgram init update view }
