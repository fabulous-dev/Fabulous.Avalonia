namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentBorder =
    inherit IFabComponentDecorator
    inherit IFabBorder

[<AutoOpen>]
module ComponentBorderBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Border widget.</summary>
        /// <param name="content">The content of the Border.</param>
        static member Border(content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentBorder>(
                Border.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentBorderExtraModifiers =
    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<unit, #IFabBorder>, value: Color) =
        BorderModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<unit, #IFabBorder>, value: string) =
        BorderModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabBorder>, value: Color) =
        BorderModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabBorder>, value: string) =
        BorderModifiers.background(this, View.SolidColorBrush(value))
