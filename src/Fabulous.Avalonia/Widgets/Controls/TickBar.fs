namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous

type IFabTickBar =
    inherit IFabControl

module TickBar =
    let WidgetKey = Widgets.register<TickBar>()

    let FillWidget = Attributes.defineAvaloniaPropertyWidget TickBar.FillProperty

    let Fill = Attributes.defineAvaloniaPropertyWithEquality TickBar.FillProperty

    let Minimum = Attributes.defineAvaloniaPropertyWithEquality TickBar.MinimumProperty

    let Maximum = Attributes.defineAvaloniaPropertyWithEquality TickBar.MaximumProperty

    let TickFrequency =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.TickFrequencyProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.OrientationProperty

    let Ticks =
        Attributes.defineSimpleScalarWithEquality<float list> "TickBar_Ticks" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(TickBar.TicksProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(TickBar.TicksProperty, coll) |> ignore)

    let IsDirectionReversed =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.IsDirectionReversedProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.PlacementProperty

    let ReservedSpace =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.ReservedSpaceProperty

[<AutoOpen>]
module TickBarBuilders =
    type Fabulous.Avalonia.View with

        static member TickBar(min: float, max: float) =
            WidgetBuilder<'msg, IFabTickBar>(TickBar.WidgetKey, TickBar.Minimum.WithValue(min), TickBar.Maximum.WithValue(max))

[<Extension>]
type TickBarModifiers =
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TickBar.FillWidget.WithValue(value.Compile()))

    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, brush: string) =
        this.AddScalar(TickBar.Fill.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline tickFrequency(this: WidgetBuilder<'msg, #IFabTickBar>, value: float) =
        this.AddScalar(TickBar.TickFrequency.WithValue(value))

    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabTickBar>, value: Orientation) =
        this.AddScalar(TickBar.Orientation.WithValue(value))

    [<Extension>]
    static member inline ticks(this: WidgetBuilder<'msg, #IFabTickBar>, value: float list) =
        this.AddScalar(TickBar.Ticks.WithValue(value))

    [<Extension>]
    static member inline isDirectionReversed(this: WidgetBuilder<'msg, #IFabTickBar>, value: bool) =
        this.AddScalar(TickBar.IsDirectionReversed.WithValue(value))

    [<Extension>]
    static member inline placement(this: WidgetBuilder<'msg, #IFabTickBar>, value: TickBarPlacement) =
        this.AddScalar(TickBar.Placement.WithValue(value))

    [<Extension>]
    static member inline reservedSpace(this: WidgetBuilder<'msg, #IFabTickBar>, value: Rect) =
        this.AddScalar(TickBar.ReservedSpace.WithValue(value))
