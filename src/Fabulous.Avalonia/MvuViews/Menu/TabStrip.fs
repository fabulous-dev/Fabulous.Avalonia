namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuTabStrip =
    inherit IFabMvuSelectingItemsControl
    inherit IFabTabStrip


[<AutoOpen>]
module MvuTabStripBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TabStrip widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member TabStrip<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabMvuControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabMvuTabStrip, 'itemData, 'itemMarker> TabStrip.WidgetKey ItemsControl.ItemsSourceTemplate items template

type MvuTabStripModifiers =
    /// <summary>Link a ViewRef to access the direct TabStrip control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuTabStrip>, value: ViewRef<TabStrip>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
