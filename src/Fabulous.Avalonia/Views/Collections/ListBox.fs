namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabListBox =
    inherit IFabSelectingItemsControl

module ListBox =
    let WidgetKey = Widgets.register<ListBox>()

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.SelectionModeProperty


[<AutoOpen>]
module ListBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline ListBox<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabListBox, 'itemData, 'itemMarker> ListBox.WidgetKey ItemsControl.ItemsSource items template

[<Extension>]
type ListBoxModifiers =
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabListBox>, value: SelectionMode) =
        this.AddScalar(ListBox.SelectionMode.WithValue(value))
