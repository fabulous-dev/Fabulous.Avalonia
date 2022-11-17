namespace Fabulous.Avalonia

open System
open Avalonia
open Avalonia.Android

[<AbstractClass>]
type FabSplashActivity() =
    inherit AvaloniaSplashActivity()
    
    abstract member CreateApp: unit -> Application
    
    override this.CreateAppBuilder() =
        AppBuilder
            .Configure(Func<_>(this.CreateApp))
            .UseAndroid()