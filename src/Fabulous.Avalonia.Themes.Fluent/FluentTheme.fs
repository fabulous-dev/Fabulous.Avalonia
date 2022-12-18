namespace Fabulous.Avalonia.Themes.Fluent

open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia

type IFabFluentTheme =
    inherit IFabStyle

module FluentTheme =
    let WidgetKey =
        Widgets.registerWithFactory<FluentTheme>(fun () -> FluentTheme(baseUri = null))

    let Mode = Attributes.defineAvaloniaPropertyWithEquality FluentTheme.ModeProperty

[<AutoOpen>]
module FluentThemeBuilders =
    type Fabulous.Avalonia.View with

        static member inline FluentTheme<'msg>(mode: FluentThemeMode) =
            WidgetBuilder<'msg, IFabFluentTheme>(FluentTheme.WidgetKey, FluentTheme.Mode.WithValue(mode))
