namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuRefreshContainer =
    inherit IFabMvuContentControl
    inherit IFabRefreshContainer

module MvuRefreshContainer =
    let RefreshRequested =
        Attributes.defineEvent<RefreshRequestedEventArgs> "RefreshContainer_RefreshRequested" (fun target -> (target :?> RefreshContainer).RefreshRequested)

[<AutoOpen>]
module MvuRefreshContainerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a RefreshContainer widget.</summary>
        /// <param name="content">The content of the RefreshContainer.</param>
        static member RefreshContainer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuRefreshContainer>(
                RefreshContainer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type MvuRefreshContainerModifiers =
    /// <summary>Listens the RefreshContainer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabMvuRefreshContainer>, fn: RefreshRequestedEventArgs -> 'msg) =
        this.AddScalar(MvuRefreshContainer.RefreshRequested.WithValue(fn))
