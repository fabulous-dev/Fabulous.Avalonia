namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList


module ComponentRefreshContainer =
    let RefreshRequested =
        Attributes.defineEventNoDispatch<RefreshRequestedEventArgs> "RefreshContainer_RefreshRequested" (fun target ->
            (target :?> RefreshContainer).RefreshRequested)

[<AutoOpen>]
module ComponentRefreshContainerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RefreshContainer widget.</summary>
        /// <param name="content">The content of the RefreshContainer.</param>
        static member RefreshContainer(content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabRefreshContainer>(
                RefreshContainer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentRefreshContainerModifiers =
    /// <summary>Listens the RefreshContainer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<unit, #IFabRefreshContainer>, fn: RefreshRequestedEventArgs -> unit) =
        this.AddScalar(ComponentRefreshContainer.RefreshRequested.WithValue(fn))
