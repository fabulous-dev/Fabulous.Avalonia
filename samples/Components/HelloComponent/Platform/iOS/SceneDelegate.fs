namespace HelloComponent.iOS

open Foundation
open Fabulous.Avalonia
open HelloComponent
open UIKit

[<Register(nameof SceneDelegate)>]
type SceneDelegate() =
    inherit UIWindowSceneDelegate()

    override this.WillConnect(scene: UIScene, _: UISceneSession, _: UISceneConnectionOptions) =
        App.create().UseiOS(this, scene :?> UIWindowScene) |> ignore

    /// Called as the scene is being released by the system.
    /// This occurs shortly after the scene enters the background, or when its session is discarded.
    /// Release any resources associated with this scene that can be re-created the next time the scene connects.
    /// The scene may re-connect later, as its session was not necessarily discarded (see UIApplicationDelegate `DidDiscardSceneSessions` instead).
    override _.DidDisconnect(_: UIScene) = ()

    /// Called when the scene has moved from an inactive state to an active state.
    /// Use this method to restart any tasks that were paused (or not yet started) when the scene was inactive.
    override _.DidBecomeActive(_: UIScene) = ()

    /// Called when the scene will move from an active state to an inactive state.
    /// This may occur due to temporary interruptions (ex. an incoming phone call).
    override _.WillResignActive(_: UIScene) = ()

    /// Called as the scene transitions from the background to the foreground.
    /// Use this method to undo the changes made on entering the background.
    override _.WillEnterForeground(_: UIScene) = ()

    /// Called as the scene transitions from the foreground to the background.
    /// Use this method to save data, release shared resources, and store enough scene-specific state information
    /// to restore the scene back to its current state.
    override _.DidEnterBackground(_: UIScene) = ()
