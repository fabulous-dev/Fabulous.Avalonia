namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.Avalonia

[<AutoOpen>]
module MvuPanelBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Panel widget.</summary>
        static member Panel() =
            CollectionBuilder<unit, IFabMvuPanel, IFabMvuControl>(Panel.WidgetKey, MvuPanel.Children)

type MvuPanelModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabMvuPanel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Panel.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabMvuPanel>, value: IBrush) =
        this.AddScalar(Panel.Background.WithValue(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabMvuPanel>, value: WidgetBuilder<unit, #IFabMvuBrush>) =
        this.AddWidget(TextElement.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabMvuPanel>, value: IBrush) =
        this.AddScalar(TextElement.Foreground.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Panel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuPanel>, value: ViewRef<Panel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type MvuPanelExtraModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabMvuPanel>, value: Color) =
        PanelModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabMvuPanel>, value: string) =
        PanelModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabMvuPanel>, value: Color) =
        PanelModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabMvuPanel>, value: string) =
        PanelModifiers.foreground(this, View.SolidColorBrush(value))

type MvuPanelCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabMvuPanel and 'itemType :> IFabMvuControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabMvuPanel and 'itemType :> IFabMvuControl>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuControl>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
