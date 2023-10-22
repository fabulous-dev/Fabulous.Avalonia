namespace NewApp.Browser

open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Avalonia.Themes.Fluent
open Fabulous.Avalonia
open NewApp


module Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        AppBuilder.Configure(fun () ->
            let app = Program.startApplication App.program
            app.Styles.Add(App.theme)
            app)

    [<EntryPoint>]
    let main argv =
        buildAvaloniaApp().StartBrowserAppAsync("out") |> ignore
        0
