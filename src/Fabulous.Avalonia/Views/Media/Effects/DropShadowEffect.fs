namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDropShadowEffect =
    inherit IFabDropShadowEffectBase

module DropShadowEffect =
    let WidgetKey = Widgets.register<DropShadowEffect>()

    let OffsetX =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffect.OffsetXProperty

    let OffsetY =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffect.OffsetYProperty

[<AutoOpen>]
module DropShadowEffectBuilders =
    type Fabulous.Avalonia.View with

        static member DropShadowEffect() =
            WidgetBuilder<'msg, IFabDropShadowEffect>(DropShadowEffect.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        static member DropShadowEffect(offsetX: float, offsetY: float) =
            WidgetBuilder<'msg, IFabDropShadowEffect>(
                DropShadowEffect.WidgetKey,
                DropShadowEffect.OffsetX.WithValue(offsetX),
                DropShadowEffect.OffsetY.WithValue(offsetY)
            )
