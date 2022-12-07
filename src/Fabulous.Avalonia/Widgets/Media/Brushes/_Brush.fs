namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabBrush =
    inherit IFabAnimatable

module Brush =

    let Opacity = Attributes.defineAvaloniaPropertyWithEquality Brush.OpacityProperty

    let Transform = Attributes.defineAvaloniaPropertyWidget Brush.TransformProperty

    let TransformOrigin =
        Attributes.defineAvaloniaPropertyWithEquality Brush.TransformOriginProperty

[<Extension>]
type BrushModifiers =

    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabBrush>, value: float) =
        this.AddScalar(Brush.Opacity.WithValue(value))

    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabBrush>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Brush.Transform.WithValue(value.Compile()))

    [<Extension>]
    static member inline transformOrigin(this: WidgetBuilder<'msg, #IFabBrush>, value: RelativePoint) =
        this.AddScalar(Brush.TransformOrigin.WithValue(value))
