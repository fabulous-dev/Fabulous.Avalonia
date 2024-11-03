namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentRefreshVisualizer =
    let RefreshRequested =
        Attributes.defineEventNoDispatch<RefreshRequestedEventArgs> "RefreshVisualizer_RefreshRequested" (fun target ->
            (target :?> RefreshVisualizer).RefreshRequested)

[<AutoOpen>]
module ComponentRefreshVisualizerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RefreshVisualizer widget.</summary>
        /// <param name="content">The content of the RefreshVisualizer.</param>
        static member RefreshVisualizer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRefreshVisualizer>(
                RefreshVisualizer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentRefreshVisualizerModifiers =
    /// <summary>Listens the RefreshVisualizer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabRefreshVisualizer>, fn: RefreshRequestedEventArgs -> unit) =
        this.AddScalar(ComponentRefreshVisualizer.RefreshRequested.WithValue(fn))
