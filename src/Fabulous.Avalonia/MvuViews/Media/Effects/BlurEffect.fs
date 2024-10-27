namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuBlurEffect =
    inherit IFabMvuEffect
    inherit IFabBlurEffect

[<AutoOpen>]
module MvuBlurEffectBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a BlurEffect widget.</summary>
        static member BlurEffect() =
            WidgetBuilder<'msg, IFabMvuBlurEffect>(BlurEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a BlurEffect widget.</summary>
        /// <param name="radius">The radius of the blur effect.</param>
        static member BlurEffect(radius: float) =
            WidgetBuilder<'msg, IFabMvuBlurEffect>(BlurEffect.WidgetKey, BlurEffect.Radius.WithValue(radius))
