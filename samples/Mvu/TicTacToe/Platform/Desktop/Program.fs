namespace TicTacToe.Desktop

open System
open Avalonia

open TicTacToe

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        App
            .create()
            .UsePlatformDetect()
            .LogToTrace(areas = Array.empty)

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
