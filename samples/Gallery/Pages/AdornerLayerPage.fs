namespace Gallery.Pages

open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Interactivity

open type Fabulous.Avalonia.View
open Gallery

module AdornerLayerPage =
    type Model = { Angle: float }

    type Msg =
        | ValueChanged of float
        | AddAdorner
        | RemoveAdorner
        | DoNothing
        | Previous
    
    type CmdMsg =
        | NoMsg

    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NoMsg -> Navigation.goBack nav
        
    let init () = { Angle = 0. }, []

    let buttonRef = ViewRef<Button>()

    let update msg model =
        match msg with
        | ValueChanged value -> { model with Angle = value }, []
        | AddAdorner ->
            let adorner = AdornerLayer.GetAdorner(buttonRef.Value)
            AdornerLayer.SetAdorner(buttonRef.Value, adorner)
            model, []
        | RemoveAdorner ->
            let adorner = AdornerLayer.GetAdorner(buttonRef.Value)

            AdornerLayer.SetAdorner(adorner, null)
            model, []
        | DoNothing -> model, []
        | Previous -> model, []

    let view model =
        Dock() {
            (Grid(coldefs = [ Auto; Star ], rowdefs = [ Auto ]) {
                TextBlock("Rotation").gridColumn(0).gridRow(0)

                Slider(0., 360., model.Angle, ValueChanged).gridColumn(1).gridRow(0)
            })
                .dock(Dock.Top)

            (HStack() {
                Button("Add adorner", AddAdorner).margin(6.)

                Button("Remove adorner", RemoveAdorner).margin(6.)
            })
                .dock(Dock.Top)
                .horizontalAlignment(HorizontalAlignment.Center)

            (Grid(coldefs = [ Pixel(24.); Auto; Pixel(24.) ], rowdefs = [ Pixel(24.); Auto; Pixel(24.) ]) {
                Border().background(Brushes.Red).gridColumn(1).gridRow(0)

                Border().background(Brushes.Blue).gridColumn(0).gridRow(1)

                Border().background(Brushes.Green).gridColumn(2).gridRow(1)

                Border().background(Brushes.Yellow).gridColumn(1).gridRow(2)

                LayoutTransformControl(
                    Button("Adorner Button", DoNothing)
                        .horizontalAlignment(HorizontalAlignment.Stretch)
                        .horizontalContentAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Stretch)
                        .verticalContentAlignment(VerticalAlignment.Center)
                        .width(200.)
                        .height(42.)
                        .reference(buttonRef)
                        .adorner(
                            (Canvas() {
                                Line(Point.Parse("-100000,0"), Point.Parse("10000,0"))
                                    .stroke(Brushes.Cyan)
                                    .strokeThickness(1.)

                                Line(Point.Parse("-100000,42"), Point.Parse("10000,42"))
                                    .stroke(Brushes.Cyan)
                                    .strokeThickness(1.)

                                Line(Point.Parse("0,-100000"), Point.Parse("0,10000"))
                                    .stroke(Brushes.Cyan)
                                    .strokeThickness(1.)

                                Line(Point.Parse("200,-100000"), Point.Parse("200,10000"))
                                    .stroke(Brushes.Cyan)
                                    .strokeThickness(1.)
                            })
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .verticalAlignment(VerticalAlignment.Stretch)
                                .background(Brushes.Cyan)
                                .isHitTestVisible(false)
                                .opacity(0.3)
                                .isVisible(true)
                        )
                )
                    .gridColumn(1)
                    .gridRow(1)
                    .layoutTransform(RotateTransform(model.Angle))

            })
                .verticalAlignment(VerticalAlignment.Center)
                .horizontalAlignment(HorizontalAlignment.Center)
        }
