namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabMvuTransform =
    inherit IFabMvuElement
    inherit IFabMvuAnimatable

module MvuTransform =

    let Changed =
        MvuAttributes.defineEventNoArg "Transform_Changed" (fun target -> (target :?> Transform).Changed)

type MvuTransformModifiers =
    /// <summary>Listens to the Transform changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Transform changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabMvuTransform>, fn: 'msg) =
        this.AddScalar(MvuTransform.Changed.WithValue(MsgValue fn))
