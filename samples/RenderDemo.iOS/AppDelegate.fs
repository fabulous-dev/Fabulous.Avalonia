namespace RenderDemo.iOS

open Avalonia
open Avalonia.iOS
open Fabulous.Avalonia
open Foundation
open RenderDemo
open UIKit

[<Register(nameof AppDelegate)>]
type AppDelegate() =
    inherit AvaloniaAppDelegate<FabApplication>()
    override this.CreateAppBuilder() = MainView.create().UseiOS()

module Main =
    [<EntryPoint>]
    let main (args: string array) =
        UIApplication.Main(args, null, typeof<AppDelegate>)
        0
