namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabBorder =
    inherit IFabDecorator

module Border =
    let WidgetKey = Widgets.register<Border>()

    let Background = Attributes.defineAvaloniaPropertyWidget Border.BackgroundProperty

    let BorderBrush = Attributes.defineAvaloniaPropertyWidget Border.BorderBrushProperty

    let BorderThickness =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderThicknessProperty

    let CornerRadius =
        Attributes.defineAvaloniaPropertyWithEquality Border.CornerRadiusProperty

    let BoxShadow =
        Attributes.defineAvaloniaPropertyWithEquality Border.BoxShadowProperty

    let BorderDashOffset =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderDashOffsetProperty

    let BorderDashArray =
        Attributes.defineSimpleScalarWithEquality<float list> "Border_BorderDashArray" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.BorderDashArrayProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(Border.BorderDashArrayProperty, coll) |> ignore)

    let BorderLineCap =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderLineCapProperty

    let BorderLineJoin =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderLineJoinProperty

[<AutoOpen>]
module BorderBuilders =
    type Fabulous.Avalonia.View with

        static member Border(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabBorder>(
                Border.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.Child.WithValue(content.Compile()) |], ValueNone)
            )

        static member Border() =
            WidgetBuilder<'msg, IFabBorder>(Border.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

[<Extension>]
type BorderModifiers =
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabBorder>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Border.Background.WithValue(value.Compile()))

    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabBorder>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Border.BorderBrush.WithValue(value.Compile()))

    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, value: Thickness) =
        this.AddScalar(Border.BorderThickness.WithValue(value))

    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, value: CornerRadius) =
        this.AddScalar(Border.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline boxShadows(this: WidgetBuilder<'msg, #IFabBorder>, value: BoxShadows) =
        this.AddScalar(Border.BoxShadow.WithValue(value))

    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabBorder>, value: float list) =
        this.AddScalar(Border.BorderDashArray.WithValue(value))

    [<Extension>]
    static member inline borderLineCap(this: WidgetBuilder<'msg, #IFabBorder>, value: PenLineCap) =
        this.AddScalar(Border.BorderLineCap.WithValue(value))

    [<Extension>]
    static member inline borderLineJoin(this: WidgetBuilder<'msg, #IFabBorder>, value: PenLineJoin) =
        this.AddScalar(Border.BorderLineJoin.WithValue(value))

    [<Extension>]
    static member inline borderDashOffset(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        this.AddScalar(Border.BorderDashOffset.WithValue(value))

[<Extension>]
type BorderExtraModifiers =
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        BorderModifiers.cornerRadius(this, CornerRadius(value))

    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, top: float, bottom: float) =
        BorderModifiers.cornerRadius(this, CornerRadius(top, bottom))

    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, topLeft: float, topRight: float, bottomRight: float, bottomLeft: float) =
        BorderModifiers.cornerRadius(this, CornerRadius(topLeft, topRight, bottomRight, bottomLeft))

    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, value: float) =
        BorderModifiers.borderThickness(this, Thickness(value))

    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, horizontal: float, vertical: float) =
        BorderModifiers.borderThickness(this, Thickness(horizontal, vertical))

    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, left: float, top: float, right: float, bottom: float) =
        BorderModifiers.borderThickness(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, value: string) =
        BorderModifiers.boxShadows(this, BoxShadows(BoxShadow.Parse(value)))

    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, first: string, rest: string list) =
        let rest = rest |> List.map BoxShadow.Parse |> List.toArray
        BorderModifiers.boxShadows(this, BoxShadows(BoxShadow.Parse(first), rest))
