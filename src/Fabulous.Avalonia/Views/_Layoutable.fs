namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Layout
open Fabulous

type IFabLayoutable =
    inherit IFabVisual

module Layoutable =
    let Width = Attributes.defineAvaloniaPropertyWithEquality Layoutable.WidthProperty

    let Height = Attributes.defineAvaloniaPropertyWithEquality Layoutable.HeightProperty

    let MinWidth =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MinWidthProperty

    let MinHeight =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MinHeightProperty

    let MaxWidth =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MaxWidthProperty

    let MaxHeight =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MaxHeightProperty

    let Margin = Attributes.defineAvaloniaPropertyWithEquality Layoutable.MarginProperty

    let HorizontalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.HorizontalAlignmentProperty

    let VerticalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.VerticalAlignmentProperty

    let UseLayoutRounding =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.UseLayoutRoundingProperty

    let EffectiveViewportChanged =
        Attributes.defineEvent<EffectiveViewportChangedEventArgs> "Layoutable_EffectiveViewportChanged" (fun target ->
            (target :?> Layoutable).EffectiveViewportChanged)

    let LayoutUpdated =
        Attributes.defineEventNoArg "Layoutable_LayoutUpdated" (fun target -> (target :?> Layoutable).LayoutUpdated)

[<Extension>]
type LayoutableModifiers =
    /// <summary>Set the Width property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Width.WithValue(value))

    /// <summary>Set the Height property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Height.WithValue(value))

    /// <summary>Set the MinWidth property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline minWidth(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MinWidth.WithValue(value))

    /// <summary>Set the MinHeight property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline minHeight(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MinHeight.WithValue(value))

    /// <summary>Set the MaxWidth property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline maxWidth(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MaxWidth.WithValue(value))

    /// <summary>Set the MaxHeight property </summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline maxHeight(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MaxHeight.WithValue(value))

    /// <summary>Set the Margin property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, value: Thickness) =
        this.AddScalar(Layoutable.Margin.WithValue(value))

    /// <summary>Set the HorizontalAlignment property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type HorizontalAlignment =
    /// | Stretch = 0
    /// | Left = 1
    /// | Center = 2
    /// | Right = 3
    /// </code>
    /// </example>
    [<Extension>]
    static member inline horizontalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: HorizontalAlignment) =
        this.AddScalar(Layoutable.HorizontalAlignment.WithValue(value))

    /// <summary>Set the VerticalAlignment property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type VerticalAlignment =
    /// | Stretch = 0
    /// | Top = 1
    /// | Center = 2
    /// | Bottom = 3
    /// </code>
    /// </example>
    [<Extension>]
    static member inline verticalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: VerticalAlignment) =
        this.AddScalar(Layoutable.VerticalAlignment.WithValue(value))

    /// <summary>Set the UseLayoutRounding property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline useLayoutRounding(this: WidgetBuilder<'msg, #IFabLayoutable>, value: bool) =
        this.AddScalar(Layoutable.UseLayoutRounding.WithValue(value))

    /// <summary>Listens to the EffectiveViewportChanged event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onEffectiveViewportChanged(this: WidgetBuilder<'msg, #IFabLayoutable>, fn: Rect -> 'msg) =
        this.AddScalar(Layoutable.EffectiveViewportChanged.WithValue(fun args -> fn args.EffectiveViewport |> box))

    /// <summary>Listens to the OnLayoutUpdated event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to be sent when the event is raised</param>
    [<Extension>]
    static member inline onLayoutUpdated(this: WidgetBuilder<'msg, #IFabLayoutable>, msg: 'msg) =
        this.AddScalar(Layoutable.LayoutUpdated.WithValue(msg))

[<Extension>]
type LayoutableExtraModifiers =
    /// <summary>Center the widget horizontally</summary>
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.horizontalAlignment(HorizontalAlignment.Center)

    /// <summary>Center the widget vertically</summary>
    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.verticalAlignment(VerticalAlignment.Center)

    /// <summary>Center the widget horizontally and vertically</summary>
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.centerHorizontal().centerVertical()

    /// <summary>Set the margin to a uniform value</summary>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, uniformValue: float) = this.margin(Thickness(uniformValue))

    /// <summary>Set the horizontal and vertical margins</summary>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, horizontal: float, vertical: float) =
        this.margin(Thickness(horizontal, vertical))

    /// <summary>Set the left, top, right and bottom margins</summary>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, left: float, top: float, right: float, bottom: float) =
        this.margin(Thickness(left, top, right, bottom))

    /// <summary>Set the width and height of the widget</summary>
    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IFabLayoutable>, width: float, height: float) = this.width(width).height(height)
