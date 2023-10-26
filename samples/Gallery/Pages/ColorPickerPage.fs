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

            (Grid(rowdefs = [ Auto; Auto; Auto; Auto; Auto; Auto; Auto; Auto; Auto ], coldefs = [ Auto ]) {
                ColorSpectrum()
                    .gridRow(0)
                    .color(Colors.Red)
                    .cornerRadius(10.)
                    .height(256.)
                    .width(256.)

                //HSV Sliders
                ColorSlider()
                    .gridRow(1)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Component1)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))

                ColorSlider()
                    .gridRow(2)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Component2)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))


                ColorSlider()
                    .gridRow(3)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Component3)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))

                ColorSlider()
                    .gridRow(4)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Alpha)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))

                ColorPreviewer()
                    .gridRow(8)
                    .isAccentColorsVisible(false)
                    .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))
                    .margin(0., 2., 0., 0.)
            })
                .gridRow(0)
                .gridColumn(2)

        }
