namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabGeometry =
    inherit IFabElement

module Geometry =

    let Transform = Attributes.defineAvaloniaPropertyWidget Geometry.TransformProperty

    let Changed =
        Attributes.defineEventNoArg "Geometry_Changed" (fun target -> (target :?> Geometry).Changed)

[<Extension>]
type GeometryModifiers =
    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabGeometry>, content: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Geometry.Transform.WithValue(content.Compile()))

    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabGeometry>, onChanged: 'msg) =
        this.AddScalar(Geometry.Changed.WithValue(onChanged))
