namespace Fabulous.Avalonia

open System
open UIKit
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.iOS

type SingleViewLifetime() =
    member val View: AvaloniaView = null with get, set

    interface ISingleViewApplicationLifetime with
        member this.MainView
            with get () = this.View.Content
            and set value =
                if this.View <> null then
                    this.View.Content <- value

[<AbstractClass>]
type FabSceneDelegate() =
    inherit UIWindowSceneDelegate()

    override val Window = null with get, set

    abstract member CreateApp: unit -> FabApplication

    override this.WillConnect(scene: UIScene, _: UISceneSession, _: UISceneConnectionOptions) =
        let scene = scene :?> UIWindowScene

        let lifetime = SingleViewLifetime()

        AppBuilder
            .Configure<FabApplication>(Func<_>(this.CreateApp))
            .UseiOS()
            .AfterSetup(fun _ ->
                let view = new AvaloniaView()
                lifetime.View <- view

                let win = new UIWindow(scene.CoordinateSpace.Bounds, WindowScene = scene)
                let controller = new DefaultAvaloniaViewController(View = view)
                win.RootViewController <- controller
                view.InitWithController(controller)

                this.Window <- win
                this.Window.MakeKeyAndVisible())
            .SetupWithLifetime(lifetime)
        |> ignore


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
