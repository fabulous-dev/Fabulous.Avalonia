namespace Tetris.iOS

open Avalonia.Themes.Fluent
open Foundation
open Fabulous.Avalonia
open Tetris

[<Register(nameof SceneDelegate)>]
type SceneDelegate() =
    inherit FabSceneDelegate()

    override this.CreateApp() = Program.startApplication App.program

    override this.AfterSetup() =
        FabApplication.Current.AppTheme <- FluentTheme()