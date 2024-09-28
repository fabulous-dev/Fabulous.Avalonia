namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFaMvuRefreshVisualizer =
    inherit IFabMvuContentControl
    inherit IFabRefreshVisualizer

module MvuRefreshVisualizer =
    let RefreshRequested =
        MvuAttributes.defineEvent<RefreshRequestedEventArgs> "RefreshVisualizer_RefreshRequested" (fun target ->
            (target :?> RefreshVisualizer).RefreshRequested)

[<AutoOpen>]
module MvuRefreshVisualizerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a RefreshVisualizer widget.</summary>
        /// <param name="content">The content of the RefreshVisualizer.</param>
        static member RefreshVisualizer(content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFaMvuRefreshVisualizer>(
                RefreshVisualizer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type MvuRefreshVisualizerModifiers =
    /// <summary>Listens the RefreshVisualizer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFaMvuRefreshVisualizer>, fn: RefreshRequestedEventArgs -> unit) =
        this.AddScalar(MvuRefreshVisualizer.RefreshRequested.WithValue(fn))
