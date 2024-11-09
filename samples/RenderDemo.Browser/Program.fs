namespace RenderDemo.Browser

open System.Diagnostics
open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Avalonia.Logging
open RenderDemo


module Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () = MainView.create()

    [<EntryPoint>]
    let main argv =
        Trace.Listeners.Add(new ConsoleTraceListener()) |> ignore

        buildAvaloniaApp()
            .LogToTrace(LogEventLevel.Warning)
            .StartBrowserAppAsync("out", BrowserPlatformOptions())
        |> ignore

        0
