namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Selection
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabListBox =
    inherit IFabSelectingItemsControl

module ListBox =
    let WidgetKey = Widgets.register<ListBox>()

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.SelectionModeProperty

    let SelectionModel =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.SelectionProperty

[<AutoOpen>]
module ListBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline ListBox<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabListBox, 'itemData, 'itemMarker> ListBox.WidgetKey ItemsControl.ItemsSource items template
            
        static member ListBox() =
            CollectionBuilder<'msg, IFabListBox, IFabListBoxItem>(ListBox.WidgetKey, ItemsControl.Items)

[<Extension>]
type ListBoxModifiers =
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabListBox>, value: SelectionMode) =
        this.AddScalar(ListBox.SelectionMode.WithValue(value))

    [<Extension>]
    static member inline selectionModel(this: WidgetBuilder<'msg, #IFabListBox>, value: ISelectionModel) =
        this.AddScalar(ListBox.SelectionModel.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ListBox control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabListBox>, value: ViewRef<ListBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
        
[<Extension>]
type ListBoxCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabListBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabListBoxItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabListBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabListBoxItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
