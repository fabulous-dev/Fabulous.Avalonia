namespace Fabulous.Avalonia

open Fabulous

[<AutoOpen>]
module ComponentsMenuBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Menu widget.</summary>
        static member Menu() =
            CollectionBuilder<'msg, IFabMenu, IFabMenuItem>(Menu.WidgetKey, ComponentItemsControl.Items)
