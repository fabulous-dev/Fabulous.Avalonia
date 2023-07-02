namespace Fabulous.Avalonia

open System
open Android.App
open Avalonia

[<AbstractClass>]
type FabSplashActivity() =
    inherit Activity()

    abstract member CreateApp: unit -> Application

    override this.OnResume() =
        base.OnResume()
        if Application.Current <> null then
            AppBuilder
                .Configure(Func<_>(this.CreateApp))
                .UseAndroid()
                .SetupWithoutStarting()
            |> ignore
