namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Collections
open Avalonia.Controls
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
