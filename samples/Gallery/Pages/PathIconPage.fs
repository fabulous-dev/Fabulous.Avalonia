namespace Gallery.Pages

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PathIconPage =
    type Model = { Nothing: bool }

    type Msg = | DoNothing

    let init () = { Nothing = true }

    let update msg model =
        match msg with
        | DoNothing -> model

    let view _ =
        VStack(spacing = 15.) {
            PathIcon("M 10,100 L 100,100 100,50Z").size(100., 100.)

            PathIcon("M13.908992,16.207977L32.000049,16.207977 32.000049,31.999985 13.908992,30.109983z")
                .size(100., 100.)
        }
