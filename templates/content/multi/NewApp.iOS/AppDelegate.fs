namespace NewApp.iOS

open Foundation
open UIKit
open Avalonia
open Avalonia.Controls
open Avalonia.iOS
open Avalonia.Media

// The UIApplicationDelegate for the application. This class is responsible for launching the
// User Interface of the application, as well as listening (and optionally responding) to
// application events from iOS.
[<Register("AppDelegate")>]
type AppDelegate() =
    inherit AvaloniaAppDelegate<NewApp.App>()
