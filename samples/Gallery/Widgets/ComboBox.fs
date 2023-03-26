namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ComboBox =
    type Model = { IsDropDownOpen: bool }

    type Msg = DropDownOpened of bool

    let init () = { IsDropDownOpen = false }

    let update msg model =
        match msg with
        | DropDownOpened isOpen -> { model with IsDropDownOpen = isOpen }

    let fontComboBox () =
        FontManager.Current.SystemFonts |> Seq.map(fun x -> FontFamily(x.Name))

    let view model =
        HStack(16) {
            (ComboBox() {
                ComboBoxItem("Inline Items")
                ComboBoxItem("Inline Item 2", true)
                ComboBoxItem("Inline Item 3")
                ComboBoxItem("Inline Item 4")
            })
                .selectedIndex(0)

            (ComboBox() {
                ComboBoxItem(
                    VStack() {
                        Rectangle().height(10.).fill(SolidColorBrush(Colors.Red))
                        TextBlock("Control Items").margin(8.)
                    }
                )

                ComboBoxItem(Ellipse().size(50., 50.).fill(SolidColorBrush(Colors.Yellow)))

                ComboBoxItem(TextBlock("TextBox"))
            })
                .selectedIndex(0)

            (ComboBox(model.IsDropDownOpen, DropDownOpened) {
                for item in fontComboBox() do
                    ComboBoxItem(item.Name)
            })
                .selectedIndex(0)
        }

    let sample =
        { Name = "ComboBox"
          Description = "Control that allows the user to select a value from a list"
          Program = Helper.createProgram init update view }
