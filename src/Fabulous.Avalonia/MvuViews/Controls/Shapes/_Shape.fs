namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia

type IFabMvuShape =
    inherit IFabMvuControl
    inherit IFabShape

type MvuShapeExtraModifiers =
    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabMvuShape>, value: Color) =
        ShapeModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabMvuShape>, value: string) =
        ShapeModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabMvuShape>, value: Color) =
        ShapeModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabMvuShape>, value: string) =
        ShapeModifiers.stroke(this, View.SolidColorBrush(value))