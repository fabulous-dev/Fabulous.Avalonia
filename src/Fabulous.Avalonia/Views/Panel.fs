namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabPanel =
    inherit IFabControl

module Panel =
    let WidgetKey = Widgets.register<Panel>()

    let BackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget Panel.BackgroundProperty

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality Panel.BackgroundProperty

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "Panel_Children" (fun x -> (x :?> Panel).Children)

[<AutoOpen>]
module PanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Panel widget.</summary>
        static member Panel<'msg>() =
            CollectionBuilder<'msg, IFabPanel, IFabControl>(Panel.WidgetKey, Panel.Children)

[<Extension>]
type PanelModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Panel.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: IBrush) =
        this.AddScalar(Panel.Background.WithValue(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: Color) =
        this.AddScalar(Panel.Background.WithValue(value |> ImmutableSolidColorBrush))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, value: string) =
        this.AddScalar(Panel.Background.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextElement.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: IBrush) =
        this.AddScalar(TextElement.Foreground.WithValue(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: Color) =
        this.AddScalar(TextElement.Foreground.WithValue(value |> ImmutableSolidColorBrush))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, value: string) =
        this.AddScalar(TextElement.Foreground.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

[<Extension>]
type PanelCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabPanel and 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabPanel and 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
