namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Immutable
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

    /// <summary>Sets the Opacity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Opacity value.</param>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabBrush>, value: float) =
        this.AddScalar(Brush.Opacity.WithValue(value))

    /// <summary>Sets the Transform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transform value.</param>
    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabBrush>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Brush.Transform.WithValue(value.Compile()))

    /// <summary>Sets the TransformOrigin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransformOrigin value.</param>
    [<Extension>]
    static member inline transformOrigin(this: WidgetBuilder<'msg, #IFabBrush>, value: RelativePoint) =
        this.AddScalar(Brush.TransformOrigin.WithValue(value))

[<Extension>]
type VisualAttachedModifiers =
    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Visual.OpacityMaskWidget.WithValue(value.Compile()))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: IBrush) =
        this.AddScalar(Visual.OpacityMask.WithValue(value))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: string) =
        this.AddScalar(Visual.OpacityMask.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

[<Extension>]
type TemplatedControlAttachedModifiers =
    /// <summary>Sets the BackgroundWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BackgroundWidget value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the BorderBrushWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrushWidget value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.BorderBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the ForegroundWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ForegroundWidget value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.ForegroundWidget.WithValue(value.Compile()))

[<Extension>]
type TopLevelAttachedModifiers =
    /// <summary>Sets the TransparencyBackgroundFallbackWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyBackgroundFallbackWidget value.</param>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.TransparencyBackgroundFallbackWidget.WithValue(value.Compile()))

    /// <summary>Sets the SystemBarColorWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SystemBarColorWidget value.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabTopLevel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.SystemBarColorWidget.WithValue(value.Compile()))

[<Extension>]
type TextElementAttachedModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BackgroundWidget value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextElement>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextElement.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextElement>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextElement.ForegroundWidget.WithValue(value.Compile()))
