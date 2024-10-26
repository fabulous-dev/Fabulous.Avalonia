namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.Avalonia

type IFabMvuSector =
    inherit IFabMvuShape
    inherit IFabSector

[<AutoOpen>]
module MvuSectorBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Sector widget.</summary>
        /// <param name="startAngle">The starting angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        static member Sector(startAngle: float, sweepAngle: float) =
            WidgetBuilder<'msg, IFabMvuSector>(Sector.WidgetKey, Sector.StartAngle.WithValue(startAngle), Sector.SweepAngle.WithValue(sweepAngle))
