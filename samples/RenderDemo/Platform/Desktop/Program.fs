namespace RenderDemo.Desktop

open System
open Avalonia
open RenderDemo

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () = MainWindow.create().UsePlatformDetect()

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
