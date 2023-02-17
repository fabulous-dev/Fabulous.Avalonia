namespace Fabulous.Avalonia.Themes.Fluent

open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia

type IFabFluentTheme =
    inherit IFabStyle

module FluentTheme =
    let WidgetKey =
        Widgets.registerWithFactory<FluentTheme>(fun () -> FluentTheme(null))

    let DensityStyle =
        Attributes.defineAvaloniaPropertyWithEquality FluentTheme.DensityStyleProperty

[<AutoOpen>]
module FluentThemeBuilders =
    type Fabulous.Avalonia.View with

        static member inline FluentTheme<'msg>(density: DensityStyle) =
            WidgetBuilder<'msg, IFabFluentTheme>(FluentTheme.WidgetKey, FluentTheme.DensityStyle.WithValue(density))
