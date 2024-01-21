namespace HelloComponent.Desktop

open System
open Avalonia
open HelloComponent

module Program =
    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () = App.create().UsePlatformDetect()

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
