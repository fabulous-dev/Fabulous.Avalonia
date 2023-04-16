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
    /// <summary>Sets the Placement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type PlacementMode =
    /// | Pointer = 0
    /// | Bottom = 1
    /// | Right = 2
    /// | Left = 3
    /// | Top = 4
    /// | Center = 5
    /// | AnchorAndGravity = 6
    /// | TopEdgeAlignedLeft = 7
    /// | TopEdgeAlignedRight = 8
    /// | BottomEdgeAlignedLeft = 9
    /// ...
    /// </code>
    /// </example>
    [<Extension>]
    static member inline placement(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: PlacementMode) =
        this.AddScalar(PopupFlyoutBase.Placement.WithValue(value))

    /// <summary>Sets the HorizontalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline horizontalOffset(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: float) =
        this.AddScalar(PopupFlyoutBase.HorizontalOffset.WithValue(value))

    /// <summary>Sets the VerticalOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline verticalOffset(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: float) =
        this.AddScalar(PopupFlyoutBase.VerticalOffset.WithValue(value))

    /// <summary>Sets the PlacementAnchor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type PopupAnchor =
    /// | None = 0
    /// | Top = 1
    /// | Bottom = 2
    /// | Left = 4
    /// | Right = 8
    /// | TopLeft = 5
    /// | TopRight = 9
    /// | BottomLeft = 6
    /// | BottomRight = 10
    /// | VerticalMask = 3
    /// ...
    /// </code>
    /// </example>
    [<Extension>]
    static member inline placementAnchor(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: PopupAnchor) =
        this.AddScalar(PopupFlyoutBase.PlacementAnchor.WithValue(value))

    /// <summary>Sets the PlacementGravity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type PopupGravity =
    /// | None = 0
    /// | Top = 1
    /// | Bottom = 2
    /// | Left = 4
    /// | Right = 8
    /// | TopLeft = 5
    /// | TopRight = 9
    /// | BottomLeft = 6
    /// | BottomRight = 10
    /// ...
    /// </code>
    /// </example>
    [<Extension>]
    static member inline placementGravity(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: PopupGravity) =
        this.AddScalar(PopupFlyoutBase.PlacementGravity.WithValue(value))

    /// <summary>Sets the ShowMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type FlyoutShowMode =
    /// | Standard = 0
    /// | Transient = 1
    /// | TransientWithDismissOnPointerMoveAway = 2
    /// </code>
    /// </example>
    [<Extension>]
    static member inline showMode(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: FlyoutShowMode) =
        this.AddScalar(PopupFlyoutBase.ShowMode.WithValue(value))

    /// <summary>Sets the OverlayInputPassThroughElement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline overlayInputPassThroughElement(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, value: IInputElement) =
        this.AddScalar(PopupFlyoutBase.OverlayInputPassThroughElement.WithValue(value))

    /// <summary>Listens to the Opening event.</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">The message to send when the event is raised.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, onOpening: 'msg) =
        this.AddScalar(PopupFlyoutBase.Opening.WithValue(onOpening))

    /// <summary>Listens to the Closing event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to call when the event is raised.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabFlyoutBase>, fn: CancelEventArgs -> 'msg) =
        this.AddScalar(PopupFlyoutBase.Closing.WithValue(fun args -> fn args |> box))
