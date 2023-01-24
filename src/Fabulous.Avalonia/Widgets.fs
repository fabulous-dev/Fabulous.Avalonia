namespace Fabulous.Avalonia

open System
open System.Collections
open Avalonia
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.WidgetCollectionAttributeDefinitions

[<AbstractClass; Sealed>]
type View =
    class
    end

type IFabElement =
    interface
    end

type WidgetItems =
    { OriginalItems: IEnumerable
      Template: obj -> Widget }

module Widgets =
    let registerWithFactory<'T when 'T :> IAvaloniaObject> (factory: unit -> 'T) =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = typeof<'T>.Name
              TargetType = typeof<'T>
              CreateView =
                fun (widget, treeContext, parentNode) ->
                    treeContext.Logger.Debug("Creating view for {0}", typeof<'T>.Name)

                    let view = factory()
                    let weakReference = WeakReference(view)

                    let parentNode =
                        match parentNode with
                        | ValueNone -> None
                        | ValueSome node -> Some node

                    let node = ViewNode(parentNode, treeContext, weakReference)

                    ViewNode.set node view

                    // additionalSetup view node

                    Reconciler.update treeContext.CanReuseView ValueNone widget node
                    struct (node :> IViewNode, box view)
              AttachView =
                fun (widget, treeContext, parentNode, view) ->
                    treeContext.Logger.Debug("Attaching view for {0}", typeof<'T>.Name)

                    let weakReference = WeakReference(view)

                    let parentNode =
                        match parentNode with
                        | ValueNone -> None
                        | ValueSome node -> Some node

                    let node = ViewNode(parentNode, treeContext, weakReference)

                    ViewNode.set node view

                    // additionalSetup view node

                    Reconciler.update treeContext.CanReuseView ValueNone widget node
                    node :> IViewNode }

        WidgetDefinitionStore.set key definition
        key

    let register<'T when 'T :> IAvaloniaObject and 'T: (new: unit -> 'T)> () = registerWithFactory(fun () -> new 'T())

module WidgetHelpers =
    let inline buildAttributeCollection<'msg, 'marker, 'item>
        (collectionAttributeDefinition: WidgetCollectionAttributeDefinition)
        (widget: WidgetBuilder<'msg, 'marker>)
        =
        AttributeCollectionBuilder<'msg, 'marker, 'item>(widget, collectionAttributeDefinition)

    let buildItems<'msg, 'marker, 'itemData, 'itemMarker>
        key
        (attrDef: SimpleScalarAttributeDefinition<WidgetItems>)
        (items: seq<'itemData>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        =
        let template (item: obj) =
            let item = unbox<'itemData> item
            (itemTemplate item).Compile()

        let data: WidgetItems =
            { OriginalItems = items
              Template = template }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))

    let inline buildWidgets<'msg, 'marker> (key: WidgetKey) (scalars) (attrs: WidgetAttribute[]) =
        WidgetBuilder<'msg, 'marker>(key, struct (scalars, ValueSome attrs, ValueNone))
