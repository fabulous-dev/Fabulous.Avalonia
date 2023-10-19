namespace RenderDemo.Android

open System
open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.Android
open Avalonia.Markup.Xaml.Styling
open RenderDemo
open Fabulous.Avalonia

[<Activity(Label = "Counter.Android",
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
            .AfterSetup(fun _ ->
                let theme = StyleInclude(baseUri = null)
                theme.Source <- Uri("avares://RenderDemo/App.xaml")
                FabApplication.Current.Styles.Add(theme))
