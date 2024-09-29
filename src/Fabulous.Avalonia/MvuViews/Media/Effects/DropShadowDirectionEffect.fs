namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuDropShadowDirectionEffect =
    inherit IFabMvuDropShadowEffectBase
    inherit IFabDropShadowDirectionEffect

[<AutoOpen>]
module MvuDropShadowDirectionEffectBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        static member DropShadowDirectionEffect() =
            WidgetBuilder<unit, IFabMvuDropShadowDirectionEffect>(DropShadowDirectionEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        /// <param name="shadowDepth">The depth of the shadow.</param>
        /// <param name="direction">The direction of the shadow.</param>
        static member DropShadowDirectionEffect(shadowDepth: float, direction: float) =
            WidgetBuilder<unit, IFabMvuDropShadowDirectionEffect>(
                DropShadowDirectionEffect.WidgetKey,
                DropShadowDirectionEffect.ShadowDepth.WithValue(shadowDepth),
                DropShadowDirectionEffect.Direction.WithValue(direction)
            )
