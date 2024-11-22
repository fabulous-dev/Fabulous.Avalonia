namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module MvuHyperlinkButton =
    let IsVisitedChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "HyperlinkButton_VisitedChanged" HyperlinkButton.IsVisitedProperty

[<AutoOpen>]
module MvuHyperlinkButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(text: string, uri: Uri, isVisited: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(uri),
                MvuHyperlinkButton.IsVisitedChanged.WithValue(ValueEventData.create isVisited fn)
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(text: string, uri: string, isVisited: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(Uri(uri)),
                MvuHyperlinkButton.IsVisitedChanged.WithValue(ValueEventData.create isVisited fn)
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(uri: Uri, isVisited: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                AttributesBundle(
                    StackList.two(HyperlinkButton.NavigateUri.WithValue(uri), MvuHyperlinkButton.IsVisitedChanged.WithValue(ValueEventData.create isVisited fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone,
                    ValueNone
                )
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(uri: string, isVisited: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        HyperlinkButton.NavigateUri.WithValue(Uri(uri)),
                        MvuHyperlinkButton.IsVisitedChanged.WithValue(ValueEventData.create isVisited fn)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone,
                    ValueNone
                )
            )
