namespace TicTacToe.Android

open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.Android
open Avalonia.Themes.Fluent
open Fabulous.Avalonia
open TicTacToe

[<Activity(Label = "TicTacToe.Android",
           Theme = "@style/MyTheme.NoActionBar",
           Icon = "@drawable/icon",
           LaunchMode = LaunchMode.SingleTop,
           ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaMainActivity<FabApplication>()

    override this.CustomizeAppBuilder(_builder: AppBuilder) =
        AppBuilder
            .Configure(fun () ->
                let app = Program.startApplication App.program
                app.Styles.Add(App.theme)
                app)
            .UseAndroid()
