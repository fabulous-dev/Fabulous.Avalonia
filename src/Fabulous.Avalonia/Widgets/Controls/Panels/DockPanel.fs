namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabDockPanel =
    inherit IFabPanel

module DockPanel =
    let WidgetKey = Widgets.register<DockPanel>()

    let Dock = Attributes.defineAvaloniaPropertyWithEquality DockPanel.DockProperty

    let LastChildFill =
        Attributes.defineAvaloniaPropertyWithEquality DockPanel.LastChildFillProperty

[<AutoOpen>]
module DockPanelBuilders =
    type Fabulous.Avalonia.View with

        static member Dock() =
            CollectionBuilder<'msg, IFabDockPanel, IFabControl>(DockPanel.WidgetKey, Panel.Children, DockPanel.LastChildFill.WithValue(true))

        static member Dock(lastChildFill: bool) =
            CollectionBuilder<'msg, IFabDockPanel, IFabControl>(DockPanel.WidgetKey, Panel.Children, DockPanel.LastChildFill.WithValue(lastChildFill))

[<Extension>]
type DockPanelModifiers =
    [<Extension>]
    static member inline dock(this: WidgetBuilder<'msg, #IFabControl>, value: Dock) =
        this.AddScalar(DockPanel.Dock.WithValue(value))
