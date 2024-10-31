namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.Avalonia

type IFabComponentArc =
    inherit IFabComponentShape
    inherit IFabArc

[<AutoOpen>]
module ComponentArcBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Arc widget/</summary>
        /// <param name="startAngle">The starting angle/</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        static member Arc(startAngle: float, sweepAngle: float) =
            WidgetBuilder<unit, IFabComponentArc>(Arc.WidgetKey, Arc.StartAngle.WithValue(startAngle), Arc.SweepAngle.WithValue(sweepAngle))
