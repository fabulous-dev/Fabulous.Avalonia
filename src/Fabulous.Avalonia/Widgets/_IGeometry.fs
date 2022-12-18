namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabGeometry =
    inherit IFabControl

module Geometry =

    let Transform = Attributes.defineAvaloniaPropertyWidget Geometry.TransformProperty

[<Extension>]
type GeometryModifiers =
    [<Extension>]
    static member inline transform
        (
            this: WidgetBuilder<'msg, #IFabGeometry>,
            content: WidgetBuilder<'msg, #IFabTransform>
        ) =
        this.AddWidget(Geometry.Transform.WithValue(content.Compile()))
