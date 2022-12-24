namespace Fabulous.Avalonia

open Avalonia.Controls.Shapes
open Fabulous

type IFabSector =
    inherit IFabShape

module Sector =
    let WidgetKey = Widgets.register<Sector> ()

    let StartAngle =
        Attributes.defineAvaloniaPropertyWithEquality Sector.StartAngleProperty

    let SweepAngle =
        Attributes.defineAvaloniaPropertyWithEquality Sector.SweepAngleProperty

[<AutoOpen>]
module SectorBuilders =
    type Fabulous.Avalonia.View with

        static member Sector(startAngle: float, sweepAngle: float) =
            WidgetBuilder<'msg, IFabSector>(
                Sector.WidgetKey,
                Sector.StartAngle.WithValue(startAngle),
                Sector.SweepAngle.WithValue(sweepAngle)
            )
