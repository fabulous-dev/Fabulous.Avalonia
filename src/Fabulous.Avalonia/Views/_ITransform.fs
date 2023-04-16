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
    /// <summary>Listens to the Changed event of the current widget.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Message to send when the event is raised.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabTransform>, msg: 'msg) =
        this.AddScalar(Transform.Changed.WithValue(msg))
