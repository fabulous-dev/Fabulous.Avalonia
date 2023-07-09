namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous

type IFabVisual =
    inherit IFabStyledElement

module Visual =
    let ClipToBounds =
        Attributes.defineAvaloniaPropertyWithEquality Visual.ClipToBoundsProperty

    let Clip = Attributes.defineAvaloniaPropertyWidget Visual.ClipProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality Visual.IsVisibleProperty

    let Opacity = Attributes.defineAvaloniaPropertyWithEquality Visual.OpacityProperty

    let OpacityMaskWidget =
        Attributes.defineAvaloniaPropertyWidget Visual.OpacityMaskProperty

    let OpacityMask =
        Attributes.defineAvaloniaPropertyWithEquality Visual.OpacityMaskProperty

    let RenderTransformWidget =
        Attributes.defineAvaloniaPropertyWidget Visual.RenderTransformProperty

    let RenderTransform =
        Attributes.defineAvaloniaPropertyWithEquality Visual.RenderTransformProperty

    let RenderTransformOrigin =
        Attributes.defineAvaloniaPropertyWithEquality Visual.RenderTransformOriginProperty

    let ZIndex = Attributes.defineAvaloniaPropertyWithEquality Visual.ZIndexProperty

    let FlowDirection =
        Attributes.defineAvaloniaPropertyWithEquality Visual.FlowDirectionProperty

    let Effect = Attributes.defineAvaloniaPropertyWidget Visual.EffectProperty

    let AttachedToVisualTree =
        Attributes.defineEvent "VisualAttachedToVisualTree" (fun target -> (target :?> Visual).AttachedToVisualTree)

    let DetachedFromVisualTree =
        Attributes.defineEvent "VisualAttachedToVisualTree" (fun target -> (target :?> Visual).DetachedFromVisualTree)

[<Extension>]
type VisualModifiers =
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
        this.AddWidget(Visual.OpacityMaskWidget.WithValue(mask.Compile()))

    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, brush: IBrush) =
        this.AddScalar(Visual.OpacityMask.WithValue(brush))

    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, brush: string) =
        this.AddScalar(Visual.OpacityMask.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

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

    [<Extension>]
    static member inline onAttachedToVisualTree(this: WidgetBuilder<'msg, #IFabVisual>, fn: VisualTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(Visual.AttachedToVisualTree.WithValue(fun args -> fn args |> box))

    [<Extension>]
    static member inline onDetachedFromVisualTree(this: WidgetBuilder<'msg, #IFabVisual>, fn: VisualTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(Visual.DetachedFromVisualTree.WithValue(fun args -> fn args |> box))
