namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentDropShadowEffect =
    inherit IFabComponentDropShadowEffectBase
    inherit IFabDropShadowEffect

[<AutoOpen>]
module ComponentDropShadowEffectBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DropShadowEffect widget.</summary>
        static member DropShadowEffect() =
            WidgetBuilder<unit, IFabDropShadowEffect>(DropShadowEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a DropShadowEffect widget.</summary>
        /// <param name="offsetX">The X offset of the shadow.</param>
        /// <param name="offsetY">The Y offset of the shadow.</param>
        static member DropShadowEffect(offsetX: float, offsetY: float) =
            WidgetBuilder<unit, IFabDropShadowEffect>(
                DropShadowEffect.WidgetKey,
                DropShadowEffect.OffsetX.WithValue(offsetX),
                DropShadowEffect.OffsetY.WithValue(offsetY)
            )
