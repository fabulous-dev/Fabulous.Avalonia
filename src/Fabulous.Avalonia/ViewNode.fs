namespace Fabulous.Avalonia

open Fabulous
open Avalonia

module ViewNode =
    let ViewNodeProperty =
        StyledProperty.RegisterAttached<ViewNode, AvaloniaObject, IViewNode>("ViewNode")

    /// Gets the view node associated with the specified object.
    let get (target: obj) =
        (target :?> AvaloniaObject).GetValue(ViewNodeProperty)

    /// Sets the view node associated with the specified object.
    let set (node: IViewNode) (target: obj) =
        (target :?> AvaloniaObject).SetValue(ViewNodeProperty, node) |> ignore
