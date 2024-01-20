namespace HelloComponent.Desktop

open System
open Avalonia
open Fabulous.Avalonia
open HelloComponent

module Program =
    [<EntryPoint; STAThread>]
    let main argv =
        AppBuilder
            .UseFabulousApp(App.view, App.theme)
            .StartWithClassicDesktopLifetime(argv)
