namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuMenu =
    inherit IFabMvuMenuBase
    inherit IFabMenu

[<AutoOpen>]
module MvuMenuBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Menu widget.</summary>
        static member Menu() =
            CollectionBuilder<unit, IFabMvuMenu, IFabMvuMenuItem>(Menu.WidgetKey, MvuItemsControl.Items)

type MvuMenuModifiers =
    /// <summary>Link a ViewRef to access the direct Menu control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuMenu>, value: ViewRef<Menu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type MenuCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
        (_: CollectionBuilder<'msg, 'marker, IFabMenuItem>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
        (_: CollectionBuilder<'msg, 'marker, IFabMenuItem>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
