namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Avalonia.Media.Immutable
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

type ComponentTextDecorationModifiers =

    /// <summary>Link a ViewRef to access the direct TextDecoration control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTextDecoration>, value: ViewRef<TextDecoration>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ComponentTextDecorationExtraModifiers =
    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<unit, #IFabTextDecoration>, value: Color) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<unit, #IFabTextDecoration>, value: string) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))
