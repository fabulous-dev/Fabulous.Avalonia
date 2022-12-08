namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabScrollViewer =
    inherit IFabContentControl

module ScrollViewer =
    let WidgetKey = Widgets.register<ScrollViewer> ()

    let CanHorizontallyScroll =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.CanHorizontallyScrollProperty

    let CanVerticallyScroll =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.CanVerticallyScrollProperty

    let Extent =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.ExtentProperty

    let Offset =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.OffsetProperty

    let Viewport =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.ViewportProperty

    let LargeChange =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.LargeChangeProperty

    let SmallChange =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.SmallChangeProperty

    let HorizontalScrollBarMaximum =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalScrollBarMaximumProperty

    let HorizontalScrollBarValue =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalScrollBarValueProperty

    let HorizontalScrollBarViewportSize =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalScrollBarViewportSizeProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalScrollBarVisibilityProperty

    let VerticalScrollBarMaximum =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalScrollBarMaximumProperty

    let VerticalScrollBarValue =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalScrollBarValueProperty

    let VerticalScrollBarViewportSize =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalScrollBarViewportSizeProperty

    let VerticalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalScrollBarVisibilityProperty


    let AllowAutoHide =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.AllowAutoHideProperty

    let IsScrollChainingEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.IsScrollChainingEnabledProperty

    let ScrollChanged =
        Attributes.defineEvent "ScrollViewer_ScrollChangedEvent" (fun target -> (target :?> ScrollViewer).ScrollChanged)

[<AutoOpen>]
module ScrollViewerBuilders =
    type Fabulous.Avalonia.View with

        static member inline ScrollViewer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabScrollViewer>(
                ScrollViewer.WidgetKey,
                AttributesBundle(
                    StackList.empty (),
                    ValueSome [| ContentControl.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ScrollViewerModifiers =
    [<Extension>]
    static member inline canHorizontallyScroll(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.CanHorizontallyScroll.WithValue(value))

    [<Extension>]
    static member inline canVerticallyScroll(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.CanVerticallyScroll.WithValue(value))

    [<Extension>]
    static member inline extent(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Size) =
        this.AddScalar(ScrollViewer.Extent.WithValue(value))

    [<Extension>]
    static member inline offset(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Vector) =
        this.AddScalar(ScrollViewer.Offset.WithValue(value))

    [<Extension>]
    static member inline viewport(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Size) =
        this.AddScalar(ScrollViewer.Viewport.WithValue(value))

    [<Extension>]
    static member inline largeChange(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Size) =
        this.AddScalar(ScrollViewer.LargeChange.WithValue(value))

    [<Extension>]
    static member inline smallChange(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Size) =
        this.AddScalar(ScrollViewer.SmallChange.WithValue(value))

    [<Extension>]
    static member inline horizontalScrollBarMaximum(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: float) =
        this.AddScalar(ScrollViewer.HorizontalScrollBarMaximum.WithValue(value))

    [<Extension>]
    static member inline horizontalScrollBarValue(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: float) =
        this.AddScalar(ScrollViewer.HorizontalScrollBarValue.WithValue(value))

    [<Extension>]
    static member inline horizontalScrollBarViewportSize(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: float) =
        this.AddScalar(ScrollViewer.HorizontalScrollBarViewportSize.WithValue(value))

    [<Extension>]
    static member inline horizontalScrollBarVisibility
        (
            this: WidgetBuilder<'msg, #IFabScrollViewer>,
            value: ScrollBarVisibility
        ) =
        this.AddScalar(ScrollViewer.HorizontalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline verticalScrollBarMaximum(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: float) =
        this.AddScalar(ScrollViewer.VerticalScrollBarMaximum.WithValue(value))

    [<Extension>]
    static member inline verticalScrollBarValue(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: float) =
        this.AddScalar(ScrollViewer.VerticalScrollBarValue.WithValue(value))

    [<Extension>]
    static member inline verticalScrollBarViewportSize(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: float) =
        this.AddScalar(ScrollViewer.VerticalScrollBarViewportSize.WithValue(value))

    [<Extension>]
    static member inline verticalScrollBarVisibility
        (
            this: WidgetBuilder<'msg, #IFabScrollViewer>,
            value: ScrollBarVisibility
        ) =
        this.AddScalar(ScrollViewer.VerticalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline allowAutoHide(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.AllowAutoHide.WithValue(value))

    [<Extension>]
    static member inline isScrollChainingEnabled(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ScrollViewer.IsScrollChainingEnabled.WithValue(value))

    [<Extension>]
    static member inline onScrollChanged
        (
            this: WidgetBuilder<'msg, #IFabScrollViewer>,
            onScrollChanged: ScrollChangedEventArgs -> 'msg
        ) =
        this.AddScalar(ScrollViewer.ScrollChanged.WithValue(fun args -> onScrollChanged args |> box))
