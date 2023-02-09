namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.VisualTree
open Fabulous

type IFabVisual =
    inherit IFabStyledElement

module Visual =

    let Bounds = Attributes.defineAvaloniaPropertyWithEquality Visual.BoundsProperty

    let ClipToBounds =
        Attributes.defineAvaloniaPropertyWithEquality Visual.ClipToBoundsProperty

    let Clip = Attributes.defineAvaloniaPropertyWidget Visual.ClipProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality Visual.IsVisibleProperty

    let Opacity = Attributes.defineAvaloniaPropertyWithEquality Visual.OpacityProperty

    let OpacityMask = Attributes.defineAvaloniaPropertyWidget Visual.OpacityMaskProperty

    let RenderTransformWidget =
        Attributes.defineAvaloniaPropertyWidget Visual.RenderTransformProperty

    let RenderTransform =
        Attributes.defineAvaloniaPropertyWithEquality Visual.RenderTransformProperty

    let RenderTransformOrigin =
        Attributes.defineAvaloniaPropertyWithEquality Visual.RenderTransformOriginProperty

    let ZIndex = Attributes.defineAvaloniaPropertyWithEquality Visual.ZIndexProperty

    let FlowDirection =
        Attributes.defineAvaloniaPropertyWithEquality Visual.FlowDirectionProperty

[<Extension>]
type VisualModifiers =
    [<Extension>]
    static member inline bounds(this: WidgetBuilder<'msg, #IFabVisual>, rect: Rect) =
        this.AddScalar(Visual.Bounds.WithValue(rect))

    [<Extension>]
    static member inline clipToBounds(this: WidgetBuilder<'msg, #IFabVisual>, clip: bool) =
        this.AddScalar(Visual.ClipToBounds.WithValue(clip))

    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IFabVisual>, clip: WidgetBuilder<'msg, #IFabGeometry>) =
        this.AddWidget(Visual.Clip.WithValue(clip.Compile()))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabVisual>, visible: bool) =
        this.AddScalar(Visual.IsVisible.WithValue(visible))

    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabVisual>, opacity: double) =
        this.AddScalar(Visual.Opacity.WithValue(opacity))

    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, mask: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Visual.OpacityMask.WithValue(mask.Compile()))

    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabVisual>, transform: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Visual.RenderTransformWidget.WithValue(transform.Compile()))

    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabVisual>, transform: ITransform) =
        this.AddScalar(Visual.RenderTransform.WithValue(transform))

    [<Extension>]
    static member inline renderTransformOrigin(this: WidgetBuilder<'msg, #IFabVisual>, origin: RelativePoint) =
        this.AddScalar(Visual.RenderTransformOrigin.WithValue(origin))

    [<Extension>]
    static member inline zIndex(this: WidgetBuilder<'msg, #IFabVisual>, index: int) =
        this.AddScalar(Visual.ZIndex.WithValue(index))

    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabVisual>, direction: FlowDirection) =
        this.AddScalar(Visual.FlowDirection.WithValue(direction))
