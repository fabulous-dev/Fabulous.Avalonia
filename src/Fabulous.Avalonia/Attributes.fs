namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Collections
open Fabulous

module Attributes =
    /// Define an attribute for a DirectProperty
    let inline defineDirect<'owner, 'modelType, 'valueType when 'owner :> IAvaloniaObject>
        (directProperty: DirectProperty<'owner, 'valueType>)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType>
            directProperty.Name
            convertValue
            compare
            (fun _ newValueOpt node ->
                let target = node.Target :?> IAvaloniaObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(directProperty)
                | ValueSome v -> target.SetValue(directProperty, v) |> ignore)
            
    /// Define an attribute for a DirectProperty supporting equality comparison
    let inline defineDirectWithEquality<'owner, 'T when 'owner :> IAvaloniaObject and 'T: equality> (directProperty: DirectProperty<'owner, 'T>) =
        Attributes.defineSimpleScalarWithEquality<'T>
            directProperty.Name
            (fun _ newValueOpt node ->
                let target = node.Target :?> IAvaloniaObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(directProperty)
                | ValueSome v -> target.SetValue(directProperty, v) |> ignore)
            
    /// Define an attribute for a StyledProperty
    let inline defineStyled<'modelType, 'valueType>
        (styledProperty: StyledProperty<'valueType>)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType>
            styledProperty.Name
            convertValue
            compare
            (fun _ newValueOpt node ->
                let target = node.Target :?> IAvaloniaObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(styledProperty)
                | ValueSome v -> target.SetValue(styledProperty, v) |> ignore)
            
    /// Define an attribute for a StyledProperty supporting equality comparison
    let inline defineStyledWithEquality<'T when 'T: equality> (styledProperty: StyledProperty<'T>) =
        Attributes.defineSimpleScalarWithEquality<'T>
            styledProperty.Name
            (fun _ newValueOpt node ->
                let target = node.Target :?> IAvaloniaObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(styledProperty)
                | ValueSome v -> target.SetValue(styledProperty, v) |> ignore)

    /// Define an attribute storing a collection of Widget for a AvaloniaList<T> property
    let inline defineAvaloniaListWidgetCollection<'itemType>
        name
        ([<InlineIfLambda>] getCollection: obj -> IAvaloniaList<'itemType>)
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
        
    /// Define an attribute storing a Widget for a styled property
    let inline defineStyledWidget (styledProperty: StyledProperty<'T>) =
        Attributes.definePropertyWidget
            styledProperty.Name
            (fun target ->
                (target :?> IAvaloniaObject).GetValue(styledProperty))
            (fun target value ->
                let avaloniaObject = target :?> IAvaloniaObject

                if value = null then
                    avaloniaObject.ClearValue(styledProperty)
                else
                    avaloniaObject.SetValue(styledProperty, value) |> ignore)
