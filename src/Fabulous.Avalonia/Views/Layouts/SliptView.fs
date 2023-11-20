namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open System.Runtime.CompilerServices

type IFabSplitView =
    inherit IFabContentControl

module SplitView =
    let WidgetKey = Widgets.register<SplitView>()

    let CompactPaneLength =
        Attributes.defineAvaloniaPropertyWithEquality SplitView.CompactPaneLengthProperty

    let DisplayMode =
        Attributes.defineAvaloniaPropertyWithEquality SplitView.DisplayModeProperty

    let IsPaneOpen =
        Attributes.defineAvaloniaPropertyWithEquality SplitView.IsPaneOpenProperty

    let OpenPaneLength =
        Attributes.defineAvaloniaPropertyWithEquality SplitView.OpenPaneLengthProperty

    let PaneBackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget SplitView.PaneBackgroundProperty

    let PaneBackground =
        Attributes.defineAvaloniaPropertyWithEquality SplitView.PaneBackgroundProperty

    let PanePlacement =
        Attributes.defineAvaloniaPropertyWithEquality SplitView.PanePlacementProperty

    let Pane = Attributes.defineAvaloniaPropertyWidget SplitView.PaneProperty

    let UseLightDismissOverlayMode =
        Attributes.defineAvaloniaPropertyWithEquality SplitView.UseLightDismissOverlayModeProperty

    let ClosedPaneWidth =
        Attributes.defineAvaloniaPropertyWithEquality SplitViewTemplateSettings.ClosedPaneWidthProperty

    let PaneColumnGridLength =
        Attributes.defineAvaloniaPropertyWithEquality SplitViewTemplateSettings.PaneColumnGridLengthProperty

    let PanClosed =
        Attributes.defineEvent "SplitView_PanClosed" (fun target -> (target :?> SplitView).PaneClosed)

    let PanClosing =
        Attributes.defineEvent "SplitView_PanClosing" (fun target -> (target :?> SplitView).PaneClosing)

    let PanOpened =
        Attributes.defineEvent "SplitView_PanOpened" (fun target -> (target :?> SplitView).PaneOpened)

    let PanOpening =
        Attributes.defineEvent "SplitView_PanOpening" (fun target -> (target :?> SplitView).PaneOpening)

    let IsPresented =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "SplitView_IsPresented" SplitView.IsPaneOpenProperty

[<AutoOpen>]
module SplitViewBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a SplitView widget.</summary>
        /// <param name="pane">The content of the pane.</param>
        /// <param name="content">The content to display.</param>
        static member inline SplitView(pane: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabSplitView>(
                SplitView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| SplitView.Pane.WithValue(pane.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueSome [||]
                )
            )

[<Extension>]
type SplitViewModifiers =
    /// <summary>Sets the CompactPaneLength property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CompactPaneLength value.</param>
    [<Extension>]
    static member inline compactPaneLength(this: WidgetBuilder<'msg, #IFabSplitView>, value: float) =
        this.AddScalar(SplitView.CompactPaneLength.WithValue(value))

    /// <summary>Sets the DisplayMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayMode value.</param>
    [<Extension>]
    static member inline displayMode(this: WidgetBuilder<'msg, #IFabSplitView>, value: SplitViewDisplayMode) =
        this.AddScalar(SplitView.DisplayMode.WithValue(value))

    /// <summary>Sets the IsPaneOpen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsPaneOpen value.</param>
    [<Extension>]
    static member inline isPaneOpen(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool) =
        this.AddScalar(SplitView.IsPaneOpen.WithValue(value))

    /// <summary>Sets the OpenPaneLength property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpenPaneLength value.</param>
    [<Extension>]
    static member inline openPaneLength(this: WidgetBuilder<'msg, #IFabSplitView>, value: float) =
        this.AddScalar(SplitView.OpenPaneLength.WithValue(value))

    /// <summary>Sets the PaneBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneBackground value.</param>
    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(SplitView.PaneBackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the PaneBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneBackground value.</param>
    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, value: IBrush) =
        this.AddScalar(SplitView.PaneBackground.WithValue(value))

    /// <summary>Sets the PaneBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneBackground value.</param>
    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, value: string) =
        this.AddScalar(SplitView.PaneBackground.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Sets the PanePlacement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PanePlacement value.</param>
    [<Extension>]
    static member inline panePlacement(this: WidgetBuilder<'msg, #IFabSplitView>, value: SplitViewPanePlacement) =
        this.AddScalar(SplitView.PanePlacement.WithValue(value))

    /// <summary>Sets the UseLightDismissOverlayMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The UseLightDismissOverlayMode value.</param>
    [<Extension>]
    static member inline useLightDismissOverlayMode(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool) =
        this.AddScalar(SplitView.UseLightDismissOverlayMode.WithValue(value))

    /// <summary>Sets the ClosedPaneWidth event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClosedPaneWidth value.</param>
    [<Extension>]
    static member inline closedPaneWidth(this: WidgetBuilder<'msg, #IFabSplitView>, value: float) =
        this.AddScalar(SplitView.ClosedPaneWidth.WithValue(value))

    /// <summary>Sets the PaneColumnGridLength event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaneColumnGridLength value.</param>
    [<Extension>]
    static member inline paneColumnGridLength(this: WidgetBuilder<'msg, #IFabSplitView>, value: GridLength) =
        this.AddScalar(SplitView.PaneColumnGridLength.WithValue(value))

    /// <summary>Listens to the SplitView PanClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosed event fires.</param>
    [<Extension>]
    static member inline onPanClosed(this: WidgetBuilder<'msg, #IFabSplitView>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanClosed.WithValue(fn))

    /// <summary>Listens to the SplitView PanClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanClosing event fires.</param>
    [<Extension>]
    static member inline onPanClosing(this: WidgetBuilder<'msg, #IFabSplitView>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanClosing.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpened event fires.</param>
    [<Extension>]
    static member inline onPanOpened(this: WidgetBuilder<'msg, #IFabSplitView>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanOpened.WithValue(fn))

    /// <summary>Listens to the SplitView PanOpening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PanOpening event fires.</param>
    [<Extension>]
    static member inline onPanOpening(this: WidgetBuilder<'msg, #IFabSplitView>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanOpening.WithValue(fn))

    /// <summary>Listens to the SplitView IsPresented event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsPresented value.</param>
    /// <param name="fn">Raised when the IsPresented event fires.</param>
    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool, fn: bool -> 'msg) =
        this.AddScalar(SplitView.IsPresented.WithValue(ValueEventData.create value fn))

    /// <summary>Link a ViewRef to access the direct SplitView control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSplitView>, value: ViewRef<SplitView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
