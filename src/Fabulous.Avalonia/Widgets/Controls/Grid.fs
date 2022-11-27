namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabGrid =
    inherit IFabPanel

module Grid =
    let WidgetKey = Widgets.register<Grid> ()

[<AutoOpen>]
module GridBuilders =
    type Fabulous.Avalonia.View with

        static member Grid<'msg>() =
            CollectionBuilder<'msg, IFabGrid, IFabControl>(Grid.WidgetKey, Panel.Children)
