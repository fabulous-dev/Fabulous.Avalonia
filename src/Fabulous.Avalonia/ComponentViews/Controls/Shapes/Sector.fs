namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.Avalonia

type IFabComponentSector =
    inherit IFabComponentShape
    inherit IFabSector

[<AutoOpen>]
module ComponentSectorBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Sector widget.</summary>
        /// <param name="startAngle">The starting angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        static member Sector(startAngle: float, sweepAngle: float) =
            WidgetBuilder<unit, IFabComponentSector>(Sector.WidgetKey, Sector.StartAngle.WithValue(startAngle), Sector.SweepAngle.WithValue(sweepAngle))
