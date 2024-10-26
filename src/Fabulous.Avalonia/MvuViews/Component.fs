namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module MvuComponentBuilders =
    type Fabulous.Avalonia.Mvu.View with

        static member Component<'msg, 'marker when 'msg: equality>(key) = ComponentBuilder<unit>(key)

        static member Component<'msg, 'model, 'marker, 'parentMsg when 'msg: equality and 'parentMsg: equality>(key: string, program: Program<unit, 'model, 'msg>) =
            MvuComponentBuilder<unit, 'msg, 'model, 'marker, 'parentMsg>(key, program, ())

        static member Component<'arg, 'msg, 'model, 'marker, 'parentMsg when 'msg: equality and 'parentMsg: equality>(key: string, program: Program<'arg, 'model, 'msg>, arg: 'arg) =
            MvuComponentBuilder<'arg, 'msg, 'model, 'marker, 'parentMsg>(key, program, arg)