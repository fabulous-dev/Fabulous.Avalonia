namespace TicTacToe.Browser

open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Fabulous.Avalonia
open TicTacToe

module public Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">]
    let public buildAvaloniaApp () =
        AppBuilder.Configure(fun () -> Program.startApplication App.program)

    [<EntryPoint>]
    let main argv =
        buildAvaloniaApp().StartBrowserAppAsync("out") |> ignore
        0
