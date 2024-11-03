namespace Playground

open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent
open Fabulous.Avalonia.Components

open type Fabulous.Avalonia.View

module App =
    let firstNameView (value: StateValue<string>) =
        Component("firstNameView") {
            let! firstName = Context.Binding(value)
            TextBox(firstName.Current, firstName.Set)
        }

    let lastNameView (value: StateValue<string>) =
        Component("lastNameView") {
            let! lastName = Context.Binding(value)
            TextBox(lastName.Current, lastName.Set)
        }

    let content () =
        Component("content") {
            let! firstName = Context.State("")
            let! lastName = Context.State("")

            VStack() {
                Label($"Full name is {firstName.Current} {lastName.Current}")
                firstNameView firstName
                lastNameView lastName
            }
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
