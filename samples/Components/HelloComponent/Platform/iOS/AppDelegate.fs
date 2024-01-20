namespace HelloComponent.iOS

open Foundation
open UIKit

[<Register(nameof AppDelegate)>]
type AppDelegate() =
    inherit UIResponder()

    interface IUIApplicationDelegate

    [<Export("application:didFinishLaunchingWithOptions:")>]
    member this.FinishedLaunching(_: UIApplication, _: NSDictionary) : bool = true

    [<Export("application:configurationForConnectingSceneSession:options:")>]
    member this.GetConfiguration(_: UIApplication, sceneSession: UISceneSession, _: UISceneConnectionOptions) =
        UISceneConfiguration.Create("Default Configuration", sceneSession.Role)

module Main =
    [<EntryPoint>]
    let main (args: string array) =
        UIApplication.Main(args, null, typeof<AppDelegate>)
        0
