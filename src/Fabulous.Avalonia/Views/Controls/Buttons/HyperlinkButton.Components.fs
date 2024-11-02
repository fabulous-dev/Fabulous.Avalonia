namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentHyperlinkButton =
    let IsVisitedChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "HyperlinkButton_VisitedChanged" HyperlinkButton.IsVisitedProperty

[<AutoOpen>]
module ComponentHyperlinkButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        static member HyperlinkButton(text: string, uri: Uri) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(uri)
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(text: string, uri: Uri, isVisited: bool, fn: bool -> unit) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(uri),
                ComponentHyperlinkButton.IsVisitedChanged.WithValue(ComponentValueEventData.create isVisited fn)
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        static member HyperlinkButton(text: string, uri: string) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(Uri(uri))
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(text: string, uri: string, isVisited: bool, fn: bool -> unit) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(Uri(uri)),
                ComponentHyperlinkButton.IsVisitedChanged.WithValue(ComponentValueEventData.create isVisited fn)
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        static member HyperlinkButton(uri: Uri, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                AttributesBundle(
                    StackList.one(HyperlinkButton.NavigateUri.WithValue(uri)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(uri: Uri, isVisited: bool, fn: bool -> unit, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        HyperlinkButton.NavigateUri.WithValue(uri),
                        ComponentHyperlinkButton.IsVisitedChanged.WithValue(ComponentValueEventData.create isVisited fn)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        static member HyperlinkButton(uri: string, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                AttributesBundle(
                    StackList.one(HyperlinkButton.NavigateUri.WithValue(Uri(uri))),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(uri: string, isVisited: bool, fn: bool -> unit, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        HyperlinkButton.NavigateUri.WithValue(Uri(uri)),
                        ComponentHyperlinkButton.IsVisitedChanged.WithValue(ComponentValueEventData.create isVisited fn)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
