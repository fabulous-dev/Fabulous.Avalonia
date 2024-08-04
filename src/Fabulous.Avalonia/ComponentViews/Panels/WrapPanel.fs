namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentWrapPanel =
    inherit IFabComponentPanel
    inherit IFabWrapPanel

[<AutoOpen>]
module ComponentWrapPanelBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Vertical" />
        /// rendering child elements from left to right while they fit the width and starting a new line when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member VWrap() =
            CollectionBuilder<unit, IFabComponentWrapPanel, IFabComponentControl>(WrapPanel.WidgetKey, ComponentPanel.Children, WrapPanel.Orientation.WithValue(Orientation.Vertical))

        /// <summary>Creates a <see cref="WrapPanel" /> with <see cref="WrapPanel.Orientation" /> set to <see cref="Orientation.Horizontal" />
        /// rendering child elements from top to bottom while they fit the height and starting a new column when there is no space left
        /// (including any margins and borders). See <seealso href="https://docs.avaloniaui.net/docs/reference/controls/detailed-reference/wrappanel" />.</summary>
        static member HWrap() =
            CollectionBuilder<unit, IFabComponentWrapPanel, IFabComponentControl>(WrapPanel.WidgetKey, ComponentPanel.Children, WrapPanel.Orientation.WithValue(Orientation.Horizontal))

type ComponentWrapPanelModifiers =

    /// <summary>Link a ViewRef to access the direct WrapPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabWrapPanel>, value: ViewRef<WrapPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
