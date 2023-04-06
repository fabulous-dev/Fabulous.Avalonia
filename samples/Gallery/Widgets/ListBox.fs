namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ListBox =

    type DataType =
        { Name: string
          Species: string
          Family: string }

    type Model =
        { SampleData: DataType list
          SelectedIndex: int }

    type Msg = SelectionChanged of SelectionChangedEventArgs

    let init () =
        { SampleData =
            [ { Name = "Dog"
                Species = "Canis familiaris"
                Family = "Canidae" }
              { Name = "Cat"
                Species = "Felis catus"
                Family = "Felidae" }
              { Name = "Mouse"
                Species = "Mus musculus"
                Family = "Muridae" } ]
          SelectedIndex = 0 }

    let update (msg: Msg) model =
        match msg with
        | SelectionChanged args ->
            let control = args.Source :?> ListBox

            { model with
                SelectedIndex = control.SelectedIndex }

    let view model =
        VStack(spacing = 15.) {

            TextBlock("ListBox using a collection with a WidgetDataTemplate")
                .fontWeight(FontWeight.Bold)

            ListBox(model.SampleData, (fun x -> TextBlock($"{x.Name} ({x.Species})")))
                .onSelectionChanged(SelectionChanged)
                .selectedIndex(1)
        }

    let sample =
        { Name = "ListBox"
          Description = "A list box control using a collection with a WidgetDataTemplate"
          Program = Helper.createProgram init update view }
