namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
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

    let PlaceholderForeground =
        Attributes.defineAvaloniaPropertyWidget ComboBox.PlaceholderForegroundProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ComboBox.VerticalContentAlignmentProperty

    let DropDownOpened =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Opened" ComboBox.IsDropDownOpenProperty

[<AutoOpen>]
module ComboBoxBuilders =
    type Fabulous.Avalonia.View with

        static member ComboBox() =
            CollectionBuilder<'msg, IFabComboBox, IFabComboBoxItem>(ComboBox.WidgetKey, ItemsControl.Items)

        static member ComboBox(isOpen: bool, onDropDownOpened: bool -> 'msg) =
            CollectionBuilder<'msg, IFabComboBox, IFabComboBoxItem>(
                ComboBox.WidgetKey,
                ItemsControl.Items,
                ComboBox.DropDownOpened.WithValue(ValueEventData.create isOpen (fun args -> onDropDownOpened args |> box))
            )


[<Extension>]
type ComboBoxModifiers =
    [<Extension>]
    static member inline isDropDownOpen(this: WidgetBuilder<'msg, #IFabComboBox>, value: bool) =
        this.AddScalar(ComboBox.IsDropDownOpen.WithValue(value))

    [<Extension>]
    static member inline maxDropDownHeight(this: WidgetBuilder<'msg, #IFabComboBox>, value: double) =
        this.AddScalar(ComboBox.MaxDropDownHeight.WithValue(value))

    [<Extension>]
    static member inline placeholderText(this: WidgetBuilder<'msg, #IFabComboBox>, value: string) =
        this.AddScalar(ComboBox.PlaceholderText.WithValue(value))

    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(ComboBox.PlaceholderForeground.WithValue(content.Compile()))

    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: HorizontalAlignment) =
        this.AddScalar(ComboBox.HorizontalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: VerticalAlignment) =
        this.AddScalar(ComboBox.VerticalContentAlignment.WithValue(value))

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
