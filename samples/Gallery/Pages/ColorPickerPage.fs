namespace Gallery

open System.Drawing
open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ColorPickerPage =

    type Model =
        { ColorView: Color
          ColorPicker: Color
          ColorSpectrum: Color
          ColorSlider1: Color
          ColorPreviewer: Color }

    type Msg =
        | ColorViewChanged of Color
        | ColorPickerChanged of Color
        | ColorSpectrumChanged of Color
        | ColorSlider1Changed of Color
        | ColorPreviewerChanged of ColorChangedEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { ColorView = Colors.Green
          ColorPicker = Colors.Yellow
          ColorSpectrum = Colors.Blue
          ColorSlider1 = Colors.Red
          ColorPreviewer = Colors.Teal },
        []

    let update msg model =
        match msg with
        | ColorViewChanged args -> { model with ColorView = args }, []
        | ColorPickerChanged args -> { model with ColorPicker = args }, []
        | ColorSpectrumChanged args -> { model with ColorSpectrum = args }, []
        | ColorSlider1Changed args -> { model with ColorSlider1 = args }, []
        | ColorPreviewerChanged args ->
            { model with
                ColorPreviewer = args.NewColor },
            []

    let view model =
        Grid(coldefs = [ Auto; Pixel(10.); Auto ], rowdefs = [ Auto; Auto ]) {
            ColorView(model.ColorView, ColorViewChanged)
                .gridRow(0)
                .gridColumn(0)
                .colorSpectrumShape(ColorSpectrumShape.Ring)

            ColorPicker(model.ColorPicker, ColorPickerChanged)
                .gridRow(1)
                .gridColumn(0)
                .hsvColor(HsvColor.Parse("hsv(120, 1, 1)"))
                .margin(0., 50., 0., 0.)
                .palette(FlatHalfColorPalette())

            (Grid(rowdefs = [ Auto; Auto; Auto; Auto; Auto; Auto; Auto; Auto; Auto ], coldefs = [ Auto ]) {
                ColorSpectrum(model.ColorSpectrum, ColorSpectrumChanged)
                    .gridRow(0)
                    .cornerRadius(10.)
                    .height(256.)
                    .width(256.)

                ColorSlider()
                    .gridRow(1)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Component1)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(model.ColorSpectrum.ToHsv())

                ColorSlider()
                    .gridRow(2)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Component2)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(model.ColorSpectrum.ToHsv())

                ColorSlider()
                    .gridRow(3)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Component3)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(model.ColorSpectrum.ToHsv())

                ColorSlider()
                    .gridRow(4)
                    .margin(0., 10., 0., 0.)
                    .colorComponent(ColorComponent.Alpha)
                    .colorModel(ColorModel.Hsva)
                    .hsvColor(model.ColorSpectrum.ToHsv())

                ColorPreviewer(ColorPreviewerChanged)
                    .gridRow(8)
                    .isAccentColorsVisible(false)
                    .hsvColor(model.ColorSpectrum.ToHsv())
                    .margin(0., 2., 0., 0.)
            })
                .gridRow(0)
                .gridColumn(2)

        }
