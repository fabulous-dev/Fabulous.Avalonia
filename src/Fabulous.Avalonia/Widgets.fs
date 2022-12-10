namespace Fabulous.Avalonia

open System
open Avalonia
open Fabulous
open Fabulous.WidgetCollectionAttributeDefinitions

[<AbstractClass; Sealed>]
type View =
    class
    end

type IFabElement =
    interface
    end

module Widgets =
    let registerWithFactory<'T when 'T :> IAvaloniaObject> (factory: unit -> 'T) =
        let key = WidgetDefinitionStore.getNextKey ()

        let definition =
            { Key = key
              Name = typeof<'T>.Name
              TargetType = typeof<'T>
              CreateView =
                fun (widget, treeContext, parentNode) ->
                    treeContext.Logger.Debug("Creating view for {0}", typeof<'T>.Name)

                    let view = factory ()
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

    let register<'T when 'T :> IAvaloniaObject and 'T: (new: unit -> 'T)> () =
        registerWithFactory (fun () -> new 'T())

module WidgetHelpers =
    let inline buildAttributeCollection<'msg, 'marker, 'item>
        (collectionAttributeDefinition: WidgetCollectionAttributeDefinition)
        (widget: WidgetBuilder<'msg, 'marker>)
        =
        AttributeCollectionBuilder<'msg, 'marker, 'item>(widget, collectionAttributeDefinition)
