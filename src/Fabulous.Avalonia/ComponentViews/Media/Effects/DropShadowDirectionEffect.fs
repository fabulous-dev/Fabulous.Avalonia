namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentDropShadowDirectionEffect =
    inherit IFabComponentDropShadowEffectBase

[<AutoOpen>]
module ComponentDropShadowDirectionEffectBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        static member DropShadowDirectionEffect() =
            WidgetBuilder<unit, IFabDropShadowDirectionEffect>(DropShadowDirectionEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        /// <param name="shadowDepth">The depth of the shadow.</param>
        /// <param name="direction">The direction of the shadow.</param>
        static member DropShadowDirectionEffect(shadowDepth: float, direction: float) =
            WidgetBuilder<unit, IFabDropShadowDirectionEffect>(
                DropShadowDirectionEffect.WidgetKey,
                DropShadowDirectionEffect.ShadowDepth.WithValue(shadowDepth),
                DropShadowDirectionEffect.Direction.WithValue(direction)
            )
