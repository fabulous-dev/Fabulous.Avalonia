namespace Fabulous.Avalonia

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Input
open Fabulous

type IFabPopupFlyoutBase =
    inherit IFabFlyoutBase

module PopupFlyoutBase =
    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.PlacementProperty

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.VerticalOffsetProperty

    let PlacementAnchor =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.PlacementAnchorProperty

    let PlacementGravity =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.PlacementGravityProperty

    let ShowMode =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.ShowModeProperty

    let OverlayInputPassThroughElement =
        Attributes.defineAvaloniaPropertyWithEquality PopupFlyoutBase.OverlayInputPassThroughElementProperty

    let Opening =
        Attributes.defineEventNoArg "PopupFlyoutBase_Opening" (fun target -> (target :?> PopupFlyoutBase).Opening)

    let Closing =
        Attributes.defineEvent "PopupFlyoutBase_Closing" (fun target -> (target :?> PopupFlyoutBase).Closing)

[<Extension>]
type PopupFlyoutBaseModifiers =
    [<Extension>]
    static member inline placement(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, placement: PlacementMode) =
        this.AddScalar(PopupFlyoutBase.Placement.WithValue(placement))

    [<Extension>]
    static member inline horizontalOffset(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, offset: double) =
        this.AddScalar(PopupFlyoutBase.HorizontalOffset.WithValue(offset))

    [<Extension>]
    static member inline verticalOffset(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, offset: double) =
        this.AddScalar(PopupFlyoutBase.VerticalOffset.WithValue(offset))

    [<Extension>]
    static member inline placementAnchor(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, anchor: PopupAnchor) =
        this.AddScalar(PopupFlyoutBase.PlacementAnchor.WithValue(anchor))

    [<Extension>]
    static member inline placementGravity(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, gravity: PopupGravity) =
        this.AddScalar(PopupFlyoutBase.PlacementGravity.WithValue(gravity))

    [<Extension>]
    static member inline showMode(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, mode: FlyoutShowMode) =
        this.AddScalar(PopupFlyoutBase.ShowMode.WithValue(mode))

    [<Extension>]
    static member inline overlayInputPassThroughElement(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: IInputElement) =
        this.AddScalar(PopupFlyoutBase.OverlayInputPassThroughElement.WithValue(value))

    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, onOpening: 'msg) =
        this.AddScalar(PopupFlyoutBase.Opening.WithValue(onOpening))

    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, onClosing: CancelEventArgs -> 'msg) =
        this.AddScalar(PopupFlyoutBase.Closing.WithValue(fun args -> onClosing args |> box))
