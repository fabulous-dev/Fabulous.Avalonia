namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous

type IFabTemplatedControl =
    inherit IFabControl

module TemplatedControl =
    let Background =
        Attributes.defineAvaloniaPropertyWidget TemplatedControl.BackgroundProperty

    let BorderBrush =
        Attributes.defineAvaloniaPropertyWidget TemplatedControl.BorderBrushProperty

    let BorderThickness =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.BorderThicknessProperty

    let CornerRadius =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.CornerRadiusProperty

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontStretchProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWidget TemplatedControl.ForegroundProperty

    let Padding =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.PaddingProperty

[<Extension>]
type TemplatedControlModifiers =
    [<Extension>]
    static member inline background
        (
            this: WidgetBuilder<'msg, #IFabTemplatedControl>,
            value: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TemplatedControl.Background.WithValue(value.Compile()))

    [<Extension>]
    static member inline borderBrush
        (
            this: WidgetBuilder<'msg, #IFabTemplatedControl>,
            value: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TemplatedControl.BorderBrush.WithValue(value.Compile()))

    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Thickness) =
        this.AddScalar(TemplatedControl.BorderThickness.WithValue(value))

    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: CornerRadius) =
        this.AddScalar(TemplatedControl.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontFamily) =
        this.AddScalar(TemplatedControl.FontFamily.WithValue(value))

    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: float) =
        this.AddScalar(TemplatedControl.FontSize.WithValue(value))

    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontStyle) =
        this.AddScalar(TemplatedControl.FontStyle.WithValue(value))

    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontWeight) =
        this.AddScalar(TemplatedControl.FontWeight.WithValue(value))

    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontStretch) =
        this.AddScalar(TemplatedControl.FontStretch.WithValue(value))

    [<Extension>]
    static member inline foreground
        (
            this: WidgetBuilder<'msg, #IFabTemplatedControl>,
            value: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TemplatedControl.Foreground.WithValue(value.Compile()))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Thickness) =
        this.AddScalar(TemplatedControl.Padding.WithValue(value))

[<Extension>]
type TemplatedControlExtraModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, uniformValue: float) =
        this.padding (Thickness(uniformValue))
