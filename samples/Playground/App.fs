namespace Playground

open Avalonia.Controls
open Avalonia.Media
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia

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
            (Dock() {
                // from https://knowyourmeme.com/photos/295268-dont-worry-im-from-the-internet
                AsyncImage("https://i.kym-cdn.com/photos/images/original/000/295/268/642.jpg")
                    .height(420) // generic extensions work
                    .stretchDirection(StretchDirection.Both) // image extensions work

                (HStack() { TextBlock("Counter").centerVertical() })
                    .margin(20.)
                    .centerHorizontal()

                component1().dock(Dock.Bottom)

                component2().dock(Dock.Bottom)

            })
                .center()
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif

#if DEBUG
            .attachDevTools()
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
