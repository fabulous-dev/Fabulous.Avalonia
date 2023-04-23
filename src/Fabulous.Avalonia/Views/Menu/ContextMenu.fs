namespace Fabulous.Avalonia

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.StackAllocatedCollections

type IFabContextMenu =
    inherit IFabMenuBase

module ContextMenu =
    let WidgetKey = Widgets.register<ContextMenu>()

    let inline defineContextMenuEvent
        name
        ([<InlineIfLambda>] getEvent: obj -> IEvent<CancelEventHandler, CancelEventArgs>)
        : SimpleScalarAttributeDefinition<CancelEventArgs -> obj> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: (CancelEventArgs -> obj) voption) (node: IViewNode) ->
                    let event = getEvent node.Target

                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> event.RemoveHandler handler

                    match newValueOpt with
                    | ValueNone -> node.SetHandler(name, ValueNone)

                    | ValueSome fn ->
                        let handler =
                            CancelEventHandler(fun _ args ->
                                let r = fn args
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, ValueSome handler)
                        event.AddHandler handler)
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.VerticalOffsetProperty

    let PlacementConstraintAdjustment =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementConstraintAdjustmentProperty

    let PlacementAnchor =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementAnchorProperty

    let PlacementGravity =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementGravityProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementProperty

    let PlacementRect =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementRectProperty

    let PlacementTarget =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementTargetProperty

    let WindowManagerAddShadowHint =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.WindowManagerAddShadowHintProperty

    let ContextMenuOpening =
        defineContextMenuEvent "ContextMenuOpening_ContextMenuOpening" (fun target -> (target :?> ContextMenu).ContextMenuOpening)

    let ContextMenuClosing =
        defineContextMenuEvent "ContextMenuClosing_ContextMenuClosing" (fun target -> (target :?> ContextMenu).ContextMenuClosing)

[<AutoOpen>]
module ContextMenuBuilders =
    type Fabulous.Avalonia.View with

        static member inline ContextMenu(?placement: PlacementMode) =
            match placement with
            | None ->
                CollectionBuilder<'msg, IFabContextMenu, IFabControl>(
                    ContextMenu.WidgetKey,
                    ItemsControl.Items,
                    ContextMenu.Placement.WithValue(PlacementMode.Bottom)
                )

            | Some placement ->
                CollectionBuilder<'msg, IFabContextMenu, IFabControl>(ContextMenu.WidgetKey, ItemsControl.Items, ContextMenu.Placement.WithValue(placement))

[<Extension>]
type ContextMenuModifiers =
    [<Extension>]
    static member inline horizontalOffset(this: WidgetBuilder<'msg, #IFabContextMenu>, value: float) =
        this.AddScalar(ContextMenu.HorizontalOffset.WithValue(value))

    [<Extension>]
    static member inline verticalOffset(this: WidgetBuilder<'msg, #IFabContextMenu>, value: float) =
        this.AddScalar(ContextMenu.VerticalOffset.WithValue(value))

    [<Extension>]
    static member inline placementConstraintAdjustment(this: WidgetBuilder<'msg, #IFabContextMenu>, value: PopupPositionerConstraintAdjustment) =
        this.AddScalar(ContextMenu.PlacementConstraintAdjustment.WithValue(value))

    [<Extension>]
    static member inline placementAnchor(this: WidgetBuilder<'msg, #IFabContextMenu>, value: PopupAnchor) =
        this.AddScalar(ContextMenu.PlacementAnchor.WithValue(value))

    [<Extension>]
    static member inline placementGravity(this: WidgetBuilder<'msg, #IFabContextMenu>, value: PopupGravity) =
        this.AddScalar(ContextMenu.PlacementGravity.WithValue(value))

    [<Extension>]
    static member inline placementRect(this: WidgetBuilder<'msg, #IFabContextMenu>, value: Rect) =
        this.AddScalar(ContextMenu.PlacementRect.WithValue(value))

    [<Extension>]
    static member inline windowManagerAddShadowHint(this: WidgetBuilder<'msg, #IFabContextMenu>, value: bool) =
        this.AddScalar(ContextMenu.WindowManagerAddShadowHint.WithValue(value))

    [<Extension>]
    static member inline onContextMenuOpening(this: WidgetBuilder<'msg, #IFabContextMenu>, onContextMenuOpening: CancelEventArgs -> 'msg) =
        this.AddScalar(ContextMenu.ContextMenuOpening.WithValue(fun args -> onContextMenuOpening args |> box))

    [<Extension>]
    static member inline onContextMenuClosing(this: WidgetBuilder<'msg, #IFabContextMenu>, onContextMenuClosing: CancelEventArgs -> 'msg) =
        this.AddScalar(ContextMenu.ContextMenuClosing.WithValue(fun args -> onContextMenuClosing args |> box))

    [<Extension>]
    static member inline placementTarget(this: WidgetBuilder<'msg, #IFabContextMenu>, value: ViewRef<#Control>) =
        match value.TryValue with
        | None -> this
        | Some value -> this.AddScalar(ContextMenu.PlacementTarget.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ContextMenu control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabContextMenu>, value: ViewRef<ContextMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type ContextMenuAttachedModifiers =
    [<Extension>]
    static member inline contextMenu(this: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, IFabContextMenu>) =
        this.AddWidget(Control.ContextMenu.WithValue(content.Compile()))

[<Extension>]
type ContextMenuCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
