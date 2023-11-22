namespace TicTacToe.Desktop

open System
open Avalonia

open Avalonia.Themes.Fluent
open TicTacToe
open Fabulous.Avalonia

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        AppBuilder
            .Configure(fun () ->
                let app = Program.startApplication App.program
                app.Styles.Add(App.theme)
                app)
            .LogToTrace(areas = Array.empty)
            .UsePlatformDetect()

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
