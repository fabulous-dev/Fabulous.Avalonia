namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous

type IFabTextDecoration =
    inherit IFabElement

module TextDecoration =
    let WidgetKey = Widgets.register<TextDecoration>()

    let Location =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.LocationProperty

    let StrokeWidget =
        Attributes.defineAvaloniaPropertyWidget TextDecoration.StrokeProperty

    let Stroke =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeProperty

    let StrokeThicknessUnit =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeThicknessUnitProperty

    let StrokeDashArray =
        Attributes.defineSimpleScalarWithEquality<float list> "TextDecoration_StrokeDashArray" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(TextDecoration.StrokeDashArrayProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(TextDecoration.StrokeDashArrayProperty, coll) |> ignore)

    let StrokeDashOffset =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeDashOffsetProperty

    let StrokeThickness =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeThicknessProperty

    let StrokeLineCap =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeLineCapProperty

    let StrokeOffset =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeOffsetProperty

    let StrokeOffsetUnit =
        Attributes.defineAvaloniaPropertyWithEquality TextDecoration.StrokeOffsetUnitProperty

[<AutoOpen>]
module TextDecorationBuilders =
    type Fabulous.Avalonia.View with

        static member inline TextDecoration<'msg>(location: TextDecorationLocation) =
            WidgetBuilder<'msg, IFabTextDecoration>(TextDecoration.WidgetKey, TextDecoration.Location.WithValue(location))

[<Extension>]
type TextDecorationModifiers =
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextDecoration.StrokeWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabTextDecoration>, brush: string) =
        this.AddScalar(TextDecoration.Stroke.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline strokeThicknessUnit(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: TextDecorationUnit) =
        this.AddScalar(TextDecoration.StrokeThicknessUnit.WithValue(value))

    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float list) =
        this.AddScalar(TextDecoration.StrokeDashArray.WithValue(value))

    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float) =
        this.AddScalar(TextDecoration.StrokeDashOffset.WithValue(value))

    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float) =
        this.AddScalar(TextDecoration.StrokeThickness.WithValue(value))

    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: PenLineCap) =
        this.AddScalar(TextDecoration.StrokeLineCap.WithValue(value))

    [<Extension>]
    static member inline strokeOffset(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: float) =
        this.AddScalar(TextDecoration.StrokeOffset.WithValue(value))

    [<Extension>]
    static member inline strokeOffsetUnit(this: WidgetBuilder<'msg, #IFabTextDecoration>, value: TextDecorationUnit) =
        this.AddScalar(TextDecoration.StrokeOffsetUnit.WithValue(value))
