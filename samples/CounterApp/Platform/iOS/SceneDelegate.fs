namespace CounterApp.iOS

open Avalonia.Themes.Fluent
open Foundation
open Fabulous.Avalonia
open CounterApp

[<Register(nameof SceneDelegate)>]
type SceneDelegate() =
    inherit FabSceneDelegate()

    override this.CreateApp() =
        let app = Program.startApplication App.program
        app.Styles.Add(App.theme)
        app
