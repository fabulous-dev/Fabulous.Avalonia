namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentGeometry =
    inherit IFabComponentElement
    inherit IFabGeometry

module ComponentGeometry =
    let Changed =
        Attributes.defineEventNoArgNoDispatch "Geometry_Changed" (fun target -> (target :?> Geometry).Changed)

type ComponentGeometryModifiers =
    /// <summary>Listens to the Geometry Changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the geometry changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<unit, #IFabComponentGeometry>, msg: unit -> unit) =
        this.AddScalar(ComponentGeometry.Changed.WithValue(msg))

type GeometryAttachedModifiers =
    /// <summary>Sets the Clip property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Clip value.</param>
    [<Extension>]
    static member inline clip(this: WidgetBuilder<unit, #IFabComponentVisual>, value: WidgetBuilder<unit, #IFabComponentGeometry>) =
        this.AddWidget(Visual.ClipWidget.WithValue(value.Compile()))
