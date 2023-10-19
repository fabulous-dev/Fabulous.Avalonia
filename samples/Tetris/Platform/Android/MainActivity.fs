namespace Tetris.Android

open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.Android
open Avalonia.Themes.Fluent
open Tetris
open Fabulous.Avalonia

[<Activity(Label = "Tetris.Android",
           Theme = "@style/MyTheme.NoActionBar",
           Icon = "@drawable/icon",
           LaunchMode = LaunchMode.SingleTop,
           ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaMainActivity<FabApplication>()

    override this.CustomizeAppBuilder(_builder: AppBuilder) =
        AppBuilder
            .Configure(fun () -> Program.startApplication App.program)
            .UseAndroid()
            .AfterSetup(fun _ -> FabApplication.Current.AppTheme <- FluentTheme())
