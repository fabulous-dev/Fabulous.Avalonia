namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabTreeView =
    inherit IFabItemsControl

module TreeView =
    let WidgetKey = Widgets.register<TreeView>()

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "TreeView_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let listBox = node.Target :?> TreeView

                match newValueOpt with
                | ValueNone ->
                    listBox.ClearValue(TreeView.ItemTemplateProperty)
                    listBox.ClearValue(TreeView.ItemsProperty)
                | ValueSome value ->
                    // FIXME: Implement WidgetTreeDataTemplate properly
                    listBox.SetValue(TreeView.ItemTemplateProperty, WidgetTreeDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    listBox.SetValue(TreeView.ItemsProperty, value.OriginalItems))

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality TreeView.SelectionModeProperty

[<AutoOpen>]
module TreeViewBuilders =
    type Fabulous.Avalonia.View with

        static member inline TreeView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabTreeView, 'itemData, 'itemMarker> TreeView.WidgetKey TreeView.ItemsSource items template

[<Extension>]
type TreeViewModifiers =
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabTreeView>, value: SelectionMode) =
        this.AddScalar(TreeView.SelectionMode.WithValue(value))
