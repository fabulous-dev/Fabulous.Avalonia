namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.Avalonia

[<AutoOpen>]
module ComponentPanelBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Panel widget.</summary>
        static member Panel() =
            CollectionBuilder<unit, IFabComponentPanel, IFabComponentControl>(Panel.WidgetKey, ComponentPanel.Children)

type ComponentPanelModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabComponentPanel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Panel.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabComponentPanel>, value: IBrush) =
        this.AddScalar(Panel.Background.WithValue(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabComponentPanel>, value: WidgetBuilder<unit, #IFabComponentBrush>) =
        this.AddWidget(TextElement.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabComponentPanel>, value: IBrush) =
        this.AddScalar(TextElement.Foreground.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Panel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentPanel>, value: ViewRef<Panel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ComponentPanelExtraModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabComponentPanel>, value: Color) =
        PanelModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabComponentPanel>, value: string) =
        PanelModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabComponentPanel>, value: Color) =
        PanelModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabComponentPanel>, value: string) =
        PanelModifiers.foreground(this, View.SolidColorBrush(value))

type ComponentPanelCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabComponentPanel and 'itemType :> IFabComponentControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabComponentPanel and 'itemType :> IFabComponentControl>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentControl>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
