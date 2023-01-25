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
        | SelectionChanged args ->
            { model with
                Notification = $"Selection: %A{args.AddedItems}" }

    let view model =
        VStack(spacing = 15.) {

            TextBlock("ListBox using a collection with a WidgetDataTemplate")
                .fontWeight(FontWeight.Bold)

            ListBox(model.SampleData, (fun x -> TextBlock($"{x.Name} ({x.Species})")))
                .onSelectedIndexChanged(model.SelectedIndex, SelectedIndexChanged)

            TextBlock("ListBox using explicit ListBoxItem controls")
                .fontWeight(FontWeight.Bold)
                .margin(0, 30, 0, 0)

            ListBox() {

                ListBoxItem(TextBlock("Text with ListBoxIem and selected = true"), true)

                HStack(30.) {
                    TextBlock("Stack Item1")
                    TextBlock("Stack Item2")
                    TextBlock("Stack Item3")
                }

                TextBlock("Text with not ListBoxIem")

                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .size(32., 32.)

                Ellipse().size(50., 50.).fill(SolidColorBrush(Colors.Yellow))

                TextBlock("TextBlock")
            }

            TextBlock("ListBox with 1.000 items with recycling").fontWeight(FontWeight.Bold)

            ListBox(Seq.init 1000 id, (fun x -> TextBlock($"Row {x}")))
        }

    let sample =
        { Name = "ListBox"
          Description = "A list box control"
          Program = Helper.createProgram init update view }
