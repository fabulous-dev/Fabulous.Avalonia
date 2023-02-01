namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ListBox2 =

    type Model =
        { SelectedIndex: int
          Notification: string }

    type Msg = SelectedChanged of SelectionChangedEventArgs

    let init () =
        { SelectedIndex = -1
          Notification = "" }

    let update msg model =
        match msg with
        | SelectedChanged args ->
            let control = args.Source :?> ListBox

            { model with
                SelectedIndex = control.SelectedIndex }

    let view model =
        VStack(spacing = 15.) {
            TextBlock("ListBox using explicit ListBoxItem controls")
                .fontWeight(FontWeight.Bold)
                .margin(0, 30, 0, 0)

            (ListBox() {
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
            })
                .onSelectionChanged(SelectedChanged)
        }

    let sample =
        { Name = "ListBox"
          Description = "A list box control using explicit ListBoxItem controls"
          Program = Helper.createProgram init update view }
