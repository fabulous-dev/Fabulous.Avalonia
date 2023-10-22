namespace RenderDemo.iOS

open Foundation
open Fabulous.Avalonia
open RenderDemo

[<Register(nameof SceneDelegate)>]
type SceneDelegate() =
    inherit FabSceneDelegate()

    override this.CreateApp() =
        let app = Program.startApplication App.program
        app.Styles.Add(App.theme)
        app
