namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabRefreshVisualizer =
    inherit IFabContentControl

module RefreshVisualizer =
    let WidgetKey = Widgets.register<RefreshVisualizer>()

    let RefreshRequested =
        Attributes.defineEvent<RefreshRequestedEventArgs> "RefreshVisualizer_RefreshRequested" (fun target -> (target :?> RefreshVisualizer).RefreshRequested)

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality RefreshVisualizer.OrientationProperty


[<AutoOpen>]
module RefreshVisualizerBuilders =
    type Fabulous.Avalonia.View with

        static member RefreshVisualizer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRefreshVisualizer>(
                RefreshVisualizer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type RefreshVisualizerModifiers =
    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabRefreshVisualizer>, value: RefreshVisualizerOrientation) =
        this.AddScalar(RefreshVisualizer.Orientation.WithValue(value))

    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabRefreshVisualizer>, onRefreshRequested: RefreshRequestedEventArgs -> 'msg) =
        this.AddScalar(RefreshVisualizer.RefreshRequested.WithValue(fun args -> onRefreshRequested args |> box))

    /// <summary>Link a ViewRef to access the direct RefreshContainer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRefreshVisualizer>, value: ViewRef<RefreshVisualizer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
