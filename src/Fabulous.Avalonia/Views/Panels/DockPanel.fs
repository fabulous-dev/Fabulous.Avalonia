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

        static member DockPanel() =
            CollectionBuilder<'msg, IFabDockPanel, IFabControl>(DockPanel.WidgetKey, Panel.Children, DockPanel.LastChildFill.WithValue(true))

        static member DockPanel(lastChildFill: bool) =
            CollectionBuilder<'msg, IFabDockPanel, IFabControl>(DockPanel.WidgetKey, Panel.Children, DockPanel.LastChildFill.WithValue(lastChildFill))

[<Extension>]
type DockPanelModifiers =
    [<Extension>]
    static member inline dock(this: WidgetBuilder<'msg, #IFabControl>, value: Dock) =
        this.AddScalar(DockPanel.Dock.WithValue(value))

    /// <summary>Link a ViewRef to access the direct DockPanel control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDockPanel>, value: ViewRef<DockPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
