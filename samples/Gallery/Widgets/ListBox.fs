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
          SelectedIndex: int
          Notification: string }

    type Msg =
        | SelectedIndexChanged of int
        | SelectionChanged of SelectionChangedEventArgs

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
          SelectedIndex = -1
          Notification = "" }

    let update msg model =
        match msg with
        | SelectedIndexChanged index ->
            { model with
                SelectedIndex = index
                Notification = $"Family: {model.SampleData[index].Family}" }
        | SelectionChanged args -> { model with Notification = $"Selection: %A{args.AddedItems}" }

    let view model =
        VStack(spacing = 15.) {

            TextBlock("ListBox using a collection with a string template")
                .fontWeight (FontWeight.Bold)

            ListBox(model.SampleData, (fun x -> $"{x.Name} ({x.Species})"))
                .onSelectedIndexChanged (model.SelectedIndex, SelectedIndexChanged)

            TextBlock(model.Notification)

            //TextBlock("ListBox using a ListBoxItem template [INCOMPLETE]")
            //  .fontWeight(FontWeight.Bold)
            //  .margin (0,30,0,0)

            //ListBox(model.SampleData, (fun x -> ListBoxItem(TextBlock(x.Name))))
            //  .onSelectionChanged (SelectionChanged)

            TextBlock("ListBox using explict ListBoxItem controls")
                .fontWeight(FontWeight.Bold)
                .margin (0, 30, 0, 0)

            (ListBox() {
                ListBoxItem(
                    HStack(30.) {
                        TextBlock("Stack Item1")
                        TextBlock("Stack Item2")
                        TextBlock("Stack Item3")
                    }
                )

                ListBoxItem(Ellipse().size(50., 50.).fill (SolidColorBrush(Colors.Yellow)))

                ListBoxItem(TextBlock("TextBlock"))
            })
                .selectedIndex (0)
        }

    let sample =
        { Name = "ListBox"
          Description = "A list box control"
          Program = Helper.createProgram init update view }
