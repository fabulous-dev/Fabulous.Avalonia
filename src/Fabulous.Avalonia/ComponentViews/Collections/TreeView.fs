namespace Fabulous.Avalonia.Components

open System.Collections
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentTreeView =
    inherit IFabComponentItemsControl
    inherit IFabTreeView

type ComponentTreeWidgetItems =
    { Nodes: IEnumerable
      SubNodesFn: obj -> IEnumerable
      Template: obj -> Widget }

module ComponentTreeView =
    let SelectionChanged =
        ComponentAttributes.defineEvent "TreeView_SelectionChanged" (fun target -> (target :?> TreeView).SelectionChanged)

[<AutoOpen>]
module ComponentTreeViewBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TreeView widget.</summary>
        /// <param name="nodes">The root nodes used to populate the TreeView.</param>
        /// <param name="subNodes">The sub nodes used to populate the children of each node.</param>
        /// <param name="template">The template used to render each node.</param>
        static member TreeView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabComponentControl>
            (nodes: seq<'itemData>, subNodes: 'itemData -> seq<'itemData>, template: 'itemData -> WidgetBuilder<unit, 'itemMarker>)
            =
            let template (item: obj) =
                let item = unbox<'itemData> item
                (template item).Compile()

            let data: TreeWidgetItems =
                { Nodes = nodes
                  SubNodesFn = (fun subNode -> subNodes(unbox subNode) :> IEnumerable)
                  Template = template }

            WidgetBuilder<'msg, IFabComponentTreeView>(TreeView.WidgetKey, TreeView.ItemsSource.WithValue(data))

type ComponentTreeViewModifiers =
    /// <summary>Listens to the TreeView SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the TreeView SelectionChanged event is fired.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<unit, #IFabComponentTreeView>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(ComponentTreeView.SelectionChanged.WithValue(fn))
