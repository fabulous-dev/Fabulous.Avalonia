namespace Fabulous.Avalonia

open System
open Avalonia
open Avalonia.Collections
open Avalonia.Interactivity
open Fabulous
open Fabulous.ScalarAttributeDefinitions

[<Struct>]
type ValueEventData<'data, 'eventArgs> =
    { Value: 'data
      Event: 'eventArgs -> obj }
    
module ValueEventData =
    let create (value: 'data) (event: 'eventArgs -> obj) = { Value = value; Event = event }

module Attributes =
    /// Define an attribute for an AvaloniaProperty
    let inline defineAvaloniaProperty<'modelType, 'valueType>
        (property: AvaloniaProperty<'valueType>)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType>
            property.Name
            convertValue
            compare
            (fun _ newValueOpt node ->
                let target = node.Target :?> IAvaloniaObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(property)
                | ValueSome v -> target.SetValue(property, v) |> ignore)
            
    /// Define an attribute for an AvaloniaProperty supporting equality comparison
    let inline defineAvaloniaPropertyWithEquality<'T when 'T: equality> (directProperty: AvaloniaProperty<'T>) =
        Attributes.defineSimpleScalarWithEquality<'T>
            directProperty.Name
            (fun _ newValueOpt node ->
                let target = node.Target :?> IAvaloniaObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(directProperty)
                | ValueSome v -> target.SetValue(directProperty, v) |> ignore)

    /// Define an attribute storing a collection of Widget for a AvaloniaList<T> property
    let defineAvaloniaListWidgetCollection<'itemType>
        name
        (getCollection: obj -> IAvaloniaList<'itemType>)
        =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove (index, widget) ->
                    let itemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Disconnect()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert (index, widget) ->
                    let struct (itemNode, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    targetColl.Insert(index, unbox view)

                    // Trigger the mounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

                | WidgetCollectionItemChange.Update (index, widgetDiff) ->
                    let childNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace (index, oldWidget, newWidget) ->
                    let prevItemNode =
                        node.TreeContext.GetViewNode(box targetColl.[index])

                    let struct (nextItemNode, view) =
                        Helpers.createViewForWidget node newWidget

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
        Attributes.definePropertyWidget
            property.Name
            (fun target ->
                (target :?> IAvaloniaObject).GetValue(property))
            (fun target value ->
                let avaloniaObject = target :?> IAvaloniaObject

                if value = null then
                    avaloniaObject.ClearValue(property)
                else
                    avaloniaObject.SetValue(property, value) |> ignore)
            
    /// Update both a property and its related event.
    /// This definition makes sure that the event is only raised when the property is changed by the user,
    /// and not when the property is set by the code
    let defineAvaloniaPropertyWith2RoutedEvents<'modelType, 'valueType>
        name
        (property: AvaloniaProperty<'valueType>)
        (getEventOn: obj -> IEvent<EventHandler<RoutedEventArgs>, RoutedEventArgs>)
        (getEventOff: obj -> IEvent<EventHandler<RoutedEventArgs>, RoutedEventArgs>)
        (convert: 'modelType -> 'valueType)
        (valueOn: 'modelType)
        (valueOff: 'modelType)
        : SimpleScalarAttributeDefinition<ValueEventData<'modelType, 'modelType>> =

        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun oldValueOpt (newValueOpt: ValueEventData<'modelType, 'modelType> voption) node ->
                    let target = node.Target :?> AvaloniaObject
                    let eventOn = getEventOn target
                    let eventOff = getEventOff target

                    let eventOnName = $"{name}_On"
                    let eventOffName = $"{name}_Off"

                    match newValueOpt with
                    | ValueNone ->
                        // The attribute is no longer applied, so we clean up the event
                        match node.TryGetHandler(eventOnName) with
                        | ValueNone -> ()
                        | ValueSome handler -> eventOn.RemoveHandler(handler)

                        match node.TryGetHandler(eventOffName) with
                        | ValueNone -> ()
                        | ValueSome handler -> eventOff.RemoveHandler(handler)

                        // Only clear the property if a value was set before
                        match oldValueOpt with
                        | ValueNone -> ()
                        | ValueSome _ -> target.ClearValue(property)

                    | ValueSome curr ->
                        // Clean up the old event handler if any
                        match node.TryGetHandler(eventOnName) with
                        | ValueNone -> ()
                        | ValueSome handler -> eventOn.RemoveHandler(handler)

                        match node.TryGetHandler(eventOffName) with
                        | ValueNone -> ()
                        | ValueSome handler -> eventOff.RemoveHandler(handler)

                        // Set the new value
                        let newValue = convert curr.Value
                        target.SetValue(property, newValue) |> ignore

                        // Set the new event handler
                        let handlerOn =
                            EventHandler<RoutedEventArgs>
                                (fun _ _ ->
                                    let r = curr.Event valueOn
                                    Dispatcher.dispatch node r)

                        let handlerOff =
                            EventHandler<RoutedEventArgs>
                                (fun _ _ ->
                                    let r = curr.Event valueOff
                                    Dispatcher.dispatch node r)

                        node.SetHandler(eventOnName, ValueSome handlerOn)
                        eventOn.AddHandler(handlerOn)

                        node.SetHandler(eventOffName, ValueSome handlerOff)
                        eventOff.AddHandler(handlerOff))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
