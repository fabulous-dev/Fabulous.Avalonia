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


[<AutoOpen>]
module ComponentBuilders =
    type Fabulous.Avalonia.View with

        static member Component<'msg, 'marker when 'msg: equality>(key: string) = ComponentBuilder<'msg>(key)

        static member Component<'msg, 'model, 'marker, 'parentMsg when 'msg: equality and 'parentMsg: equality>
            (key: string, program: Program<unit, 'model, 'msg>)
            =
            MvuComponentBuilder<unit, 'msg, 'model, 'marker, 'parentMsg>(key, program, ())

        static member Component<'arg, 'msg, 'model, 'marker, 'parentMsg when 'msg: equality and 'parentMsg: equality>
            (key: string, program: Program<'arg, 'model, 'msg>, arg: 'arg)
            =
            MvuComponentBuilder<'arg, 'msg, 'model, 'marker, 'parentMsg>(key, program, arg)
