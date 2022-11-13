namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Themes.Fluent
open Foundation
open UIKit

open Avalonia.Controls.ApplicationLifetimes
open Avalonia.iOS

open Fabulous

type SingleViewLifetime() =
    member val View: AvaloniaView = null with get, set
    
    interface ISingleViewApplicationLifetime with
        member this.MainView
            with get() = this.View.Content
            and set(value) = this.View.Content <- value

[<AbstractClass>]
type FabulousAvaloniaAppDelegate<'model, 'msg>() =
    inherit UIResponder()
    interface IUIApplicationDelegate
    
    [<Export("window")>]
    member val Window: UIWindow = null with get, set
    
    abstract member CustomizeAppBuilder: AppBuilder -> AppBuilder
    default this.CustomizeAppBuilder(appBuilder) = appBuilder
    
    abstract member FabulousApp: Program<unit, 'model, 'msg, IFabApplication>
    
    [<Export("application:didFinishLaunchingWithOptions:")>]
    member this.FinishedLaunching(application: UIApplication, launchOptions: NSDictionary) =
        let builder =
            AppBuilder
                .Configure<Application>(fun () -> Program.startApplication this.FabulousApp)
                .UseiOS()
                
        let lifetime = SingleViewLifetime()
        
        builder.AfterSetup(fun _ ->
            this.Window <- new UIWindow()
            
            let view = new AvaloniaView()
            lifetime.View <- view
            this.Window.RootViewController <- new UIViewController(View = view)
        ) |> ignore
        
        builder.SetupWithLifetime(lifetime) |> ignore
        
        this.Window.MakeKeyAndVisible()
        
        true
