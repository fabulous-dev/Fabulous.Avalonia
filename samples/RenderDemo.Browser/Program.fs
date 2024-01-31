namespace RenderDemo.Browser

open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Avalonia.Themes.Fluent
open Fabulous.Avalonia
open RenderDemo


module Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () = MainView.create()

    [<EntryPoint>]
    let main argv =
        buildAvaloniaApp().StartBrowserAppAsync("out") |> ignore
        0
