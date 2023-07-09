namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous

type IFabBlurEffect =
    inherit IFabEffect

module BlurEffect =
    let WidgetKey = Widgets.register<BlurEffect>()

    let Radius = Attributes.defineAvaloniaPropertyWithEquality BlurEffect.RadiusProperty

[<AutoOpen>]
module BlurEffectBuilders =
    type Fabulous.Avalonia.View with

        static member BlurEffect(radius: float) =
            WidgetBuilder<'msg, IFabBlurEffect>(BlurEffect.WidgetKey, BlurEffect.Radius.WithValue(radius))
