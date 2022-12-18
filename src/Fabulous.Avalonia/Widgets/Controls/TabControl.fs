namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabTabControl =
    inherit IFabSelectingItemsControl

module TabControl =
    let WidgetKey = Widgets.register<TabControl> ()

    let TabStripPlacement =
        Attributes.defineAvaloniaPropertyWithEquality TabControl.TabStripPlacementProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TabControl.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TabControl.VerticalContentAlignmentProperty

[<AutoOpen>]
module TabControlBuilders =
    type Fabulous.Avalonia.View with

        static member TabControl(?tabStripPlacement: Dock) =
            match tabStripPlacement with
            | Some tabStripPlacement ->
                CollectionBuilder<'msg, IFabTabControl, IFabTabItem>(
                    TabControl.WidgetKey,
                    ItemsControl.Items,
                    TabControl.TabStripPlacement.WithValue(tabStripPlacement)
                )
            | None ->
                CollectionBuilder<'msg, IFabTabControl, IFabTabItem>(
                    TabControl.WidgetKey,
                    ItemsControl.Items,
                    TabControl.TabStripPlacement.WithValue(Dock.Top)
                )

[<Extension>]
type TabControlModifiers =
    [<Extension>]
    static member inline horizontalContentAlignment
        (
            this: WidgetBuilder<'msg, #IFabTabControl>,
            value: HorizontalAlignment
        ) =
        this.AddScalar(TabControl.HorizontalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalContentAlignment
        (
            this: WidgetBuilder<'msg, #IFabTabControl>,
            value: VerticalAlignment
        ) =
        this.AddScalar(TabControl.VerticalContentAlignment.WithValue(value))

[<Extension>]
type TabControlExtraModifiers =

    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabTabControl>) =
        TabControlModifiers.horizontalContentAlignment (this, HorizontalAlignment.Center)

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabTabControl>) =
        TabControlModifiers.verticalContentAlignment (this, VerticalAlignment.Center)

    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabTabControl>) =
        this.centerHorizontal().centerVertical ()

[<Extension>]
type TabControlCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTabItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTabItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTabItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTabItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
