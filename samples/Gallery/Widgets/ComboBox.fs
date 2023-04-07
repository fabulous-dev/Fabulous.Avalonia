namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ComboBox =

    type Figure =
        | Rectangles
        | Ellipses
        | Unknown

    type Model =
        { Items: string list
          Fonts: FontFamily seq
          Figures: Figure list
          IsDropDownOpen: bool }

    type Msg = DropDownOpened of bool

    let fontComboBox () =
        FontManager.Current.SystemFonts |> Seq.map(fun x -> FontFamily(x.Name))

    let init () =
        { IsDropDownOpen = false
          Items = [ "Inline Items"; "Inline Item 2"; "Inline Item 3"; "Inline Item 4" ]
          Figures = [ Rectangles; Ellipses; Unknown ]
          Fonts = fontComboBox() }

    let update msg model =
        match msg with
        | DropDownOpened isOpen -> { model with IsDropDownOpen = isOpen }

    let view model =
        HStack(16) {
            ComboBox(model.Items, (fun x -> TextBlock(x))).selectedIndex(0)

            (ComboBox(
                model.Figures,
                fun x ->
                    match x with
                    | Rectangles -> VStack() { Rectangle().height(10.).fill(SolidColorBrush(Colors.Red)) }
                    | Ellipses -> VStack() { Ellipse().size(50., 50.).fill(SolidColorBrush(Colors.Yellow)) }
                    | Unknown -> VStack() { TextBlock("Unknown") }
            ))
                .selectedIndex(0)

            ComboBox(model.Fonts, (fun x -> TextBlock(x.Name)))
                .selectedIndex(0)
                .onDropDownOpened(model.IsDropDownOpen, DropDownOpened)
        }

    let sample =
        { Name = "ComboBox"
          Description = "Control that allows the user to select a value from a list"
          Program = Helper.createProgram init update view }
