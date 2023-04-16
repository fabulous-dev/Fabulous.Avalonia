namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous

type IFabDecorator =
    inherit IFabControl

module Decorator =
    let Child = Attributes.defineAvaloniaPropertyWidget Decorator.ChildProperty

    let Padding =
        Attributes.defineAvaloniaPropertyWithEquality Decorator.PaddingProperty

[<Extension>]
type DecoratorModifiers =
    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, value: Thickness) =
        this.AddScalar(Decorator.Padding.WithValue(value))

    /// <summary>Sets the Child property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="widget">The value to set.</param>
    [<Extension>]
    static member inline child(this: WidgetBuilder<'msg, #IFabDecorator>, widget: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(Decorator.Child.WithValue(widget.Compile()))

[<Extension>]
type DecoratorExtraModifiers =
    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, value: float) =
        DecoratorModifiers.padding(this, Thickness(value))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="left">The value to set for left.</param>
    /// <param name="top">The value to set for top.</param>
    /// <param name="right">The value to set for right.</param>
    /// <param name="bottom">The value to set for bottom.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, left: float, top: float, right: float, bottom: float) =
        DecoratorModifiers.padding(this, Thickness(left, top, right, bottom))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="horizontal">The value to set for left and right.</param>
    /// <param name="vertical">The value to set for top and bottom.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, horizontal: float, vertical) =
        DecoratorModifiers.padding(this, Thickness(horizontal, vertical))
