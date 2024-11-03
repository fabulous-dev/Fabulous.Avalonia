namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

module ComponentComboBox =
    let DropDownOpened =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "Opened" ComboBox.IsDropDownOpenProperty


[<AutoOpen>]
module ComponentComboBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ComboBox widget.</summary>
        /// <param name="items">The items to display in the ComboBox.</param>
        static member ComboBox(items: seq<_>) =
            WidgetBuilder<'msg, IFabComboBox>(
                ComboBox.WidgetKey,
                AttributesBundle(StackList.one(ItemsControl.ItemsSource.WithValue(items)), ValueNone, ValueNone)
            )

        /// <summary>Creates a ComboBox widget.</summary>
        /// <param name="items">The items to display in the ComboBox.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member ComboBox(items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>) =
            WidgetHelpers.buildItems<unit, IFabComboBox, 'itemData, 'itemMarker> ComboBox.WidgetKey ItemsControl.ItemsSourceTemplate items template

        /// <summary>Creates a ComboBox widget.</summary>
        static member ComboBox() =
            CollectionBuilder<'msg, IFabComboBox, IFabComboBoxItem>(ComboBox.WidgetKey, ComponentItemsControl.Items)

type ComponentComboBoxModifiers =
    /// <summary>Listens to the ComboBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">Weather the drop down is open or not.</param>
    /// <param name="fn">Raised when the DropDownOpened event fires.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabComboBox>, isOpen: bool, fn: bool -> unit) =
        this.AddScalar(ComponentComboBox.DropDownOpened.WithValue(ComponentValueEventData.create isOpen fn))
