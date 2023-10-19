namespace Gallery.Android

open System
open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.Android
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open Gallery

[<Activity(Label = "Gallery.Android",
           Theme = "@style/MyTheme.NoActionBar",
           Icon = "@drawable/icon",
           ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaMainActivity<FabApplication>()

    override this.CustomizeAppBuilder(_builder: AppBuilder) =
        AppBuilder
            .Configure(fun () -> Program.startApplication App.program)
            .UseAndroid()
            .AfterSetup(fun _ ->
                let theme = StyleInclude(baseUri = null)
                theme.Source <- Uri("avares://Gallery/App.xaml")
                FabApplication.Current.Styles.Add(theme))
