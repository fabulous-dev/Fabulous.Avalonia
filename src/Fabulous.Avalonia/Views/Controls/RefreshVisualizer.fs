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

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality RefreshVisualizer.OrientationProperty

type RefreshVisualizerModifiers =
    /// <summary>Link a ViewRef to access the direct RefreshContainer control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRefreshVisualizer>, value: ViewRef<RefreshVisualizer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
