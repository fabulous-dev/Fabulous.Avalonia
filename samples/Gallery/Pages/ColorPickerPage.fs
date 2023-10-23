namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ColorPickerPage =

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

    let view _ =
        HStack(16) {
            ColorPicker()
        }
