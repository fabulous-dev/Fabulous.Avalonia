namespace Gallery.Pages

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Gallery

module PopupPage =
    type Model = { IsOpen: bool }

    type Msg =
        | OpenPopup
        | OnOpened
        | OnClosed

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NoMsg -> Navigation.goBack nav

    let init () = { IsOpen = false }

    let update msg model =
        match msg with
        | OpenPopup -> { model with IsOpen = not model.IsOpen }
        | OnOpened -> model
        | OnClosed -> model

    let buttonRef = ViewRef<Button>()

    let view model =
        (VStack(spacing = 15.) {
            Button("Click me", OpenPopup)

            Popup(
                model.IsOpen,
                (Grid(coldefs = [ Pixel(300) ], rowdefs = [ Auto; Pixel(200.) ]) {
                    Ellipse().size(100., 100.).fill(SolidColorBrush(Colors.Green))

                    TextBlock("This is a popup content")
                        .centerHorizontal()
                        .centerVertical()
                        .gridRow(1)
                })
                    .background(SolidColorBrush(Colors.LightGray))
            )
                .onOpened(OnOpened)
                .onClosed(OnClosed)
                .placement(PlacementMode.Bottom)
                .placementGravity(PopupGravity.Bottom)
                .placementAnchor(PopupAnchor.Bottom)
                .placementConstraintAdjustment(PopupPositionerConstraintAdjustment.FlipY)
                .placementRect(Rect(0., 0., 100., 100.))
        })
            .center()
