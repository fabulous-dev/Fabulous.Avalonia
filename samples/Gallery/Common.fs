namespace Gallery

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

type SampleProgram =
    { init: unit -> obj
      update: obj -> obj -> obj
      view: obj -> WidgetBuilder<obj, IFabControl> }

type Sample =
    { Name: string
      Description: string
      Program: SampleProgram }

module Helper =
    let createProgram (init: unit -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        { init = init >> box
          update = (fun msg model -> update (unbox msg) (unbox model) |> box)
          view = (fun model -> AnyView(View.map box (view(unbox model)))) }
