namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

module Geometry =

    let Transform = Attributes.defineAvaloniaPropertyWidget Geometry.TransformProperty

    let Changed =
        Attributes.defineEventNoArg "Geometry_Changed" (fun target -> (target :?> Geometry).Changed)

[<Extension>]
type GeometryModifiers =
    /// <summary>Sets the Transform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TileMode value.</param>
    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabGeometry>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Geometry.Transform.WithValue(value.Compile()))

    /// <summary>Listens to the Geometry Changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the geometry changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabGeometry>, msg: 'msg) =
        this.AddScalar(Geometry.Changed.WithValue(MsgValue msg))
