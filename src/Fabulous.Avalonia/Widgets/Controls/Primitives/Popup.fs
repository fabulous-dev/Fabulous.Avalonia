namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.FSharp.Linq

type IFabPopup =
    inherit IFabControl

module Popup =
    let WidgetKey = Widgets.register<Popup>()

    let WindowManagerAddShadowHint =
        Attributes.defineAvaloniaPropertyWithEquality Popup.WindowManagerAddShadowHintProperty

    let Child = Attributes.defineAvaloniaPropertyWidget Popup.ChildProperty

    let InheritsTransform =
        Attributes.defineAvaloniaPropertyWithEquality Popup.InheritsTransformProperty

    let IsOpen = Attributes.defineAvaloniaPropertyWithEquality Popup.IsOpenProperty

    let PlacementAnchor =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementAnchorProperty

    let PlacementConstraintAdjustment =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementConstraintAdjustmentProperty

    let PlacementGravity =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementGravityProperty

    let PlacementMode =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementModeProperty

    let PlacementRect =
        Attributes.defineAvaloniaPropertyWithEquality Popup.PlacementRectProperty

    let OverlayDismissEventPassThrough =
        Attributes.defineAvaloniaPropertyWithEquality Popup.OverlayDismissEventPassThroughProperty

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality Popup.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality Popup.VerticalOffsetProperty

    let IsLightDismissEnabled =
        Attributes.defineAvaloniaPropertyWithEquality Popup.IsLightDismissEnabledProperty

    let Topmost = Attributes.defineAvaloniaPropertyWithEquality Popup.TopmostProperty

[<AutoOpen>]
module PopupBuilders =
    type Fabulous.Avalonia.View with

        static member inline Popup(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabPopup>(
                Popup.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Popup.Child.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type PopupModifiers =
    [<Extension>]
    static member inline windowManagerAddShadowHint(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.WindowManagerAddShadowHint.WithValue(value))

    [<Extension>]
    //InheritsTransform
    static member inline inheritsTransform(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.InheritsTransform.WithValue(value))

    [<Extension>]
    static member inline isOpen(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.IsOpen.WithValue(value))

    [<Extension>]
    static member inline placementAnchor(this: WidgetBuilder<'msg, #IFabPopup>, value: PopupAnchor) =
        this.AddScalar(Popup.PlacementAnchor.WithValue(value))

    [<Extension>]
    static member inline placementConstraintAdjustment
        (
            this: WidgetBuilder<'msg, #IFabPopup>,
            value: PopupPositionerConstraintAdjustment
        ) =
        this.AddScalar(Popup.PlacementConstraintAdjustment.WithValue(value))

    [<Extension>]
    static member inline placementGravity(this: WidgetBuilder<'msg, #IFabPopup>, value: PopupGravity) =
        this.AddScalar(Popup.PlacementGravity.WithValue(value))

    [<Extension>]
    static member inline placementMode(this: WidgetBuilder<'msg, #IFabPopup>, value: PlacementMode) =
        this.AddScalar(Popup.PlacementMode.WithValue(value))

    [<Extension>]
    static member inline placementRect(this: WidgetBuilder<'msg, #IFabPopup>, value: Rect) =
        this.AddScalar(Popup.PlacementRect.WithValue(Nullable.op_Implicit value))

    [<Extension>]
    static member inline overlayDismissEventPassThrough(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.OverlayDismissEventPassThrough.WithValue(value))

    [<Extension>]
    static member inline horizontalOffset(this: WidgetBuilder<'msg, #IFabPopup>, value: double) =
        this.AddScalar(Popup.HorizontalOffset.WithValue(value))

    [<Extension>]
    static member inline verticalOffset(this: WidgetBuilder<'msg, #IFabPopup>, value: double) =
        this.AddScalar(Popup.VerticalOffset.WithValue(value))

    [<Extension>]
    static member inline isLightDismissEnabled(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.IsLightDismissEnabled.WithValue(value))

    [<Extension>]
    static member inline topmost(this: WidgetBuilder<'msg, #IFabPopup>, value: bool) =
        this.AddScalar(Popup.Topmost.WithValue(value))
