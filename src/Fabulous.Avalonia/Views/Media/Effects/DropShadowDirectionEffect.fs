namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDropShadowDirectionEffect =
    inherit IFabDropShadowEffectBase

module DropShadowDirectionEffect =
    let WidgetKey = Widgets.register<DropShadowDirectionEffect>()

    let ShadowDepth =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowDirectionEffect.ShadowDepthProperty

    let Direction =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowDirectionEffect.DirectionProperty

[<AutoOpen>]
module DropShadowDirectionEffectBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        static member DropShadowDirectionEffect() =
            WidgetBuilder<'msg, IFabDropShadowDirectionEffect>(DropShadowDirectionEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        /// <param name="shadowDepth">The depth of the shadow.</param>
        /// <param name="direction">The direction of the shadow.</param>
        static member DropShadowDirectionEffect(shadowDepth: float, direction: float) =
            WidgetBuilder<'msg, IFabDropShadowDirectionEffect>(
                DropShadowDirectionEffect.WidgetKey,
                DropShadowDirectionEffect.ShadowDepth.WithValue(shadowDepth),
                DropShadowDirectionEffect.Direction.WithValue(direction)
            )
