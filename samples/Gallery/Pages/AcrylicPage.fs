namespace Gallery.Pages

open Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Gallery

module AcrylicPage =
    type Model =
        { TintOpacitySlider: float
          BorderWidth: float
          MaterialOpacitySlider: float }

    type Msg =
        | TintOpacitySliderValueChanged of float
        | MaterialOpacitySliderValueChanged of float
        | Previous

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { TintOpacitySlider = 0.9
          BorderWidth = 160.
          MaterialOpacitySlider = 0.8 },
        []

    let bordersGridRef = ViewRef<UniformGrid>()

    let update msg model =
        match msg with
        | TintOpacitySliderValueChanged value ->
            let borderWidth =
                match bordersGridRef.TryValue with
                | Some ref -> ref.Bounds.Width
                | _ -> 160.

            { model with
                TintOpacitySlider = value
                BorderWidth = borderWidth },
            []
        | MaterialOpacitySliderValueChanged value ->
            let borderWidth =
                match bordersGridRef.TryValue with
                | Some ref -> ref.Bounds.Width
                | _ -> 160.

            { model with
                MaterialOpacitySlider = value
                BorderWidth = borderWidth },
            []

        | Previous -> model, []

    let acrylicBorderStyle1 (this: WidgetBuilder<'msg, IFabExperimentalAcrylicBorder>) =
        this.height(100.).margin(10.).maxWidth(200.)

    let acrylicBorderStyle (this: WidgetBuilder<'msg, IFabExperimentalAcrylicBorder>) =
        this.cornerRadius(CornerRadius(5.)).maxWidth(660.)

    let textBlockStyle (this: WidgetBuilder<'msg, IFabTextBlock>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .foreground(SolidColorBrush(Colors.Black))

    let sliderStyle (this: WidgetBuilder<'msg, IFabSlider>) =
        this.margin(8., 0.).largeChange(0.2).smallChange(0.1)

    let view model =
        VStack(spacing = 20.) {
            ExperimentalAcrylicBorder(
                (Grid(coldefs = [ Auto; Star; Auto ], rowdefs = [ Auto; Auto ]) {
                    TextBlock("TintOpacity")
                        .gridRow(0)
                        .gridColumn(0)
                        .style(textBlockStyle)

                    Slider(0., 1., model.TintOpacitySlider, TintOpacitySliderValueChanged)
                        .gridRow(0)
                        .gridColumn(1)
                        .style(sliderStyle)

                    TextBlock($"{model.TintOpacitySlider}")
                        .gridRow(0)
                        .gridColumn(2)
                        .style(textBlockStyle)

                    TextBlock("MaterialOpacity")
                        .gridRow(1)
                        .gridColumn(0)
                        .style(textBlockStyle)

                    Slider(0., 1., model.MaterialOpacitySlider, MaterialOpacitySliderValueChanged)
                        .gridRow(1)
                        .gridColumn(1)
                        .style(sliderStyle)

                    TextBlock($"{model.MaterialOpacitySlider}")
                        .gridRow(1)
                        .gridColumn(2)
                        .style(textBlockStyle)

                })
                    .margin(20., 10.)
            )
                .material(
                    ExperimentalAcrylicMaterial()
                        .backgroundSource(AcrylicBackgroundSource.Digger)
                        .tintColor(Colors.White)
                )
                .style(acrylicBorderStyle)

            (UniformGrid() {
                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#FF0000"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)

                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#00FF00"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)

                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Colors.White)
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)

                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#3c3c3c"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)


                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Colors.White)
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)

                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#000000"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)

                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#FFFF00"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)


                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#0000FF"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)

                ExperimentalAcrylicBorder()
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Color.Parse("#0000FF"))
                            .tintOpacity(model.TintOpacitySlider)
                            .materialOpacity(model.MaterialOpacitySlider)
                    )
                    .style(acrylicBorderStyle1)
            })
                .reference(bordersGridRef)

            ExperimentalAcrylicBorder()
                .material(
                    ExperimentalAcrylicMaterial()
                        .backgroundSource(AcrylicBackgroundSource.Digger)
                        .tintColor(Color.Parse("#0000FF"))
                        .tintOpacity(model.TintOpacitySlider)
                        .materialOpacity(model.MaterialOpacitySlider)
                )
                .width(model.BorderWidth)
                .height(160.)

        }
