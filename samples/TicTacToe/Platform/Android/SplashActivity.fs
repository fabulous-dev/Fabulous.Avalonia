namespace TicTacToe

open Android.App
open Android.Content
open Avalonia
open Avalonia.Android
open Fabulous.Avalonia

[<Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)>]
type SplashActivity() =
    inherit AvaloniaSplashActivity()

    override this.CreateAppBuilder() =
        AppBuilder
            .Configure(fun () -> Program.startApplication App.program)
            .UseAndroid()

    override this.OnResume() =
        base.OnResume()
        this.StartActivity(new Intent(Application.Context, typeof<MainActivity>))
