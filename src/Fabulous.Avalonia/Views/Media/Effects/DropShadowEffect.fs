namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabDropShadowEffect =
    inherit IFabDropShadowEffectBase

module DropShadowEffect =
    let WidgetKey = Widgets.register<DropShadowEffect>()

    let OffsetX =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffect.OffsetXProperty

    let OffsetY =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffect.OffsetYProperty

type DropShadowEffectModifiers =

    /// <summary>Link a ViewRef to access the direct DropShadowEffect control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDropShadowEffect>, value: ViewRef<DropShadowEffect>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
