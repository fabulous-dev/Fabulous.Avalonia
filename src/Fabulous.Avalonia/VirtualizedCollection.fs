namespace Fabulous.Avalonia

open System
open System.Collections
open Avalonia.Controls
open Avalonia.Controls.Templates
open Fabulous

type WidgetDataTemplate(node: IViewNode, templateFn: obj -> Widget, supportsRecycling: bool) as this =
    inherit FuncDataTemplate(typeof<obj>, System.Func<obj, INameScope, Control>(fun data n -> this.Build(data, n)), supportsRecycling = supportsRecycling)

    member this.Recycle(newData: obj, prevWidget: Widget, rowNode: IViewNode) : Widget =
        let currWidget = templateFn newData
        Reconciler.update node.TreeContext.CanReuseView (ValueSome prevWidget) currWidget rowNode
        currWidget

    member this.Build(data: obj, _: INameScope) =
        let widget = templateFn data
        let definition = WidgetDefinitionStore.get widget.Key

        let struct (rowNode, view) =
            definition.CreateView(widget, node.TreeContext, ValueSome node)

        let item = ContentControl()
        item.Content <- (view :?> Control)

        let mutable prevWidget = widget

        item.DataContextChanged.AddHandler(
            EventHandler(fun sender args ->
                if supportsRecycling then
                    let currWidget = this.Recycle((sender :?> Control).DataContext, prevWidget, rowNode)

                    prevWidget <- currWidget)
        )

        item

type WidgetTreeDataTemplate(node: IViewNode, templateFn: obj -> Widget) as this =
    inherit
        FuncTreeDataTemplate(
            System.Func<obj, bool>(this.Match),
            System.Func<obj, INameScope, Control>(fun data n -> this.Build(data, n)),
            System.Func<obj, IEnumerable>(fun data -> this.ItemsSelector(data))
        )

    member this.Build(data: obj, _: INameScope) =
        let widget = templateFn data
        let definition = WidgetDefinitionStore.get widget.Key

        let struct (_, view) =
            definition.CreateView(widget, node.TreeContext, ValueSome node)

        let item = ContentControl()
        item.Content <- (view :?> Control)

        item

    member this.Match(_: obj, _: bool) = false

    member this.ItemsSelector(_: obj) = seq<obj> []
