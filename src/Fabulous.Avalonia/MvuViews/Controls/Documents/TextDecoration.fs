namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuTextDecoration =
    inherit IFabMvuElement
    inherit IFabTextDecoration

[<AutoOpen>]
module MvuTextDecorationBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TextDecoration widget.</summary>
        /// <param name="location">The location of the TextDecoration.</param>
        static member inline TextDecoration(location: TextDecorationLocation) =
            WidgetBuilder<'msg, IFabMvuTextDecoration>(TextDecoration.WidgetKey, TextDecoration.Location.WithValue(location))

type MvuTextDecorationExtraModifiers =
    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: Color) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))

    /// <summary>Sets the Stroke property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stroke value.</param>
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: string) =
        TextDecorationModifiers.stroke(this, View.SolidColorBrush(value))
