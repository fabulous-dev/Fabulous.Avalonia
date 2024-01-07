namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabComboBox =
    inherit IFabSelectingItemsControl

module ComboBox =
    let WidgetKey = Widgets.register<ComboBox>()

    let IsDropDownOpen =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.IsDropDownOpenProperty

    let MaxDropDownHeight =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.MaxDropDownHeightProperty

    let PlaceholderText =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.PlaceholderTextProperty

    let PlaceholderForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget ComboBox.PlaceholderForegroundProperty

    let PlaceholderForeground =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.PlaceholderForegroundProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.VerticalContentAlignmentProperty

    let DropDownOpened =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Opened" ComboBox.IsDropDownOpenProperty

[<AutoOpen>]
module ComboBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ComboBox widget.</summary>
        /// <param name="items">The items to display in the ComboBox.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member ComboBox(items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>) =
            WidgetHelpers.buildItems<'msg, IFabComboBox, 'itemData, 'itemMarker> ComboBox.WidgetKey ItemsControl.ItemsSource items template

        /// <summary>Creates a ComboBox widget.</summary>
        static member ComboBox() =
            CollectionBuilder<'msg, IFabComboBox, IFabComboBoxItem>(ComboBox.WidgetKey, ItemsControl.Items)

[<Extension>]
type ComboBoxModifiers =
    /// <summary>Sets the IsDropDownOpen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDropDownOpen value.</param>
    [<Extension>]
    static member inline isDropDownOpen(this: WidgetBuilder<'msg, #IFabComboBox>, value: bool) =
        this.AddScalar(ComboBox.IsDropDownOpen.WithValue(value))

    /// <summary>Sets the MaxDropDownHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxDropDownHeight value.</param>
    [<Extension>]
    static member inline maxDropDownHeight(this: WidgetBuilder<'msg, #IFabComboBox>, value: double) =
        this.AddScalar(ComboBox.MaxDropDownHeight.WithValue(value))

    /// <summary>Sets the PlaceholderText property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderText value.</param>
    [<Extension>]
    static member inline placeholderText(this: WidgetBuilder<'msg, #IFabComboBox>, value: string) =
        this.AddScalar(ComboBox.PlaceholderText.WithValue(value))

    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(ComboBox.PlaceholderForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the PlaceholderForeground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderForeground value.</param>
    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, value: IBrush) =
        this.AddScalar(ComboBox.PlaceholderForeground.WithValue(value))

    /// <summary>Sets the HorizontalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalContentAlignment value.</param>
    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: HorizontalAlignment) =
        this.AddScalar(ComboBox.HorizontalContentAlignment.WithValue(value))

    /// <summary>Sets the VerticalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalContentAlignment value.</param>
    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: VerticalAlignment) =
        this.AddScalar(ComboBox.VerticalContentAlignment.WithValue(value))

    /// <summary>Listens to the ComboBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">Weather the drop down is open or not.</param>
    /// <param name="fn">Raised when the DropDownOpened event fires.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabComboBox>, isOpen: bool, fn: bool -> 'msg) =
        this.AddScalar(ComboBox.DropDownOpened.WithValue(ValueEventData.create isOpen fn))

    /// <summary>Link a ViewRef to access the direct ComboBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComboBox>, value: ViewRef<ComboBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type ComboBoxExtraModifier =
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

[<Extension>]
type ComboBoxCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabComboBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabComboBoxItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabComboBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabComboBoxItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
