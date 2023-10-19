namespace Gallery.iOS

open System
open Avalonia.Markup.Xaml.Styling
open Foundation
open Fabulous.Avalonia
open Gallery

[<Register(nameof SceneDelegate)>]
type SceneDelegate() =
    inherit FabSceneDelegate()

    override this.CreateApp() = Program.startApplication App.program

    override this.AfterSetup() =
        let theme = StyleInclude(baseUri = null)
        theme.Source <- Uri("avares://Gallery/App.xaml")
        FabApplication.Current.Styles.Add(theme)
