namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.VisualTree
open Fabulous

type IFabVisual =
    inherit IFabStyledElement

module Visual =

    let Bounds = Attributes.defineAvaloniaPropertyWithEquality Visual.BoundsProperty

    let TransformedBounds =
        Attributes.defineAvaloniaPropertyWithEquality Visual.TransformedBoundsProperty

    let ClipToBounds =
        Attributes.defineAvaloniaPropertyWithEquality Visual.ClipToBoundsProperty

    let Clip = Attributes.defineAvaloniaPropertyWidget Visual.ClipProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality Visual.IsVisibleProperty

    let Opacity = Attributes.defineAvaloniaPropertyWithEquality Visual.OpacityProperty

    let OpacityMask = Attributes.defineAvaloniaPropertyWidget Visual.OpacityMaskProperty

    let HasMirroredTransform =
        Attributes.defineAvaloniaPropertyWithEquality Visual.HasMirrorTransformProperty

    let RenderTransform =
        Attributes.defineAvaloniaPropertyWidget Visual.RenderTransformProperty

    let RenderTransformOrigin =
        Attributes.defineAvaloniaPropertyWithEquality Visual.RenderTransformOriginProperty

    let VisualParent =
        Attributes.defineAvaloniaPropertyWithEquality Visual.VisualParentProperty

    let ZIndex = Attributes.defineAvaloniaPropertyWithEquality Visual.ZIndexProperty

[<Extension>]
type VisualModifiers =
    [<Extension>]
    static member inline bounds(this: WidgetBuilder<'msg, #IFabAnimatable>, rect: Rect) =
        this.AddScalar(Visual.Bounds.WithValue(rect))

    [<Extension>]
    static member inline transformedBounds(this: WidgetBuilder<'msg, #IFabAnimatable>, rect: TransformedBounds) =
        this.AddScalar(Visual.TransformedBounds.WithValue(rect))


    [<Extension>]
    static member inline clipToBounds(this: WidgetBuilder<'msg, #IFabAnimatable>, clip: bool) =
        this.AddScalar(Visual.ClipToBounds.WithValue(clip))

    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IFabAnimatable>, clip: WidgetBuilder<'msg, #IFabGeometry>) =
        this.AddWidget(Visual.Clip.WithValue(clip.Compile()))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabAnimatable>, visible: bool) =
        this.AddScalar(Visual.IsVisible.WithValue(visible))

    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabAnimatable>, opacity: double) =
        this.AddScalar(Visual.Opacity.WithValue(opacity))

    [<Extension>]
    static member inline opacityMask
        (
            this: WidgetBuilder<'msg, #IFabAnimatable>,
            mask: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(Visual.OpacityMask.WithValue(mask.Compile()))

    [<Extension>]
    static member inline hasMirroredTransform(this: WidgetBuilder<'msg, #IFabAnimatable>, hasMirror: bool) =
        this.AddScalar(Visual.HasMirroredTransform.WithValue(hasMirror))

    [<Extension>]
    static member inline renderTransform
        (
            this: WidgetBuilder<'msg, #IFabAnimatable>,
            transform: WidgetBuilder<'msg, #IFabTransform>
        ) =
        this.AddWidget(Visual.RenderTransform.WithValue(transform.Compile()))

    [<Extension>]
    static member inline renderTransformOrigin(this: WidgetBuilder<'msg, #IFabAnimatable>, origin: RelativePoint) =
        this.AddScalar(Visual.RenderTransformOrigin.WithValue(origin))

    [<Extension>]
    static member inline visualParent(this: WidgetBuilder<'msg, #IFabAnimatable>, parent: IVisual) =
        this.AddScalar(Visual.VisualParent.WithValue(parent))

    [<Extension>]
    static member inline zIndex(this: WidgetBuilder<'msg, #IFabAnimatable>, index: int) =
        this.AddScalar(Visual.ZIndex.WithValue(index))
