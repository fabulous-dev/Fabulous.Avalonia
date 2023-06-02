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
    let WidgetKey = Widgets.register<ScrollViewer>()

    let Extent =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.ExtentProperty

    let Offset =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.OffsetProperty

    let BringIntoViewOnFocusChange =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.BringIntoViewOnFocusChangeProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalScrollBarVisibilityProperty

    let VerticalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalScrollBarVisibilityProperty

    let AllowAutoHide =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.AllowAutoHideProperty

    let IsScrollChainingEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.IsScrollChainingEnabledProperty

    let HorizontalSnapPointsAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalSnapPointsAlignmentProperty

    let HorizontalSnapPointsType =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.HorizontalSnapPointsTypeProperty

    let VerticalSnapPointsAlignment =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalSnapPointsAlignmentProperty

    let VerticalSnapPointsType =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.VerticalSnapPointsTypeProperty

    let IsScrollInertiaEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ScrollViewer.IsScrollInertiaEnabledProperty

    let ScrollChanged =
        Attributes.defineEvent "ScrollViewer_ScrollChangedEvent" (fun target -> (target :?> ScrollViewer).ScrollChanged)

[<AutoOpen>]
module ScrollViewerBuilders =
    type Fabulous.Avalonia.View with

        static member inline ScrollViewer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabScrollViewer>(
                ScrollViewer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type ScrollViewerModifiers =
    [<Extension>]
    static member inline extent(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Size) =
        this.AddScalar(ScrollViewer.Extent.WithValue(value))

    [<Extension>]
    static member inline offset(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: Vector) =
        this.AddScalar(ScrollViewer.Offset.WithValue(value))

    [<Extension>]
    static member inline horizontalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollViewer.HorizontalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline verticalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollViewer.VerticalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline allowAutoHide(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.AllowAutoHide.WithValue(value))

    [<Extension>]
    static member inline isScrollChainingEnabled(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ScrollViewer.IsScrollChainingEnabled.WithValue(value))

    [<Extension>]
    static member inline horizontalSnapPointsAlignment(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsAlignment) =
        this.AddScalar(ScrollViewer.HorizontalSnapPointsAlignment.WithValue(value))

    [<Extension>]
    static member inline horizontalSnapPointsType(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsType) =
        this.AddScalar(ScrollViewer.HorizontalSnapPointsType.WithValue(value))

    [<Extension>]
    static member inline verticalSnapPointsAlignment(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsAlignment) =
        this.AddScalar(ScrollViewer.VerticalSnapPointsAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalSnapPointsType(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: SnapPointsType) =
        this.AddScalar(ScrollViewer.VerticalSnapPointsType.WithValue(value))

    [<Extension>]
    static member inline isScrollInertiaEnabled(this: WidgetBuilder<'msg, #IFabScrollViewer>, value: bool) =
        this.AddScalar(ScrollViewer.IsScrollInertiaEnabled.WithValue(value))

    [<Extension>]
    static member inline onScrollChanged(this: WidgetBuilder<'msg, #IFabScrollViewer>, onScrollChanged: ScrollChangedEventArgs -> 'msg) =
        this.AddScalar(ScrollViewer.ScrollChanged.WithValue(fun args -> onScrollChanged args |> box))

    /// <summary>Link a ViewRef to access the direct ScrollViewer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabScrollViewer>, value: ViewRef<ScrollViewer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type ScrollViewerAttachedModifiers =
    [<Extension>]
    static member inline bringIntoViewOnFocusChange(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ScrollViewer.BringIntoViewOnFocusChange.WithValue(value))
