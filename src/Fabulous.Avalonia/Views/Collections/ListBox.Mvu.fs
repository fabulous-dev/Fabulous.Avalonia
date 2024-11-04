namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia


[<AutoOpen>]
module MvuListBoxBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ListBox widget.</summary>
        static member ListBox() =
            CollectionBuilder<'msg, IFabListBox, IFabListBoxItem>(ListBox.WidgetKey, MvuItemsControl.Items)
