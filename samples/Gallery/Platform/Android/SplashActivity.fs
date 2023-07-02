namespace Gallery.Android

open Android.App
open Android.Content
open Avalonia
open Avalonia.Android
open Fabulous.Avalonia
open Gallery

[<Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)>]
type SplashActivity() =
    inherit Activity() 

    override this.OnResume() =
        base.OnResume()
        this.StartActivity(new Intent(Application.Context, typeof<MainActivity>))
