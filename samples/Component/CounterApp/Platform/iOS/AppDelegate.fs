namespace CounterApp.iOS

open Foundation
open UIKit

open Avalonia
open CounterApp

open Avalonia.iOS
open Fabulous.Avalonia

[<Register(nameof AppDelegate)>]
type AppDelegate() =
    inherit AvaloniaAppDelegate<FabApplication>()
    override this.CreateAppBuilder() = App.create().UseiOS()

module Main =
    [<EntryPoint>]
    let main (args: string array) =
        UIApplication.Main(args, null, typeof<AppDelegate>)
        0
