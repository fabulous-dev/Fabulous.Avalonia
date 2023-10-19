namespace NewApp

open System
open Avalonia
open Avalonia.Themes.Fluent

open NewApp
open Fabulous.Avalonia

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        AppBuilder
            .Configure(fun () -> Program.startApplication App.program)
            .LogToTrace(areas = Array.empty)
            .UsePlatformDetect()
            .AfterSetup(fun _ -> FabApplication.Current.AppTheme <- FluentTheme())

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
