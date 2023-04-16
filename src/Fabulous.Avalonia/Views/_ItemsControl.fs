namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =
    // TODO Use ItemsSource when possible. As future versions of Avalonia will make this Items read-only, we need to use ItemsSource instead.
    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "ItemsControl_Items" (fun target -> (target :?> ItemsControl).Items)

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
                    listBox.SetValue(ItemsControl.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template, true))
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
    // <summary>Sets the AreHorizontalSnapPointsRegular property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline areHorizontalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabItemsControl>, value: bool) =
        this.AddScalar(ItemsControl.AreHorizontalSnapPointsRegular.WithValue(value))

    /// <summary>Sets the AreVerticalSnapPointsRegular property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline areVerticalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabItemsControl>, value: bool) =
        this.AddScalar(ItemsControl.AreVerticalSnapPointsRegular.WithValue(value))

    /// <summary>Listens to the HorizontalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">The message to send when the event is raised.</param>
    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, msg: 'msg) =
        this.AddScalar(ItemsControl.HorizontalSnapPointsChanged.WithValue(fun _ -> msg |> box))

    /// <summary>Listens to the VerticalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">The message to send when the event is raised.</param>
    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, msg: 'msg) =
        this.AddScalar(ItemsControl.VerticalSnapPointsChanged.WithValue(fun _ -> msg |> box))

    /// <summary>Listens to the ContainerClearing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Function to call when the event is raised.</param>
    [<Extension>]
    static member inline onContainerClearing(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerClearingEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerClearing.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the ContainerIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Function to call when the event is raised.</param>
    [<Extension>]
    static member inline onContainerIndexChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerIndexChangedEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerIndexChanged.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the ContainerPrepared event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Function to call when the event is raised.</param>
    [<Extension>]
    static member inline onContainerPrepared(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerPreparedEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerPrepared.WithValue(fun args -> fn args |> box))
