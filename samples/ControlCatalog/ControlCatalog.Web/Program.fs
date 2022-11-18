namespace ControlCatalog.Web

open System.Runtime.Versioning
open Avalonia
open Avalonia.Web
open ControlCatalog
open Fabulous.Avalonia

[<assembly: SupportedOSPlatform("browser")>]
do ()

module Program =
    let main _args =
        AppBuilder
            .Configure(fun () -> Program.startApplication App.program)
            .SetupBrowserApp("out")