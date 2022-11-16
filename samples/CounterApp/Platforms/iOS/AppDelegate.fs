namespace CounterApp.iOS

open Foundation
open Avalonia
open Avalonia.iOS

open Fabulous.Avalonia

open CounterApp

// The UIApplicationDelegate for the application. This class is responsible for launching the 
// User Interface of the application, as well as listening (and optionally responding) to 
// application events from iOS.
type [<Register("AppDelegate")>] AppDelegate() =
    inherit FabulousAvaloniaAppDelegate<App.Model, App.Msg>()

    override this.FabulousApp = App.program