namespace Gallery.Pages

open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ComboBoxPage =

    type Model =
        { Items: string list
          Fonts: FontFamily seq
          IsDropDownOpen: bool }

    type Msg = DropDownOpened of bool

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let fontComboBox () =
        FontManager.Current.SystemFonts |> Seq.map(fun x -> FontFamily(x.Name))

    let init () =
        { IsDropDownOpen = false
          Items = [ "Inline Items"; "Inline Item 2"; "Inline Item 3"; "Inline Item 4" ]
          Fonts = fontComboBox() },
        []

    let update msg model =
        match msg with
        | DropDownOpened isOpen -> { model with IsDropDownOpen = isOpen }, []

    let view model =
        HStack(16) {
            ComboBox(model.Items, (fun x -> TextBlock(x)))
                .selectedIndex(0)

            (ComboBox() {
                ComboBoxItem(Rectangle().size(10., 50.).fill(SolidColorBrush(Colors.Red)))

                ComboBoxItem(
                    Ellipse()
                        .size(50., 50.)
                        .fill(SolidColorBrush(Colors.Yellow))
                )

                ComboBoxItem(TextBlock("Unknown"))
            })
                .selectedIndex(0)

            (ComboBox() {
                ComboBoxItem("Select a font", true)

                for font in model.Fonts do
                    ComboBoxItem(font.Name)
            })
                .onDropDownOpened(model.IsDropDownOpen, DropDownOpened)

            VStack() {
                LayoutTransformControl(
                    Grid() {
                        (ComboBox() {
                            ComboBoxItem("Inline Items")
                            ComboBoxItem("Inline Item 2")
                            ComboBoxItem("Inline Item 3")
                            ComboBoxItem("Inline Item 4")
                            ComboBoxItem("Inline Item 5")
                        })
                            .selectedIndex(0)
                    }
                )
                    .layoutTransform(RotateTransform(45.))
            }
        }
