namespace ControlCatalog

open System
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open ControlCatalog.Pages

open type Fabulous.Avalonia.View

module App =
    type Model =
        { Count: int }

    type Msg =
        | DoNothing

    let init () = { Count = 0 }

    let update (msg: Msg) (model: Model) =
        model

    let view model =
        Grid() {
            TabItem(
                "Buttons",
                ButtonsPage.view ()
            )
        }
            
// #if MOBILE
    let app model =
        SingleViewApplication(
            view model
        )
// #else
//     let app model =
//         DesktopApplication(
//             Window(
//                 view model
//             )
//         )
// #endif

    let program = Program.stateful init update app
