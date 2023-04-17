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

        static member Panel<'msg>() =
            CollectionBuilder<'msg, IFabPanel, IFabControl>(Panel.WidgetKey, Panel.Children)

[<Extension>]
type PanelModifiers =
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, brush: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Panel.BackgroundWidget.WithValue(brush.Compile()))

    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, brush: IBrush) =
        this.AddScalar(Panel.Background.WithValue(brush))

    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, brush: string) =
        this.AddScalar(Panel.Background.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextElement.ForegroundWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, brush: IBrush) =
        this.AddScalar(TextElement.Foreground.WithValue(brush))

    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabPanel>, brush: string) =
        this.AddScalar(TextElement.Foreground.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

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
