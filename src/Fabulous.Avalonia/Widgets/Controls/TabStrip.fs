namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections


type IFabTabStrip =
    inherit IFabSelectingItemsControl

module TabStrip =
    let WidgetKey = Widgets.register<TabStrip> ()

[<AutoOpen>]
module TabStripBuilders =
    type Fabulous.Avalonia.View with

        static member inline TabStrip() =
            CollectionBuilder<'msg, IFabTabStrip, IFabTabStripItem>(TabStrip.WidgetKey, ItemsControl.Items)

[<Extension>]
type TabStripCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTabStripItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTabStripItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTabStripItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTabStripItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
