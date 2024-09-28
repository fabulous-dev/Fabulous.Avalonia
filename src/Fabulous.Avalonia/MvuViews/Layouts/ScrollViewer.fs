namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentScrollViewer =
    inherit IFabComponentContentControl
    inherit IFabScrollViewer

module ComponentScrollViewer =
    let ScrollChanged =
        ComponentAttributes.defineEvent "ScrollViewer_ScrollChangedEvent" (fun target -> (target :?> ScrollViewer).ScrollChanged)

[<AutoOpen>]
module ComponentScrollViewerBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ScrollViewer widget</summary>
        /// <param name="content">The content to display</param>
        static member ScrollViewer(content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabScrollViewer>(
                ScrollViewer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentScrollViewerModifiers =
    /// <summary>Listens to the ScrollViewer ScrollChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ScrollChanged event fires.</param>
    [<Extension>]
    static member inline onScrollChanged(this: WidgetBuilder<unit, #IFabComponentScrollViewer>, fn: ScrollChangedEventArgs -> unit) =
        this.AddScalar(ComponentScrollViewer.ScrollChanged.WithValue(fn))
