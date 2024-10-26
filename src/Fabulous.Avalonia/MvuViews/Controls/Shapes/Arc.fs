namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.Avalonia

type IFabMvuArc =
    inherit IFabMvuShape
    inherit IFabArc

[<AutoOpen>]
module MvuArcBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Arc widget/</summary>
        /// <param name="startAngle">The starting angle/</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        static member Arc(startAngle: float, sweepAngle: float) =
            WidgetBuilder<'msg, IFabMvuArc>(Arc.WidgetKey, Arc.StartAngle.WithValue(startAngle), Arc.SweepAngle.WithValue(sweepAngle))
