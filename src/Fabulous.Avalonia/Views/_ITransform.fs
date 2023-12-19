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
    /// <summary>Listens to the Transform changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Transform changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabTransform>, fn: 'msg) =
        this.AddScalar(Transform.Changed.WithValue(MsgValue fn))
