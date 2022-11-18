namespace CounterApp.Android

open Android.App
open Android.Content.PM
open Avalonia.Android

[<Activity(
    Label = "ControlCatalog.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize)
)>]
type MainActivity() =
    inherit AvaloniaMainActivity()