namespace Gallery

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

    type Msg = SelectedIndexChanged of int

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
          SelectedIndex = -1 }

    let update msg model =
        match msg with
        | SelectedIndexChanged index -> { model with SelectedIndex = index }

    let view model =
        VStack(spacing = 15.) {

            TextBlock("ListBox using a collection with a WidgetDataTemplate")
                .fontWeight(FontWeight.Bold)

            ListBox(model.SampleData, (fun x -> TextBlock($"{x.Name} ({x.Species})")))
                .onSelectedIndexChanged(model.SelectedIndex, SelectedIndexChanged)
        }

    let sample =
        { Name = "ListBox"
          Description = "A list box control using a collection with a WidgetDataTemplate"
          Program = Helper.createProgram init update view }
