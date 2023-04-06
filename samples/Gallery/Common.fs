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
          update =
            (fun msg model ->
                if msg <> null && typeof<'msg>.IsAssignableFrom(msg.GetType()) then
                    update (unbox msg) (unbox model) |> box
                else
                    (unbox model) |> box)
          view = (fun model -> AnyView(View.map box (view(unbox model)))) }

module Paths =

    [<Literal>]
    let Path1 =
        "F1 M 16.6309,18.6563C 17.1309,8.15625 29.8809,14.1563 29.8809,14.1563C 30.8809,11.1563 34.1308,11.4063 34.1308,11.4063C 33.5,12 34.6309,13.1563 34.6309,13.1563C 32.1309,13.1562 31.1309,14.9062 31.1309,14.9062C 41.1309,23.9062 32.6309,27.9063 32.6309,27.9062C 24.6309,24.9063 21.1309,22.1562 16.6309,18.6563 Z M 16.6309,19.9063C 21.6309,24.1563 25.1309,26.1562 31.6309,28.6562C 31.6309,28.6562 26.3809,39.1562 18.3809,36.1563C 18.3809,36.1563 18,38 16.3809,36.9063C 15,36 16.3809,34.9063 16.3809,34.9063C 16.3809,34.9063 10.1309,30.9062 16.6309,19.9063 Z"

    [<Literal>]
    let Path2 =
        "M 272.70141,238.71731 C 206.46141,238.71731 152.70146,292.4773 152.70146,358.71731 C 152.70146,493.47282 288.63461,528.80461 381.26391,662.02535 C 468.83815,529.62199 609.82641,489.17075 609.82641,358.71731 C 609.82641,292.47731 556.06651,238.7173 489.82641,238.71731 C 441.77851,238.71731 400.42481,267.08774 381.26391,307.90481 C 362.10311,267.08773 320.74941,238.7173 272.70141,238.71731 z"
