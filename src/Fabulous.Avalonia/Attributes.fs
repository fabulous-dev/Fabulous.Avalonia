namespace Fabulous.Avalonia

open System
open System.IO
open Avalonia
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.ScalarAttributeDefinitions

[<RequireQualifiedAccess>]
type ImageSourceValue =
    | Bitmap of source: Bitmap
    | File of source: string
    | Uri of source: Uri
    | Stream of source: Stream

[<RequireQualifiedAccess>]
module ScalarAttributeComparers =
    let inline physicalEqualityCompare a b =
        if LanguagePrimitives.PhysicalEquality a b then
            ScalarAttributeComparison.Identical
        else
            ScalarAttributeComparison.Different

[<Struct>]
type ComponentValueEventData<'data, 'eventArgs> =
    { Value: 'data voption
      Event: 'eventArgs -> unit }

module ComponentValueEventData =
    let create (value: 'data) (event: 'eventArgs -> unit) =
        { Value = ValueSome value
          Event = event }

    let createVOption (value: 'data voption) (event: 'eventArgs -> unit) = { Value = value; Event = event }

[<Struct>]
type MvuValueEventData<'data, 'eventArgs> =
    { Value: 'data voption
      Event: 'eventArgs -> MsgValue }

module MvuValueEventData =
    let create (value: 'data) (event: 'eventArgs -> 'msg) =
        { Value = ValueSome value
          Event = event >> box >> MsgValue }

    let createVOption (value: 'data voption) (event: 'eventArgs -> 'msg) =
        { Value = value
          Event = event >> box >> MsgValue }

module Attributes =
    /// Define an attribute for an AvaloniaProperty
    let inline defineAvaloniaProperty<'modelType, 'valueType>
        (property: AvaloniaProperty<'valueType>)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType> property.Name convertValue compare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(property)
            | ValueSome v -> target.SetValue(property, v) |> ignore)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison
    let inline defineAvaloniaPropertyWithEquality<'T when 'T: equality> (directProperty: AvaloniaProperty<'T>) =
        Attributes.defineSimpleScalarWithEquality<'T> directProperty.Name (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(directProperty)
            | ValueSome v -> target.SetValue(directProperty, v) |> ignore)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison with a default value and setter
    let inline defineProperty<'T when 'T: equality> name (defaultValue: 'T) (setter: obj -> 'T -> unit) =
        Attributes.defineSimpleScalarWithEquality<'T> name (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> setter target defaultValue
            | ValueSome v -> setter target v)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison with getter and setter
    let inline definePropertyWithGetSet<'T when 'T: equality> name (getter: obj -> 'T) (setter: obj -> 'T -> unit) =
        Attributes.defineSimpleScalarWithEquality<'T> name (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> setter target (getter target)
            | ValueSome v -> setter target v)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison and converter
    let inline defineAvaloniaPropertyWithEqualityConverter<'T, 'modelType, 'valueType when 'T: equality>
        (directProperty: AvaloniaProperty<'T>)
        (convert: 'modelType -> 'valueType)
        =
        Attributes.defineScalar<'modelType, 'valueType> directProperty.Name convert ScalarAttributeComparers.noCompare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(directProperty)
            | ValueSome v -> target.SetValue(directProperty, v) |> ignore)

    /// Define an attribute storing a Widget for an AvaloniaProperty
    let inline defineAvaloniaPropertyWidget (property: AvaloniaProperty<'T>) =
        Attributes.definePropertyWidget property.Name (fun target -> (target :?> AvaloniaObject).GetValue(property)) (fun target value ->
            let avaloniaObject = target :?> AvaloniaObject

            if value = null then
                avaloniaObject.ClearValue(property)
            else
                avaloniaObject.SetValue(property, value) |> ignore)


    /// Performance optimization: avoid allocating a new ImageSource instance on each update
    /// we store the user value (e.g. Bitmap, string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline defineBindableImageSource (property: AvaloniaProperty) =
        Attributes.defineScalar<ImageSourceValue, ImageSourceValue> property.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(property)
            | ValueSome v ->
                let value =
                    match v with
                    | ImageSourceValue.Bitmap source -> source
                    | ImageSourceValue.File file -> ImageSource.fromString file
                    | ImageSourceValue.Uri uri -> ImageSource.fromUri uri
                    | ImageSourceValue.Stream stream -> ImageSource.fromStream(stream)

                target.SetValue(property, value) |> ignore)

    /// Performance optimization: avoid allocating a new WindowIcon instance on each update
    /// we store the user value (e.g. Bitmap, string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline defineBindableWindowIconSource (property: AvaloniaProperty) =
        Attributes.defineScalar<ImageSourceValue, ImageSourceValue> property.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(property)
            | ValueSome v ->
                let value =
                    match v with
                    | ImageSourceValue.Bitmap source -> WindowIcon(source)
                    | ImageSourceValue.File file -> WindowIcon(ImageSource.fromString file)
                    | ImageSourceValue.Uri uri -> WindowIcon(ImageSource.fromUri uri)
                    | ImageSourceValue.Stream stream -> WindowIcon(ImageSource.fromStream(stream))

                target.SetValue(property, value) |> ignore)

    let inline defineAvaloniaPropertyWithChangedEvent<'modelType, 'valueType>
        name
        (property: AvaloniaProperty<'valueType>)
        ([<InlineIfLambda>] convertToValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] convertToModel: 'valueType -> 'modelType)
        : SimpleScalarAttributeDefinition<MvuValueEventData<'modelType, 'modelType>> =

        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun oldValueOpt (newValueOpt: MvuValueEventData<'modelType, 'modelType> voption) node ->
                    let target = node.Target :?> AvaloniaObject

                    // The attribute is no longer applied, so we clean up the event
                    match node.TryGetHandler(property.Name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone ->
                        match oldValueOpt with
                        | ValueNone -> ()
                        | ValueSome _ -> target.ClearValue(property)

                    | ValueSome curr ->
                        // Clean up the old event handler if any
                        match node.TryGetHandler(property.Name) with
                        | ValueNone -> ()
                        | ValueSome handler -> handler.Dispose()

                        // Set the new value

                        match curr.Value with
                        | ValueNone -> ()
                        | ValueSome v ->
                            let newValue = convertToValue v
                            target.SetValue(property, box newValue) |> ignore

                        let event = property.Changed
                        // Set the new event handler
                        let disposable =
                            event.Subscribe(fun args ->
                                if args.Sender = target then
                                    if args.NewValue.HasValue then
                                        let args = args.NewValue.Value
                                        let (MsgValue r) = curr.Event(convertToModel args)
                                        Dispatcher.dispatch node r)

                        node.SetHandler(property.Name, disposable))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let defineAvaloniaPropertyWithChangedEvent'<'T> name (property: AvaloniaProperty<'T>) : SimpleScalarAttributeDefinition<MvuValueEventData<'T, 'T>> =
        defineAvaloniaPropertyWithChangedEvent<'T, 'T> name property id id

    let defineAvaloniaPropertyWithChangedEventNoDispatch<'modelType, 'valueType>
        name
        (property: AvaloniaProperty<'valueType>)
        (convertToValue: 'modelType -> 'valueType)
        (convertToModel: 'valueType -> 'modelType)
        : SimpleScalarAttributeDefinition<ComponentValueEventData<'modelType, 'modelType>> =

        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun oldValueOpt (newValueOpt: ComponentValueEventData<'modelType, 'modelType> voption) node ->
                    let target = node.Target :?> AvaloniaObject

                    // The attribute is no longer applied, so we clean up the event
                    match node.TryGetHandler(property.Name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone ->
                        match oldValueOpt with
                        | ValueNone -> ()
                        | ValueSome _ -> target.ClearValue(property)

                    | ValueSome curr ->
                        // Clean up the old event handler if any
                        match node.TryGetHandler(property.Name) with
                        | ValueNone -> ()
                        | ValueSome handler -> handler.Dispose()

                        // Set the new value

                        match curr.Value with
                        | ValueNone -> ()
                        | ValueSome v ->
                            let newValue = convertToValue v
                            target.SetValue(property, box newValue) |> ignore

                        let event = property.Changed
                        // Set the new event handler
                        let disposable =
                            event.Subscribe(fun args ->
                                if args.Sender = target then
                                    if args.NewValue.HasValue then
                                        curr.Event(convertToModel args.NewValue.Value))

                        node.SetHandler(property.Name, disposable))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let defineAvaloniaPropertyWithChangedEventNoDispatch'<'T>
        name
        (property: AvaloniaProperty<'T>)
        : SimpleScalarAttributeDefinition<ComponentValueEventData<'T, 'T>> =
        defineAvaloniaPropertyWithChangedEventNoDispatch<'T, 'T> name property id id

    let defineRoutedEvent<'args when 'args :> RoutedEventArgs> name (property: RoutedEvent<'args>) : SimpleScalarAttributeDefinition<'args -> MsgValue> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> MsgValue) voption) (node: IViewNode) ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.Dispose()

                    | ValueSome fn ->
                        let event =
                            property.AddClassHandler(fun _ args ->
                                let (MsgValue r) = fn args
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, event))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let defineRoutedEventNoDispatch<'args when 'args :> RoutedEventArgs> name (property: RoutedEvent<'args>) : SimpleScalarAttributeDefinition<'args -> unit> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> unit) voption) (node: IViewNode) ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.Dispose()

                    | ValueSome fn ->
                        let event = property.AddClassHandler(fun _ args -> fn args)

                        node.SetHandler(name, event))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let inline defineEventHandler name ([<InlineIfLambda>] getEvent: obj -> IEvent<'handler, 'args>) : SimpleScalarAttributeDefinition<'args -> MsgValue> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> MsgValue) voption) (node: IViewNode) ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.Dispose()

                    | ValueSome fn ->
                        let event = getEvent node.Target

                        let handler =
                            event.Subscribe(fun args ->
                                let (MsgValue r) = fn args
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, handler))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let inline defineEventHandlerNoDispatch
        name
        ([<InlineIfLambda>] getEvent: obj -> IEvent<'handler, 'args>)
        : SimpleScalarAttributeDefinition<'args -> unit> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> unit) voption) (node: IViewNode) ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.Dispose()

                    | ValueSome fn ->
                        let event = getEvent node.Target

                        let handler = event.Subscribe(fun args -> fn args)

                        node.SetHandler(name, handler))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let inline defineAvaloniaNonGenericListWidgetCollection name ([<InlineIfLambda>] getCollection: obj -> System.Collections.IList) =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove(index, widget) ->
                    let itemNode = node.TreeContext.GetViewNode(targetColl[index])

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Dispose()

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
                    let childNode = node.TreeContext.GetViewNode(targetColl[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace(index, oldWidget, newWidget) ->
                    let prevItemNode = node.TreeContext.GetViewNode(targetColl[index])

                    let struct (nextItemNode, view) = Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode oldWidget Lifecycle.Unmounted
                    prevItemNode.Dispose()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl[index] <- view

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

                    targetColl.Add(view) |> ignore

        Attributes.defineWidgetCollection name applyDiff updateNode

    /// Define an attribute storing a collection of Widget for a AvaloniaList<T> property
    let defineAvaloniaListWidgetCollection<'itemType> name (getCollection: obj -> System.Collections.Generic.IList<'itemType>) =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove(index, widget) ->
                    let itemNode = node.TreeContext.GetViewNode(box targetColl[index])

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Dispose()

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
                    let childNode = node.TreeContext.GetViewNode(box targetColl[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace(index, oldWidget, newWidget) ->
                    let prevItemNode = node.TreeContext.GetViewNode(box targetColl[index])

                    let struct (nextItemNode, view) = Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode oldWidget Lifecycle.Unmounted
                    prevItemNode.Dispose()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl[index] <- unbox view

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

    let inline defineAvaloniaNonGenericListWidgetCollectionNoDispatch name ([<InlineIfLambda>] getCollection: obj -> System.Collections.IList) =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove(index, _) ->
                    let itemNode = node.TreeContext.GetViewNode(targetColl[index])

                    itemNode.Dispose()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert(index, widget) ->
                    let struct (_, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    targetColl.Insert(index, unbox view)

                | WidgetCollectionItemChange.Update(index, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(targetColl[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace(index, _, newWidget) ->
                    let prevItemNode = node.TreeContext.GetViewNode(targetColl[index])

                    let struct (_, view) = Helpers.createViewForWidget node newWidget

                    prevItemNode.Dispose()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl[index] <- view
                | _ -> ()

        let updateNode _ (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            let targetColl = getCollection node.Target
            targetColl.Clear()

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let struct (_, view) = Helpers.createViewForWidget node widget

                    targetColl.Add(view) |> ignore

        Attributes.defineWidgetCollection name applyDiff updateNode

    /// Define an attribute storing a collection of Widget for a AvaloniaList<T> property
    let defineAvaloniaListWidgetCollectionNoDispatch<'itemType> name (getCollection: obj -> System.Collections.Generic.IList<'itemType>) =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let targetColl = getCollection node.Target

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove(index, _) ->
                    let itemNode = node.TreeContext.GetViewNode(box targetColl[index])

                    itemNode.Dispose()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert(index, widget) ->
                    let struct (_, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    targetColl.Insert(index, unbox view)

                | WidgetCollectionItemChange.Update(index, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(box targetColl[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace(index, _, newWidget) ->
                    let prevItemNode = node.TreeContext.GetViewNode(box targetColl[index])

                    let struct (_, view) = Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    prevItemNode.Dispose()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl[index] <- unbox view

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
