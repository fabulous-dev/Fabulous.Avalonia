namespace Playground

open System
open System.IO
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Themes.Fluent
open AsyncImageLoader
open Fabulous
open Fabulous.Avalonia

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
        Component("content") {
            let! firstName = State("")
            let! lastName = State("")

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
        DesktopApplication(
            Window(content())
#if DEBUG
                .attachDevTools()
#endif
        )
#endif


    let create () =
        // see https://github.com/AvaloniaUtils/AsyncImageLoader.Avalonia?tab=readme-ov-file#loaders
        ImageLoader.AsyncImageLoader.Dispose()
        let imageCacheFolder = Path.Combine(Environment.CurrentDirectory, "async images")
        ImageLoader.AsyncImageLoader <- new Loaders.DiskCachedWebImageLoader(imageCacheFolder)

        FabulousAppBuilder.Configure(FluentTheme, view)
