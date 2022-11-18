namespace ControlCatalog.Web

open System.Runtime.Versioning
open Avalonia
open Avalonia.Web
open ControlCatalog

[<assembly:SupportedOSPlatform("browser")>]
type Program() =
    static member BuildAvaloniaApp() =
        AppBuilder.Configure<App>()
           
    static member Main(args: string array) =
        BuildAvaloniaApp()
            .SetupBrowserApp("out")