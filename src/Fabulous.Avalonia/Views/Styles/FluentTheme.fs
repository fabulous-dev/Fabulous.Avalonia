namespace Fabulous.Avalonia

open System
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabFluentTheme = inherit IFabStyle

module FluentTheme =
    let WidgetKey = Widgets.registerWithFactory<FluentTheme>(fun () -> FluentTheme(baseUri = null))
    let Mode = Attributes.defineStyledWithEquality FluentTheme.ModeProperty
    
[<AutoOpen>]
module FluentThemeBuilders =
    type Fabulous.Avalonia.View with
        static member inline FluentTheme<'msg>(mode: FluentThemeMode) =
            WidgetBuilder<'msg, IFabFluentTheme>(
                FluentTheme.WidgetKey,
                FluentTheme.Mode.WithValue(mode)
            )
