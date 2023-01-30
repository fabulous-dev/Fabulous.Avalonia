namespace Fabulous.Avalonia

open System
open Avalonia
open Avalonia.Collections
open Fabulous
open Fabulous.ScalarAttributeDefinitions

[<Struct>]
type ValueEventData<'data, 'eventArgs> =
    { Value: 'data voption
      Event: 'eventArgs -> obj }

module ValueEventData =
    let create (value: 'data) (event: 'eventArgs -> obj) =
        { Value = ValueSome value
          Event = event }

    let createVOption (value: 'data voption) (event: 'eventArgs -> obj) = { Value = value; Event = event }

module Attributes =
    /// Define an attribute for EventHandler<'T>
    let inline defineAvaloniaObservableEvent<'args>
        name
        ([<InlineIfLambda>] getObservable: obj -> IObservable<AvaloniaPropertyChangedEventArgs<'args>>)
        : SimpleScalarAttributeDefinition<'args -> obj> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> obj) voption) (node: IViewNode) ->
                    let observable = getObservable node.Target

                    match node.TryGetHandler<IDisposable>(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.SetHandler(name, ValueNone)

                    | ValueSome fn ->
                        let disposable =
                            observable.Subscribe(fun args ->
                                let r = fn args.NewValue.Value
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, ValueSome disposable))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an attribute for an AvaloniaProperty
    let inline defineAvaloniaProperty<'modelType, 'valueType>
        (property: AvaloniaProperty<'valueType>)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType> property.Name convertValue compare (fun _ newValueOpt node ->
            let target = node.Target :?> IAvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(property)
            | ValueSome v -> target.SetValue(property, v) |> ignore)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison
    let inline defineAvaloniaPropertyWithEquality<'T when 'T: equality> (directProperty: AvaloniaProperty<'T>) =
        Attributes.defineSimpleScalarWithEquality<'T> directProperty.Name (fun _ newValueOpt node ->
            let target = node.Target :?> IAvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(directProperty)
            | ValueSome v -> target.SetValue(directProperty, v) |> ignore)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison
    let inline defineProperty<'T when 'T: equality> name (defaultValue: 'T) (setter: obj -> 'T -> unit) =
        Attributes.defineSimpleScalarWithEquality<'T> name (fun _ newValueOpt node ->
            let target = node.Target :?> IAvaloniaObject

            match newValueOpt with
            | ValueNone -> setter target defaultValue
            | ValueSome v -> setter target v)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison and converter
    let inline defineAvaloniaPropertyWithEqualityConverter<'T, 'modelType, 'valueType when 'T: equality>
        (directProperty: AvaloniaProperty<'T>)
        (convert: 'modelType -> 'valueType)
        =
        Attributes.defineScalar<'modelType, 'valueType> directProperty.Name convert ScalarAttributeComparers.noCompare (fun _ newValueOpt node ->
            let target = node.Target :?> IAvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(directProperty)
            | ValueSome v -> target.SetValue(directProperty, v) |> ignore)

    /// Define an attribute storing a collection of Widget for a AvaloniaList<T> property
    let defineAvaloniaListWidgetCollection<'itemType> name (getCollection: obj -> IAvaloniaList<'itemType>) =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove(index, widget) ->
                    let itemNode = node.TreeContext.GetViewNode(box targetColl.[index])

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Disconnect()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert(index, widget) ->
                    let struct (itemNode, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    targetColl.Insert(index, unbox view)

                    // Trigger the mounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

                | WidgetCollectionItemChange.Update(index, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(box targetColl.[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace(index, oldWidget, newWidget) ->
                    let prevItemNode = node.TreeContext.GetViewNode(box targetColl.[index])

                    let struct (nextItemNode, view) = Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode oldWidget Lifecycle.Unmounted
                    prevItemNode.Disconnect()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl.[index] <- unbox view

                    // Trigger the mounted event for the new child
                    Dispatcher.dispatchEventForAllChildren nextItemNode newWidget Lifecycle.Mounted

                | _ -> ()

        let updateNode _ (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            let targetColl = getCollection node.Target
            targetColl.Clear()

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let struct (_, view) = Helpers.createViewForWidget node widget

                    targetColl.Add(unbox view)

        Attributes.defineWidgetCollection name applyDiff updateNode

    /// Define an attribute storing a Widget for an AvaloniaProperty
    let inline defineAvaloniaPropertyWidget (property: AvaloniaProperty<'T>) =
        Attributes.definePropertyWidget property.Name (fun target -> (target :?> IAvaloniaObject).GetValue(property)) (fun target value ->
            let avaloniaObject = target :?> IAvaloniaObject

            if value = null then
                avaloniaObject.ClearValue(property)
            else
                avaloniaObject.SetValue(property, value) |> ignore)

    let defineAvaloniaPropertyWithChangedEvent<'modelType, 'valueType>
        name
        (property: AvaloniaProperty<'valueType>)
        (convert: 'modelType -> 'valueType)
        (convertToModel: 'valueType -> 'modelType)
        : SimpleScalarAttributeDefinition<ValueEventData<'modelType, 'modelType>> =

        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun oldValueOpt (newValueOpt: ValueEventData<'modelType, 'modelType> voption) node ->
                    let target = node.Target :?> AvaloniaObject
                    let observable = property.Changed

                    // The attribute is no longer applied, so we clean up the event
                    match node.TryGetHandler<IDisposable>(property.Name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone ->
                        match oldValueOpt with
                        | ValueNone -> ()
                        | ValueSome _ -> target.ClearValue(property)

                    | ValueSome curr ->
                        // Clean up the old event handler if any
                        match node.TryGetHandler<IDisposable>(property.Name) with
                        | ValueNone -> ()
                        | ValueSome handler -> handler.Dispose()

                        // Set the new value

                        match curr.Value with
                        | ValueNone -> ()
                        | ValueSome v ->
                            let newValue = convert v
                            target.SetValue(property, box newValue) |> ignore

                        // Set the new event handler
                        let disposable =
                            observable.Subscribe(fun args ->
                                if args.Sender = target then
                                    if args.NewValue.HasValue then
                                        let args = args.NewValue.Value
                                        let r = curr.Event(convertToModel args)
                                        Dispatcher.dispatch node r)

                        node.SetHandler(property.Name, ValueSome disposable))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let defineAvaloniaPropertyWithChangedEvent'<'T> name (property: AvaloniaProperty<'T>) : SimpleScalarAttributeDefinition<ValueEventData<'T, 'T>> =
        defineAvaloniaPropertyWithChangedEvent<'T, 'T> name property id id
