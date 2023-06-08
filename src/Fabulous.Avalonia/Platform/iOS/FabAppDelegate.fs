namespace Fabulous.Avalonia

open System
open Avalonia
open Foundation
open UIKit

open Avalonia.Controls.ApplicationLifetimes
open Avalonia.iOS


type SingleViewLifetime() =
    member val View: AvaloniaView = null with get, set

    interface ISingleViewApplicationLifetime with
        member this.MainView
            with get () = this.View.Content
            and set (value) =
                if this.View <> null then
                    this.View.Content <- value

[<AbstractClass>]
type FabAppDelegate() =
    inherit UIResponder()
    interface IUIApplicationDelegate

    [<Export("window")>]
    member val Window: UIWindow = null with get, set

    abstract member CreateApp: unit -> Application

    [<Export("application:didFinishLaunchingWithOptions:")>]
    member this.FinishedLaunching(_: UIApplication, _: NSDictionary) =
        let builder =
            AppBuilder
                .Configure<Application>(Func<_>(this.CreateApp))
                .UseiOS()

        let lifetime = SingleViewLifetime()

        builder.AfterSetup(fun _ ->
            this.Window <- new UIWindow()

            let view = new AvaloniaView()
            lifetime.View <- view
            this.Window.RootViewController <- new UIViewController(View = view))
        |> ignore

        builder.SetupWithLifetime(lifetime) |> ignore

        this.Window.MakeKeyAndVisible()

        true
