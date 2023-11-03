namespace Fabulous.Avalonia

open System.Collections
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabTreeView =
    inherit IFabItemsControl

(*
    TreeView(nodes, _.Children, fun node ->
        TextBlock(node.Value)
    )
*)

type TreeWidgetItems =
    { Nodes: IEnumerable
      SubNodesFn: obj -> IEnumerable
      Template: obj -> Widget }

module TreeView =
    let WidgetKey = Widgets.register<TreeView>()

    let ItemsSource =
        Attributes.defineSimpleScalar<TreeWidgetItems>
            "TreeView_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.Nodes b.Nodes)
            (fun _ newValueOpt node ->
                let listBox = node.Target :?> TreeView

                match newValueOpt with
                | ValueNone ->
                    listBox.ClearValue(TreeView.ItemTemplateProperty)
                    listBox.ClearValue(TreeView.ItemsSourceProperty)
                | ValueSome value ->
                    listBox.SetValue(TreeView.ItemTemplateProperty, WidgetTreeDataTemplate(node, value.SubNodesFn, unbox >> value.Template))
                    |> ignore

                    listBox.SetValue(TreeView.ItemsSourceProperty, value.Nodes) |> ignore)


[<AutoOpen>]
module TreeViewBuilders =
    type Fabulous.Avalonia.View with

        static member inline TreeView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                nodes: seq<'itemData>,
                subNodes: 'itemData -> seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            let template (item: obj) =
                let item = unbox<'itemData> item
                (template item).Compile()

            let data: TreeWidgetItems =
                { Nodes = nodes
                  SubNodesFn = (fun subNode -> subNodes(unbox subNode) :> IEnumerable)
                  Template = template }

            WidgetBuilder<'msg, 'itemMarker>(TreeView.WidgetKey, TreeView.ItemsSource.WithValue(data))

[<Extension>]
type TreeViewModifiers =
    /// <summary>Link a ViewRef to access the direct TreeView control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTreeView>, value: ViewRef<TreeView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
