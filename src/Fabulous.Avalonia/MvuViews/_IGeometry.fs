namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuGeometry =
    inherit IFabMvuElement
    inherit IFabGeometry

module MvuGeometry =
    let Changed =
        Attributes.defineEventNoArg "Geometry_Changed" (fun target -> (target :?> Geometry).Changed)

type MvuGeometryModifiers =
    /// <summary>Listens to the Geometry Changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the geometry changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabMvuGeometry>, msg: 'msg) =
        this.AddScalar(MvuGeometry.Changed.WithValue(MsgValue msg))

type GeometryAttachedModifiers =
    /// <summary>Sets the Clip property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Clip value.</param>
    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IFabMvuVisual>, value: WidgetBuilder<'msg, #IFabMvuGeometry>) =
        this.AddWidget(Visual.ClipWidget.WithValue(value.Compile()))
