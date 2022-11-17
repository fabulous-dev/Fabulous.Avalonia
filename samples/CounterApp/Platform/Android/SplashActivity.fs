namespace CounterApp.Android

open Android.App
open Android.Content
open CounterApp
open Fabulous.Avalonia

[<Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)>]
type SplashActivity() =
    inherit FabSplashActivity()
    
    override this.CreateApp() =
        Program.startApplication App.program

    override this.OnResume() =
        base.OnResume()
        this.StartActivity(new Intent(Application.Context, typeof<MainActivity>))