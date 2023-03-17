namespace GameOfLife.Browser

open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Fabulous.Avalonia
open GameOfLife

module public Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">] 
    let public buildAvaloniaApp () = 
        AppBuilder
            .Configure(fun () -> Program.startApplication App.program)

    [<EntryPoint>]
    let main argv =
        buildAvaloniaApp()
            .SetupBrowserApp("out")
            |> ignore
        0
