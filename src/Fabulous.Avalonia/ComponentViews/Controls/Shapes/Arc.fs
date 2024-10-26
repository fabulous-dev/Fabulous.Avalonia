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

type ComponentArcModifiers =
    /// <summary>Link a ViewRef to access the direct Arc control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentArc>, value: ViewRef<Arc>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
