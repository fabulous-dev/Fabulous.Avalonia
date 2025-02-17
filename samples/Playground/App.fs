namespace Playground

open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View
open type Fabulous.Context

module App =
    let firstNameView (value: StateValue<string>) =
        Component("firstNameView") {
            let! firstName = Binding(value)
            TextBox(firstName.Current, firstName.Set)
        }

    let lastNameView (value: StateValue<string>) =
        Component("lastNameView") {
            let! lastName = Binding(value)
            TextBox(lastName.Current, lastName.Set)
        }

    let content () =
        Component("content1") {
            let app = FabApplication.Current

            VStack() {
                Label("Window 1")

                Button("Open", fun _ -> app.ShowWindow("window2"))
            }
        }

    let content2 () =
        Component("content2") {
            let app = FabApplication.Current

            VStack() {

                Label("Window 2")

                Button("Open", fun _ -> app.CloseWindow("window1"))
            }
        }


    let window1 () = Window(content()).windowId("window1")

    let window2 () = Window(content2()).windowId("window2")

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() {
            window1()
            window2()
        }
#endif


    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
