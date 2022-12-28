namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous

type IFabFlyoutBase =
    inherit IFabElement

module FlyoutBase =

    let IsOpen = Attributes.defineAvaloniaPropertyWithEquality FlyoutBase.IsOpenProperty

    let Target = Attributes.defineAvaloniaPropertyWidget FlyoutBase.TargetProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality FlyoutBase.PlacementProperty

    let ShowMode =
        Attributes.defineAvaloniaPropertyWithEquality FlyoutBase.ShowModeProperty

    let OverlayInputPassThrough =
        Attributes.defineAvaloniaPropertyWidget FlyoutBase.OverlayInputPassThroughElementProperty

    let AttachedFlyout =
        Attributes.defineAvaloniaPropertyWidget FlyoutBase.AttachedFlyoutProperty

[<Extension>]
type FlyoutBaseModifiers =
    [<Extension>]
    static member inline isOpen(this: WidgetBuilder<'msg, #IFabFlyoutBase>, isOpen: bool) =
        this.AddScalar(FlyoutBase.IsOpen.WithValue(isOpen))

    [<Extension>]
    static member inline target(this: WidgetBuilder<'msg, #IFabFlyoutBase>, target: WidgetBuilder<'msg, IFabControl>) =
        this.AddWidget(FlyoutBase.Target.WithValue(target.Compile()))

    [<Extension>]
    static member inline placement(this: WidgetBuilder<'msg, #IFabFlyoutBase>, placement: FlyoutPlacementMode) =
        this.AddScalar(FlyoutBase.Placement.WithValue(placement))

    [<Extension>]
    static member inline showMode(this: WidgetBuilder<'msg, #IFabFlyoutBase>, showMode: FlyoutShowMode) =
        this.AddScalar(FlyoutBase.ShowMode.WithValue(showMode))

    [<Extension>]
    static member inline overlayInputPassThrough
        (
            this: WidgetBuilder<'msg, #IFabFlyoutBase>,
            overlayInputPassThrough: WidgetBuilder<'msg, IFabInputElement>
        ) =
        this.AddWidget(FlyoutBase.OverlayInputPassThrough.WithValue(overlayInputPassThrough.Compile()))

    [<Extension>]
    static member inline attachedFlyout
        (
            this: WidgetBuilder<'msg, #IFabFlyoutBase>,
            attachedFlyout: WidgetBuilder<'msg, IFabFlyoutBase>
        ) =
        this.AddWidget(FlyoutBase.AttachedFlyout.WithValue(attachedFlyout.Compile()))

    [<Extension>]
    static member inline contextFlyout
        (
            this: WidgetBuilder<'msg, #IFabControl>,
            content: WidgetBuilder<'msg, #IFabFlyoutBase>
        ) =
        this.AddWidget(Control.ContextMenu.WithValue(content.Compile()))
