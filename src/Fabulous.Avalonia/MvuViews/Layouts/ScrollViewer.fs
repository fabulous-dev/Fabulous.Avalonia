namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuScrollViewer =
    inherit IFabMvuContentControl
    inherit IFabScrollViewer

module MvuScrollViewer =
    let ScrollChanged =
        Attributes.defineEvent "ScrollViewer_ScrollChangedEvent" (fun target -> (target :?> ScrollViewer).ScrollChanged)

[<AutoOpen>]
module MvuScrollViewerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ScrollViewer widget</summary>
        /// <param name="content">The content to display</param>
        static member ScrollViewer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuScrollViewer>(
                ScrollViewer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type MvuScrollViewerModifiers =
    /// <summary>Listens to the ScrollViewer ScrollChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ScrollChanged event fires.</param>
    [<Extension>]
    static member inline onScrollChanged(this: WidgetBuilder<'msg, #IFabMvuScrollViewer>, fn: ScrollChangedEventArgs -> 'msg) =
        this.AddScalar(MvuScrollViewer.ScrollChanged.WithValue(fn))
