namespace Fabulous.Avalonia

open Avalonia.Controls.Shapes
open Fabulous

type IFabArc =
    inherit IFabShape

module Arc =
    let WidgetKey = Widgets.register<Arc>()

    let StartAngle =
        Attributes.defineAvaloniaPropertyWithEquality Arc.StartAngleProperty

    let SweepAngle =
        Attributes.defineAvaloniaPropertyWithEquality Arc.SweepAngleProperty

[<AutoOpen>]
module ArcBuilders =
    type Fabulous.Avalonia.View with

        static member Arc(startAngle: float, sweepAngle: float) =
            WidgetBuilder<'msg, IFabArc>(
                Arc.WidgetKey,
                Arc.StartAngle.WithValue(startAngle),
                Arc.SweepAngle.WithValue(sweepAngle)
            )
