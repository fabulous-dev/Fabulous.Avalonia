namespace Fabulous.Avalonia

open System
open System.Collections.Generic
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open System.Runtime.CompilerServices

type IFabListBox =
    inherit IFabSelectingItemsControl

module ListBox =
    let WidgetKey = Widgets.register<ListBox> ()
    
    type WidgetDataTemplate(node: IViewNode, templateFn: obj -> Widget) as this =
        inherit Avalonia.Controls.Templates.FuncDataTemplate(
            typeof<obj>,
            System.Func<obj, INameScope, IControl>(fun data n -> this.Build(data, n)),
            supportsRecycling = true
        )
        
        member this.Recycle(newData: obj, prevWidget: Widget, rowNode: IViewNode): Widget =
            let currWidget = templateFn newData
            Reconciler.update node.TreeContext.CanReuseView (ValueSome prevWidget) currWidget rowNode
            currWidget
        
        member this.Build(data: obj, _: INameScope) =            
            let widget = templateFn data
            let definition = WidgetDefinitionStore.get widget.Key
            let struct (rowNode, view) = definition.CreateView(widget, node.TreeContext, ValueSome node)
            let item = ListBoxItem()
            item.Content <- (view :?> IControl)
            
            let mutable prevWidget = widget
            
            item.DataContextChanged.AddHandler(
                EventHandler(fun sender args ->
                    let currWidget = this.Recycle((sender :?> IControl).DataContext, prevWidget, rowNode)
                    prevWidget <- currWidget
                )
            )
            
            item

    let Items =
        Attributes.defineListWidgetCollection "ListBox_Items" (fun target -> (target :?> ListBox).Items :?> IList<_>)
        
    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "ListBox_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone ->
                    itemsView.ClearValue(ListBox.ItemTemplateProperty)
                    itemsView.ClearValue(ListBox.ItemsProperty)
                | ValueSome value ->
                    itemsView.SetValue(ListBox.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template)) |> ignore
                    itemsView.SetValue(ListBox.ItemsProperty, value.OriginalItems))

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.SelectionModeProperty

    let VirtualizationMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.VirtualizationModeProperty

    let SelectedItems<'T when 'T: equality> =
        Attributes.defineSimpleScalar
            "SelectingItemsControl_SelectedItems"
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let control = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone -> control.ClearValue(ListBox.SelectedItemsProperty)
                | ValueSome value -> control.SetValue(ListBox.SelectedItemsProperty, value))

[<AutoOpen>]
module ListBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline ListBox<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabListBox, 'itemData, 'itemMarker>
                ListBox.WidgetKey
                ListBox.ItemsSource
                items
                template
                
        static member inline ListBox<'msg>() =
            CollectionBuilder<'msg, IFabListBox, IFabListBoxItem>(
                ListBox.WidgetKey,
                ListBox.Items
            )

[<Extension>]
type ListBoxModifiers =
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabListBox>, value: SelectionMode) =
        this.AddScalar(ListBox.SelectionMode.WithValue(value))

    [<Extension>]
    static member inline virtualizationMode(this: WidgetBuilder<'msg, #IFabListBox>, value: ItemVirtualizationMode) =
        this.AddScalar(ListBox.VirtualizationMode.WithValue(value))

    [<Extension>]
    static member inline selectedItems(this: WidgetBuilder<'msg, #IFabListBox>, value: obj list) =
        this.AddScalar(ListBox.SelectedItems.WithValue(ResizeArray(value)))

[<Extension>]
type ListBoxCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabListBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabListBoxItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabListBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabListBoxItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
