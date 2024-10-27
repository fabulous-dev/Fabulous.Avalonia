namespace Gallery

open System.Diagnostics
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View

module ComboBoxPage =

    type Model =
        { Items: string list
          Fonts: FontFamily seq
          IsDropDownOpen: bool }

    type Msg = DropDownOpened of bool

    let fontComboBox () =
        FontManager.Current.SystemFonts |> Seq.map(fun x -> FontFamily(x.Name))

    let init () =
        { IsDropDownOpen = false
          Items = [ "Inline Items 1"; "Inline Item 2"; "Inline Item 3"; "Inline Item 4" ]
          Fonts = fontComboBox() },
        Cmd.none

    let update msg model =
        match msg with
        | DropDownOpened isOpen -> { model with IsDropDownOpen = isOpen }, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("", program) {
            let! model = Mvu.State

            HStack(16) {
                ComboBox(model.Items).selectedIndex(0)

                ComboBox(
                    model.Items,
                    fun item ->
                        if item = "Inline Items 1" then
                            TextBlock(item).foreground(Colors.Red)
                        else
                            TextBlock(item)
                )

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
        }
