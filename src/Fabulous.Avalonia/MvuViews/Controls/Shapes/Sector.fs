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
            WidgetBuilder<unit, IFabMvuSector>(Sector.WidgetKey, Sector.StartAngle.WithValue(startAngle), Sector.SweepAngle.WithValue(sweepAngle))

type MvuSectorModifiers =
    /// <summary>Link a ViewRef to access the direct Sector control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuSector>, value: ViewRef<Sector>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
