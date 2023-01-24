namespace Fabulous.Avalonia

open Avalonia.Controls
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

    let PaneBackground =
        Attributes.defineAvaloniaPropertyWidget SplitView.PaneBackgroundProperty

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
        this.AddWidget(SplitView.PaneBackground.WithValue(content.Compile()))

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
    static member inline onPanClosed(this: WidgetBuilder<'msg, #IFabSplitView>, onPanClosed: 'msg) =
        this.AddScalar(SplitView.PanClosed.WithValue(fun _ -> onPanClosed |> box))

    [<Extension>]

    static member inline onPanClosing(this: WidgetBuilder<'msg, #IFabSplitView>, onPanClosing: bool -> 'msg) =
        this.AddScalar(SplitView.PanClosing.WithValue(fun args -> onPanClosing args.Cancel |> box))

    [<Extension>]
    static member inline onPanOpened(this: WidgetBuilder<'msg, #IFabSplitView>, onPanOpened: 'msg) =
        this.AddScalar(SplitView.PanOpened.WithValue(fun _ -> onPanOpened |> box))

    [<Extension>]
    static member inline onPanOpening(this: WidgetBuilder<'msg, #IFabSplitView>, onPanOpening: 'msg) =
        this.AddScalar(SplitView.PanOpening.WithValue(fun _ -> onPanOpening |> box))

    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFabSplitView>, value: bool, onChanged: bool -> 'msg) =
        this.AddScalar(SplitView.IsPresented.WithValue(ValueEventData.create value (fun v -> onChanged v |> box)))
