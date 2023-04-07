namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabTransform =
    inherit IFabAnimatable

module Transform =

    let Changed =
        Attributes.defineEventNoArg "Transform_Changed" (fun target -> (target :?> Transform).Changed)

[<Extension>]
type TransformModifiers =
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabTransform>, onChanged: 'msg) =
        this.AddScalar(Transform.Changed.WithValue(onChanged))
