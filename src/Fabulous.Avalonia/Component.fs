namespace Fabulous.Avalonia

open Avalonia
open Fabulous

module Component =
    let ComponentProperty =
        StyledProperty.RegisterAttached<Component, AvaloniaObject, obj>("Component")

    let get (target: obj) =
        (target :?> AvaloniaObject).GetValue(ComponentProperty)

    let set (comp: obj) (target: obj) =
        (target :?> AvaloniaObject)
            .SetValue(ComponentProperty, comp)
        |> ignore
