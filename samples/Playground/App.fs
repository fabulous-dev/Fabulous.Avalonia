namespace Playground

open Avalonia.Controls
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

    let firstNameView (value: StateValue<string>) =
        Component() {
            let! firstName = Context.Binding(value)
            TextBox(firstName.Current, firstName.Set)
        }

    let lastNameView (value: StateValue<string>) =
        Component() {
            let! lastName = Context.Binding(value)
            TextBox(lastName.Current, lastName.Set)
        }

    let component2 () =
        Component() {
            let! firstName = Context.State("")
            let! lastName = Context.State("")

            VStack() {
                Label($"Full name is {firstName.Current} {lastName.Current}")
                firstNameView firstName
                lastNameView lastName
            }
        }

    let content () =
        Component() {
            Gallery.EditableTreeView.view()
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
