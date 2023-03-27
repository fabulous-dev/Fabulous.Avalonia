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
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, value: Thickness) =
        this.AddScalar(Decorator.Padding.WithValue(value))

    [<Extension>]
    static member inline child(this: WidgetBuilder<'msg, #IFabDecorator>, content: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(Decorator.Child.WithValue(content.Compile()))

[<Extension>]
type DecoratorExtraModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, value: float) =
        DecoratorModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, left: float, top: float, right: float, bottom: float) =
        DecoratorModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabDecorator>, horizontal: float, vertical) =
        DecoratorModifiers.padding(this, Thickness(horizontal, vertical))
