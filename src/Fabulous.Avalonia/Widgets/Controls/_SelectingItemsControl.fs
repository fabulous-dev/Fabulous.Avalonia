namespace Fabulous.Avalonia

open Avalonia.Collections
open Avalonia.Controls
open Fabulous

type IFabSelectingItemsControl =
    inherit IFabItemsControl

module SelectingItemsControl =
    let Items =
        Attributes.defineAvaloniaListWidgetCollection "ItemsControl_Items" (fun target ->
            (target :?> ItemsControl).Items :?> IAvaloniaList<_>)

    let ItemCount =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.ItemCountProperty

    let ItemsPanel =
        Attributes.defineAvaloniaPropertyWidget ItemsControl.ItemsPanelProperty
