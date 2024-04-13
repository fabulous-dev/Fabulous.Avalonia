namespace Playground

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

module App =
    type Model = { Count: int }

    type Msg =
        | Increment
        | Decrement

    let initModel = { Count = 0 }

    let init () = initModel

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let program = Program.stateful init update

    let component1 () =
        Component(program) {
            let! model = Mvu.State

            (VStack() {
                TextBlock($"%d{model.Count}").centerText()

                Button("Increment", Increment).centerHorizontal()

                Button("Decrement", Decrement).centerHorizontal()

            })
                .center()
        }


    let content () =
        Component() {
            (Dock() {
                (HStack() { TextBlock("Counter").centerVertical() })
                    .margin(20.)
                    .centerHorizontal()

                component1().dock(Dock.Bottom)

            })
                .center()

        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
