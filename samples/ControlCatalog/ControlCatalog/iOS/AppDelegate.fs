namespace ControlCatalog.iOS

open Foundation
open Fabulous.Avalonia
open ControlCatalog

[<Register(nameof AppDelegate)>]
type AppDelegate() =
    inherit FabAppDelegate()

    override this.CreateApp() =
        Program.startApplication App.program