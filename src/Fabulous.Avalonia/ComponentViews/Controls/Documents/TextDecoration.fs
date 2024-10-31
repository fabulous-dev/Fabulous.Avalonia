namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentTextDecoration =
    inherit IFabComponentElement
    inherit IFabTextDecoration

[<AutoOpen>]
module ComponentTextDecorationBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TextDecoration widget.</summary>
        /// <param name="location">The location of the TextDecoration.</param>
        static member inline TextDecoration(location: TextDecorationLocation) =
            WidgetBuilder<unit, IFabComponentTextDecoration>(TextDecoration.WidgetKey, TextDecoration.Location.WithValue(location))

type ComponentTextDecorationExtraModifiers =
    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<unit, #IFabComponentTextDecoration>, value: Color) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<unit, #IFabComponentTextDecoration>, value: string) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))
