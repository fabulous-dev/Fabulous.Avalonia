namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous

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

        static member ComboBox(items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>) =
            WidgetHelpers.buildItems<'msg, IFabComboBox, 'itemData, 'itemMarker> ComboBox.WidgetKey ItemsControl.ItemsSource items template

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
        this.AddWidget(ComboBox.PlaceholderForegroundWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, brush: IBrush) =
        this.AddScalar(ComboBox.PlaceholderForeground.WithValue(brush))

    [<Extension>]
    static member inline placeholderForeground(this: WidgetBuilder<'msg, #IFabComboBox>, brush: string) =
        this.AddScalar(ComboBox.PlaceholderForeground.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: HorizontalAlignment) =
        this.AddScalar(ComboBox.HorizontalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabComboBox>, value: VerticalAlignment) =
        this.AddScalar(ComboBox.VerticalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabComboBox>, isOpen: bool, onDropDownOpened: bool -> 'msg) =
        this.AddScalar(ComboBox.DropDownOpened.WithValue(ValueEventData.create isOpen (fun args -> onDropDownOpened args |> box)))

    /// <summary>Link a ViewRef to access the direct ComboBox control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComboBox>, value: ViewRef<ComboBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
