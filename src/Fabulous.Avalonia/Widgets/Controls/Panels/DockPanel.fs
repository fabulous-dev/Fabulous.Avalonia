namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabDockPanel =
    inherit IFabPanel

module DockPanel =
    let WidgetKey = Widgets.register<DockPanel> ()

    let Dock = Attributes.defineAvaloniaPropertyWithEquality DockPanel.DockProperty

    let LastChildFill =
        Attributes.defineAvaloniaPropertyWithEquality DockPanel.LastChildFillProperty

[<AutoOpen>]
module DockPanelBuilders =
    type Fabulous.Avalonia.View with

        static member Dock<'msg>(dock: Dock, ?lastChildFill: bool) =
            CollectionBuilder<'msg, IFabDockPanel, IFabControl>(
                DockPanel.WidgetKey,
                Panel.Children,
                DockPanel.Dock.WithValue(dock),
                DockPanel.LastChildFill.WithValue(lastChildFill |> Option.defaultValue true)
            )
