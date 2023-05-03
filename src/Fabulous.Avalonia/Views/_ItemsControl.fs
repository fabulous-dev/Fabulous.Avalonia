namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =
    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "ItemsControl_Items" (fun target ->
            let target = target :?> ItemsControl

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "ItemsControl_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let listBox = node.Target :?> ItemsControl

                match newValueOpt with
                | ValueNone ->
                    listBox.ClearValue(ItemsControl.ItemTemplateProperty)
                    listBox.ClearValue(ItemsControl.ItemsSourceProperty)
                | ValueSome value ->
                    listBox.SetValue(ItemsControl.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    listBox.SetValue(ItemsControl.ItemsSourceProperty, value.OriginalItems)
                    |> ignore)

    let AreHorizontalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.AreHorizontalSnapPointsRegularProperty

    let AreVerticalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.AreVerticalSnapPointsRegularProperty

    let HorizontalSnapPointsChanged =
        Attributes.defineEvent "ItemsControl_HorizontalSnapPointsChanged" (fun target -> (target :?> ItemsControl).HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        Attributes.defineEvent "ItemsControl_VerticalSnapPointsChanged" (fun target -> (target :?> ItemsControl).VerticalSnapPointsChanged)

    let ContainerClearing =
        Attributes.defineEvent "ItemsControl_ContainerClearing" (fun target -> (target :?> ItemsControl).ContainerClearing)

    let ContainerIndexChanged =
        Attributes.defineEvent "ItemsControl_ContainerIndexChanged" (fun target -> (target :?> ItemsControl).ContainerIndexChanged)

    let ContainerPrepared =
        Attributes.defineEvent "ItemsControl_ContainerPrepared" (fun target -> (target :?> ItemsControl).ContainerPrepared)

[<Extension>]
type ItemsControlModifiers =
    [<Extension>]
    static member inline areHorizontalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabItemsControl>, value: bool) =
        this.AddScalar(ItemsControl.AreHorizontalSnapPointsRegular.WithValue(value))

    [<Extension>]
    static member inline areVerticalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabItemsControl>, value: bool) =
        this.AddScalar(ItemsControl.AreVerticalSnapPointsRegular.WithValue(value))

    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, onHorizontalSnapPointsChanged: 'msg) =
        this.AddScalar(ItemsControl.HorizontalSnapPointsChanged.WithValue(fun _ -> onHorizontalSnapPointsChanged |> box))

    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, onVerticalSnapPointsChanged: 'msg) =
        this.AddScalar(ItemsControl.VerticalSnapPointsChanged.WithValue(fun _ -> onVerticalSnapPointsChanged |> box))

    [<Extension>]
    static member inline onContainerClearing(this: WidgetBuilder<'msg, #IFabItemsControl>, onContainerClearing: ContainerClearingEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerClearing.WithValue(fun args -> onContainerClearing args |> box))

    [<Extension>]
    static member inline onContainerIndexChanged
        (
            this: WidgetBuilder<'msg, #IFabItemsControl>,
            onContainerIndexChanged: ContainerIndexChangedEventArgs -> 'msg
        ) =
        this.AddScalar(ItemsControl.ContainerIndexChanged.WithValue(fun args -> onContainerIndexChanged args |> box))

    [<Extension>]
    static member inline onContainerPrepared(this: WidgetBuilder<'msg, #IFabItemsControl>, onContainerPrepared: ContainerPreparedEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerPrepared.WithValue(fun args -> onContainerPrepared args |> box))
