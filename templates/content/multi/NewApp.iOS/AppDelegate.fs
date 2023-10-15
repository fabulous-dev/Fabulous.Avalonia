namespace NewApp.iOS

open Fabulous.Avalonia
open Foundation
open MyApp
open UIKit

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit FabAppDelegate()

    override this.CreateApp() = Program.startApplication App.program

module Main =
    [<EntryPoint>]
    let main (args: string array) =
        UIApplication.Main(args, null, typeof<AppDelegate>)
        0
