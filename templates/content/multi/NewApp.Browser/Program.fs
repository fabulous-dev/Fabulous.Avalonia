namespace NewApp.Browser

open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Fabulous.Avalonia
open NewApp


module Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () = AppBuilder.Configure(fun () -> Program.startApplication App.program)

    [<EntryPoint>]
    let main argv =
        buildAvaloniaApp().StartBrowserAppAsync("out") |> ignore
        0