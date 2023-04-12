namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Immutable
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

[<Extension>]
type VisualModifiers =
    /// <summary>Set the Bounds property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline bounds(this: WidgetBuilder<'msg, #IFabVisual>, value: Rect) =
        this.AddScalar(Visual.Bounds.WithValue(value))

    /// <summary>Set the ClipToBounds property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline clipToBounds(this: WidgetBuilder<'msg, #IFabVisual>, value: bool) =
        this.AddScalar(Visual.ClipToBounds.WithValue(value))

    /// <summary>Set the Clip property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="widget">The widget to set</param>
    /// <example>
    /// <code>
    /// Border()
    ///     .clip(PathGeometry(clip, FillRule.EvenOdd))
    /// </code>
    /// </example>
    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IFabVisual>, widget: WidgetBuilder<'msg, #IFabGeometry>) =
        this.AddWidget(Visual.Clip.WithValue(widget.Compile()))

    /// <summary>Set the IsVisible property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabVisual>, value: bool) =
        this.AddScalar(Visual.IsVisible.WithValue(value))

    /// <summary> Set the Opacity property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabVisual>, value: double) =
        this.AddScalar(Visual.Opacity.WithValue(value))

    /// <summary>Set the OpacityMask property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="widget">The widget to set</param>
    /// <example>
    /// <code>
    /// Rectangle(10., 10.)
    ///     .size(50., 50.)
    ///     .opacityMask(
    ///         LinearGradientBrush(RelativePoint.Center, RelativePoint.BottomRight) {
    ///             ...
    ///         }
    ///     )
    /// </code>
    /// </example>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, widget: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Visual.OpacityMaskWidget.WithValue(widget.Compile()))

    /// <summary>Set the OpacityMask property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    /// <example>
    /// <code>
    /// Rectangle(10., 10.)
    ///     .size(50., 50.)
    ///     .opacityMask(GradientBrush.Parse(".."))
    /// </code>
    /// </example>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: IBrush) =
        this.AddScalar(Visual.OpacityMask.WithValue(value))

    /// <summary>Set the OpacityMask property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    /// <example>
    /// <code>
    /// Rectangle(10., 10.)
    ///     .size(50., 50.)
    ///     .opacityMask("...")
    /// </code>
    /// </example>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: string) =
        this.AddScalar(Visual.OpacityMask.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Set the RenderTransform property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="widget">The widget to set</param>
    /// <example>
    /// <code>
    /// Border(TextBlock("Hello"))
    ///     .renderTransform(RotateTransform(45.))
    /// </code>
    /// </example>
    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabVisual>, widget: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Visual.RenderTransformWidget.WithValue(widget.Compile()))

    /// <summary>Set the RenderTransform property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    /// <example>
    /// <code>
    /// Border(TextBlock("Hello"))
    ///     .renderTransform(TransformOperations.Parse("rotate(90deg) scale(1.5)"))
    /// </code>
    /// </example>
    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabVisual>, value: ITransform) =
        this.AddScalar(Visual.RenderTransform.WithValue(value))

    /// <summary>Set the RenderTransformOrigin property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline renderTransformOrigin(this: WidgetBuilder<'msg, #IFabVisual>, value: RelativePoint) =
        this.AddScalar(Visual.RenderTransformOrigin.WithValue(value))

    /// <summary>Set the ZIndex property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline zIndex(this: WidgetBuilder<'msg, #IFabVisual>, value: int) =
        this.AddScalar(Visual.ZIndex.WithValue(value))

    /// <summary>Set the FlowDirection property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabVisual>, value: FlowDirection) =
        this.AddScalar(Visual.FlowDirection.WithValue(value))
