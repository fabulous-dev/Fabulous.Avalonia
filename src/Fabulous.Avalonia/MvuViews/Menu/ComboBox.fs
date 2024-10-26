namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuComboBox =
    inherit IFabMvuSelectingItemsControl
    inherit IFabComboBox

module MvuComboBox =
    let DropDownOpened =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "Opened" ComboBox.IsDropDownOpenProperty


[<AutoOpen>]
module ComboBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ComboBox widget.</summary>
        /// <param name="items">The items to display in the ComboBox.</param>
        static member ComboBox(items: seq<_>) =
            WidgetBuilder<unit, IFabMvuComboBox>(
                ComboBox.WidgetKey,
                AttributesBundle(StackList.one(ItemsControl.ItemsSource.WithValue(items)), ValueNone, ValueNone)
            )

        /// <summary>Creates a ComboBox widget.</summary>
        /// <param name="items">The items to display in the ComboBox.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member ComboBox(items: seq<'itemData>, template: 'itemData -> WidgetBuilder<unit, 'itemMarker>) =
            WidgetHelpers.buildItems<unit, IFabMvuComboBox, 'itemData, 'itemMarker> ComboBox.WidgetKey ItemsControl.ItemsSourceTemplate items template

        /// <summary>Creates a ComboBox widget.</summary>
        static member ComboBox() =
            CollectionBuilder<unit, IFabMvuComboBox, IFabMvuComboBoxItem>(ComboBox.WidgetKey, MvuItemsControl.Items)

type MvuComboBoxModifiers =
    /// <summary>Listens to the ComboBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">Weather the drop down is open or not.</param>
    /// <param name="fn">Raised when the DropDownOpened event fires.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabMvuComboBox>, isOpen: bool, fn: bool -> unit) =
        this.AddScalar(MvuComboBox.DropDownOpened.WithValue(MvuValueEventData.create isOpen fn))

// /// <summary>Link a ViewRef to access the direct ComboBox control instance.</summary>
// /// <param name="this">Current widget.</param>
// /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
// [<Extension>]
// static member inline reference(this: WidgetBuilder<'msg, IFabMvuComboBox>, value: ViewRef<ComboBox>) =
//     this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type MvuComboBoxExtraModifier =
    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, value: Color) =
        ComboBoxModifiers.placeholderForeground(this, View.SolidColorBrush(value))

    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, value: string) =
        ComboBoxModifiers.placeholderForeground(this, View.SolidColorBrush(value))

type MvuComboBoxCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComboBoxItem>
        (_: CollectionBuilder<'msg, 'marker, IFabComboBoxItem>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComboBoxItem>
        (_: CollectionBuilder<'msg, 'marker, IFabComboBoxItem>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
