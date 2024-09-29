namespace Fabulous.Avalonia.Components

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open System.Runtime.CompilerServices

type IFabComponentSplitView =
    inherit IFabComponentContentControl
    inherit IFabSplitView

module ComponentSplitView =
    let PanClosed =
        ComponentAttributes.defineEvent "SplitView_PanClosed" (fun target -> (target :?> SplitView).PaneClosed)

    let PanClosing =
        ComponentAttributes.defineEvent "SplitView_PanClosing" (fun target -> (target :?> SplitView).PaneClosing)

    let PanOpened =
        ComponentAttributes.defineEvent "SplitView_PanOpened" (fun target -> (target :?> SplitView).PaneOpened)

    let PanOpening =
        ComponentAttributes.defineEvent "SplitView_PanOpening" (fun target -> (target :?> SplitView).PaneOpening)

    let IsPresented =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "SplitView_IsPresented" SplitView.IsPaneOpenProperty

[<AutoOpen>]
module ComponentSplitViewBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a SplitView widget.</summary>
        /// <param name="pane">The content of the pane.</param>
        /// <param name="content">The content to display.</param>
        static member SplitView(pane: WidgetBuilder<'msg, #IFabComponentControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentSplitView>(
                SplitView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| SplitView.Pane.WithValue(pane.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueSome [||]
                )
            )

type ComponentSplitViewModifiers =
    /// <summary>Listens to the SplitView PanClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosed event fires.</param>
    [<Extension>]
    static member inline onPanClosed(this: WidgetBuilder<unit, #IFabSplitView>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentSplitView.PanClosed.WithValue(fn))

    /// <summary>Listens to the SplitView PanClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosing event fires.</param>
    [<Extension>]
    static member inline onPanClosing(this: WidgetBuilder<unit, #IFabSplitView>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(ComponentSplitView.PanClosing.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpened event fires.</param>
    [<Extension>]
    static member inline onPanOpened(this: WidgetBuilder<'msg, #IFabSplitView>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentSplitView.PanOpened.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpening event fires.</param>
    [<Extension>]
    static member inline onPanOpening(this: WidgetBuilder<'msg, #IFabSplitView>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(ComponentSplitView.PanOpening.WithValue(fn))

    /// <summary>Listens to the SplitView IsPresented event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsPresented value.</param>
    /// <param name="fn">Raised when the IsPresented event fires.</param>
    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool, fn: bool -> unit) =
        this.AddScalar(ComponentSplitView.IsPresented.WithValue(ComponentValueEventData.create value fn))

type ComponentSplitViewExtraModifiers =
    /// <summary>Sets the PaneBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneBackground value.</param>
    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<unit, #IFabSplitView>, value: Color) =
        SplitViewModifiers.paneBackground(this, View.SolidColorBrush(value))

    /// <summary>Sets the PaneBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneBackground value.</param>
    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<unit, #IFabSplitView>, value: string) =
        SplitViewModifiers.paneBackground(this, View.SolidColorBrush(value))
