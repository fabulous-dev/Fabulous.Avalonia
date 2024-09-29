namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open System.Runtime.CompilerServices

type IFabMvuSplitView =
    inherit IFabMvuContentControl
    inherit IFabSplitView

module MvuSplitView =
    let PanClosed =
        MvuAttributes.defineEvent "SplitView_PanClosed" (fun target -> (target :?> SplitView).PaneClosed)

    let PanClosing =
        MvuAttributes.defineEvent "SplitView_PanClosing" (fun target -> (target :?> SplitView).PaneClosing)

    let PanOpened =
        MvuAttributes.defineEvent "SplitView_PanOpened" (fun target -> (target :?> SplitView).PaneOpened)

    let PanOpening =
        MvuAttributes.defineEvent "SplitView_PanOpening" (fun target -> (target :?> SplitView).PaneOpening)

    let IsPresented =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "SplitView_IsPresented" SplitView.IsPaneOpenProperty

[<AutoOpen>]
module MvuSplitViewBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a SplitView widget.</summary>
        /// <param name="pane">The content of the pane.</param>
        /// <param name="content">The content to display.</param>
        static member SplitView(pane: WidgetBuilder<'msg, #IFabMvuControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabMvuSplitView>(
                SplitView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| SplitView.Pane.WithValue(pane.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueSome [||]
                )
            )

type MvuSplitViewModifiers =
    /// <summary>Listens to the SplitView PanClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosed event fires.</param>
    [<Extension>]
    static member inline onPanClosed(this: WidgetBuilder<unit, #IFabSplitView>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuSplitView.PanClosed.WithValue(fn))

    /// <summary>Listens to the SplitView PanClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosing event fires.</param>
    [<Extension>]
    static member inline onPanClosing(this: WidgetBuilder<unit, #IFabSplitView>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(MvuSplitView.PanClosing.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpened event fires.</param>
    [<Extension>]
    static member inline onPanOpened(this: WidgetBuilder<'msg, #IFabSplitView>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuSplitView.PanOpened.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpening event fires.</param>
    [<Extension>]
    static member inline onPanOpening(this: WidgetBuilder<'msg, #IFabSplitView>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(MvuSplitView.PanOpening.WithValue(fn))

    /// <summary>Listens to the SplitView IsPresented event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsPresented value.</param>
    /// <param name="fn">Raised when the IsPresented event fires.</param>
    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool, fn: bool -> unit) =
        this.AddScalar(MvuSplitView.IsPresented.WithValue(MvuValueEventData.create value fn))

type MvuSplitViewExtraModifiers =
    /// <summary>Sets the PaneBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneBackground value.</param>
    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, value: Color) =
        SplitViewModifiers.paneBackground(this, View.SolidColorBrush(value))

    /// <summary>Sets the PaneBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneBackground value.</param>
    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, value: string) =
        SplitViewModifiers.paneBackground(this, View.SolidColorBrush(value))
