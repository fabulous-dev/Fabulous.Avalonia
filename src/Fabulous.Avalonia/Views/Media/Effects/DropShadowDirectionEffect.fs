namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabDropShadowDirectionEffect =
    inherit IFabDropShadowEffectBase

module DropShadowDirectionEffect =
    let WidgetKey = Widgets.register<DropShadowDirectionEffect>()

    let ShadowDepth =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowDirectionEffect.ShadowDepthProperty

    let Direction =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowDirectionEffect.DirectionProperty


type DropShadowDirectionEffectModifiers =

    /// <summary>Link a ViewRef to access the direct DropShadowDirectionEffect control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDropShadowDirectionEffect>, value: ViewRef<DropShadowDirectionEffect>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
