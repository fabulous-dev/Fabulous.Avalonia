namespace Fabulous.Avalonia

open Fabulous
open Avalonia

module ViewNode =
    let ViewNodeProperty =
        StyledProperty.RegisterAttached<ViewNode, AvaloniaObject, IViewNode>("ViewNode")

    let get (target: obj) =
        (target :?> AvaloniaObject).GetValue(ViewNodeProperty)

    let set (node: IViewNode) (target: obj) =
        (target :?> AvaloniaObject).SetValue(ViewNodeProperty, node) |> ignore
