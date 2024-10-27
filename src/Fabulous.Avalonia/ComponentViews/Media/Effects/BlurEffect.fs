namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentBlurEffect =
    inherit IFabComponentEffect
    inherit IFabBlurEffect

[<AutoOpen>]
module ComponentBlurEffectBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a BlurEffect widget.</summary>
        static member BlurEffect() =
            WidgetBuilder<'msg, IFabComponentBlurEffect>(BlurEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a BlurEffect widget.</summary>
        /// <param name="radius">The radius of the blur effect.</param>
        static member BlurEffect(radius: float) =
            WidgetBuilder<'msg, IFabComponentBlurEffect>(BlurEffect.WidgetKey, BlurEffect.Radius.WithValue(radius))
