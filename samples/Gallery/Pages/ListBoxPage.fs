namespace Gallery.Pages

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ListBoxPage =

    type DataType =
        { Name: string
          Species: string
          Family: string }

    type Model =
        { SampleData: DataType list
          Items: int list }

    type Msg =
        | SelectionChanged1 of SelectionChangedEventArgs
        | SelectionChanged2 of SelectionChangedEventArgs

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
          Items = [ 1..1000 ] }

    let update (msg: Msg) model =
        match msg with
        | SelectionChanged1 _ -> model
        | SelectionChanged2 _ -> model

    let view model =
        VStack(spacing = 15.) {

            TextBlock("ListBox using a collection with a WidgetDataTemplate")
                .fontWeight(FontWeight.Bold)

            ListBox(model.SampleData, (fun x -> TextBlock($"{x.Name} ({x.Species})")))
                .onSelectionChanged(SelectionChanged1)
                .selectedIndex(1)

            VStack(spacing = 15.) {
                TextBlock("ListBox with 1.000 items with recycling").fontWeight(FontWeight.Bold)

                ListBox(model.Items, (fun x -> TextBlock($"Row {x}")))
                    .onSelectionChanged(SelectionChanged2)
            }
        }
