namespace Gallery.Desktop

open System
open Avalonia

open Avalonia.Markup.Xaml.Styling
open Gallery
open Fabulous.Avalonia

module Program =

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        AppBuilder
            .Configure(fun () -> Program.startApplication App.program)
            .LogToTrace(areas = Array.empty)
            .UsePlatformDetect()
            .AfterSetup(fun _ ->
                let theme = StyleInclude(baseUri = null)
                theme.Source <- Uri("avares://Gallery/App.xaml")
                FabApplication.Current.Styles.Add(theme))

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
