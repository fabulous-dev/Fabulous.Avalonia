namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuDropShadowEffect =
    inherit IFabMvuDropShadowEffectBase
    inherit IFabDropShadowEffect

[<AutoOpen>]
module MvuDropShadowEffectBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DropShadowEffect widget.</summary>
        static member DropShadowEffect() =
            WidgetBuilder<'msg, IFabMvuDropShadowEffect>(DropShadowEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a DropShadowEffect widget.</summary>
        /// <param name="offsetX">The X offset of the shadow.</param>
        /// <param name="offsetY">The Y offset of the shadow.</param>
        static member DropShadowEffect(offsetX: float, offsetY: float) =
            WidgetBuilder<'msg, IFabMvuDropShadowEffect>(
                DropShadowEffect.WidgetKey,
                DropShadowEffect.OffsetX.WithValue(offsetX),
                DropShadowEffect.OffsetY.WithValue(offsetY)
            )
