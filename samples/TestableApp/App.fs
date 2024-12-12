namespace TestableApp

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open type Fabulous.Context

module App =
    let firstNameView (value: StateValue<string>) =
        Component("firstNameView") {
            let! firstName = Binding(value)
            TextBox(firstName.Current, firstName.Set).name("firstName")
        }

    let lastNameView (value: StateValue<string>) =
        Component("lastNameView") {
            let! lastName = Binding(value)
            TextBox(lastName.Current, lastName.Set)
        }

    let content () =
        Component("content") {
            let! firstName = State("")
            let! lastName = State("")

            VStack() {
                Label($"Full name is {firstName.Current} {lastName.Current}")
                firstNameView firstName
                lastNameView lastName
            }
        }

    let view () = Window(content())
