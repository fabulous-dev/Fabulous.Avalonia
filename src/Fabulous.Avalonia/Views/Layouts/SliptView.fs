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

    [<Extension>]
    static member inline compactPaneLength(this: WidgetBuilder<'msg, #IFabSplitView>, value: float) =
        this.AddScalar(SplitView.CompactPaneLength.WithValue(value))

    [<Extension>]
    static member inline displayMode(this: WidgetBuilder<'msg, #IFabSplitView>, value: SplitViewDisplayMode) =
        this.AddScalar(SplitView.DisplayMode.WithValue(value))

    [<Extension>]
    static member inline isPaneOpen(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool) =
        this.AddScalar(SplitView.IsPaneOpen.WithValue(value))

    [<Extension>]
    static member inline openPaneLength(this: WidgetBuilder<'msg, #IFabSplitView>, value: float) =
        this.AddScalar(SplitView.OpenPaneLength.WithValue(value))

    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(SplitView.PaneBackgroundWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, brush: IBrush) =
        this.AddScalar(SplitView.PaneBackground.WithValue(brush))

    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabSplitView>, brush: string) =
        this.AddScalar(SplitView.PaneBackground.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline panePlacement(this: WidgetBuilder<'msg, #IFabSplitView>, value: SplitViewPanePlacement) =
        this.AddScalar(SplitView.PanePlacement.WithValue(value))

    [<Extension>]
    static member inline useLightDismissOverlayMode(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool) =
        this.AddScalar(SplitView.UseLightDismissOverlayMode.WithValue(value))

    [<Extension>]
    static member inline closedPaneWidth(this: WidgetBuilder<'msg, #IFabSplitView>, value: float) =
        this.AddScalar(SplitView.ClosedPaneWidth.WithValue(value))

    [<Extension>]
    static member inline paneColumnGridLength(this: WidgetBuilder<'msg, #IFabSplitView>, value: GridLength) =
        this.AddScalar(SplitView.PaneColumnGridLength.WithValue(value))

    [<Extension>]
    static member inline onPanClosed(this: WidgetBuilder<'msg, #IFabSplitView>, onPanClosed: RoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanClosed.WithValue(fun args -> onPanClosed args |> box))

    [<Extension>]

    static member inline onPanClosing(this: WidgetBuilder<'msg, #IFabSplitView>, onPanClosing: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanClosing.WithValue(fun args -> onPanClosing args |> box))

    [<Extension>]
    static member inline onPanOpened(this: WidgetBuilder<'msg, #IFabSplitView>, onPanOpened: RoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanOpened.WithValue(fun args -> onPanOpened args |> box))

    [<Extension>]
    static member inline onPanOpening(this: WidgetBuilder<'msg, #IFabSplitView>, onPanOpening: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(SplitView.PanOpening.WithValue(fun args -> onPanOpening args |> box))

    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool, onChanged: bool -> 'msg) =
        this.AddScalar(SplitView.IsPresented.WithValue(ValueEventData.create value (fun v -> onChanged v |> box)))

    /// <summary>Link a ViewRef to access the direct SplitView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSplitView>, value: ViewRef<SplitView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
