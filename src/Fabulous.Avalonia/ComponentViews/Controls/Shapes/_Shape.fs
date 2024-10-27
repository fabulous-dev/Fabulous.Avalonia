namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentShape =
    inherit IFabComponentControl
    inherit IFabShape

type ComponentShapeExtraModifiers =
    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<unit, #IFabShape>, value: Color) =
        ShapeModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<unit, #IFabShape>, value: string) =
        ShapeModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<unit, #IFabShape>, value: Color) =
        ShapeModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<unit, #IFabShape>, value: string) =
        ShapeModifiers.stroke(this, View.SolidColorBrush(value))
