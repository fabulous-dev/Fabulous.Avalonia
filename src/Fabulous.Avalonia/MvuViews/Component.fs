namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module MvuComponentBuilders =
    type Fabulous.Avalonia.Mvu.View with

        static member Component<'msg, 'marker>() = ComponentBuilder<'msg>()

        static member Component<'msg, 'model, 'marker, 'parentMsg>(program: Program<unit, 'model, 'msg>) =
            MvuComponentBuilder<unit, 'msg, 'model, 'marker, 'parentMsg>(program, ())

        static member Component<'arg, 'msg, 'model, 'marker, 'parentMsg>(program: Program<'arg, 'model, 'msg>, arg: 'arg) =
            MvuComponentBuilder<'arg, 'msg, 'model, 'marker, 'parentMsg>(program, arg)