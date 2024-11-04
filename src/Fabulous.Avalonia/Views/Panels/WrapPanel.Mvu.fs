namespace Fabulous.Avalonia

open Avalonia.Layout
open Fabulous

[<AutoOpen>]
module MvuWrapPanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Vertical" />
        /// rendering child elements from left to right while they fit the width and starting a new line when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member VWrap() =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(WrapPanel.WidgetKey, MvuPanel.Children, WrapPanel.Orientation.WithValue(Orientation.Vertical))

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Horizontal" />
        /// rendering child elements from top to bottom while they fit the height and starting a new column when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member HWrap() =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(WrapPanel.WidgetKey, MvuPanel.Children, WrapPanel.Orientation.WithValue(Orientation.Horizontal))
