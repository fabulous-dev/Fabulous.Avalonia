namespace Fabulous.Avalonia

open Fabulous
open Avalonia

module ViewNode =
    let ViewNodeProperty =
        StyledProperty.RegisterAttached<ViewNode, IAvaloniaObject, IViewNode>("ViewNode")

    let get (target: obj) =
        (target :?> IAvaloniaObject).GetValue(ViewNodeProperty)

    let set (node: IViewNode) (target: obj) =
        (target :?> IAvaloniaObject).SetValue(ViewNodeProperty, node) |> ignore
