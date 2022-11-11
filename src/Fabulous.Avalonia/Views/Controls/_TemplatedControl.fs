namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls.Primitives

open Fabulous

type IFabTemplatedControl = inherit IFabControl

module TemplatedControl =
    let Background = Attributes.defineStyledWidget TemplatedControl.BackgroundProperty
    let Foreground = Attributes.defineStyledWidget TemplatedControl.ForegroundProperty
    let Padding = Attributes.defineStyledWithEquality TemplatedControl.PaddingProperty

[<Extension>]
type TemplatedControlModifiers =
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.Background.WithValue(value.Compile()))
        
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.Foreground.WithValue(value.Compile()))
        
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Thickness) =
        this.AddScalar(TemplatedControl.Padding.WithValue(value))
        
[<Extension>]
type TemplatedControlExtraModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, uniformValue: float) =
        this.padding(Thickness(uniformValue))