namespace Fabulous.Avalonia

open Fabulous

[<AutoOpen>]
module MvuMenuBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Menu widget.</summary>
        static member Menu() =
            CollectionBuilder<'msg, IFabMenu, IFabMenuItem>(Menu.WidgetKey, MvuItemsControl.Items)
