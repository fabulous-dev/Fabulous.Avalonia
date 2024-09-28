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
            WidgetBuilder<unit, IFabMvuArc>(Arc.WidgetKey, Arc.StartAngle.WithValue(startAngle), Arc.SweepAngle.WithValue(sweepAngle))

type MvuArcModifiers =
    /// <summary>Link a ViewRef to access the direct Arc control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuArc>, value: ViewRef<Arc>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
