namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ColorPickerPage =

    type Model = { Nothing: string }

    type Msg = DropDownOpened of bool

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let fontComboBox () =
        FontManager.Current.SystemFonts |> Seq.map(fun x -> FontFamily(x.Name))

    let init () = { Nothing = "" }, []

    let update msg model =
        match msg with
        | DropDownOpened isOpen -> model, []

    let view _ =
        Grid(coldefs = [ Auto; Pixel(10.); Auto ], rowdefs = [ Auto; Auto ]) {
            ColorView()
                .gridRow(0)
                .gridColumn(0)
                .colorSpectrumShape(ColorSpectrumShape.Ring)

            ColorPicker()
                .gridRow(1)
                .gridColumn(0)
                .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))
                .margin(0., 50., 0., 0.)
                .palette(FlatHalfColorPalette())

            (Grid(coldefs = [ Auto; Auto; Auto; Auto; Auto; Auto; Auto; Auto; Auto ], rowdefs = [ Auto ]) {
                // <ColorSpectrum x:Name="ColorSpectrum1"
                //      Grid.Row="0"
                //      Color="Red"
                //      CornerRadius="10"
                //      Height="256"
                //      Width="256" />
                ()
            })
                .gridRow(0)
                .gridColumn(2)

        }
