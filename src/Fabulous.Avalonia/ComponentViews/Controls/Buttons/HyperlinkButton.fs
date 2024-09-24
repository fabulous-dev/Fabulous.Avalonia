namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentHyperlinkButton =
    inherit IFabComponentButton
    inherit IFabHyperlinkButton

module ComponentHyperlinkButton =
    let IsVisitedChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "HyperlinkButton_VisitedChanged" HyperlinkButton.IsVisitedProperty

[<AutoOpen>]
module ComponentHyperlinkButtonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        static member HyperlinkButton(text: string, uri: Uri) =
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
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
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(uri),
                ComponentHyperlinkButton.IsVisitedChanged.WithValue(ComponentValueEventData.create isVisited fn)
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        static member HyperlinkButton(text: string, uri: string) =
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
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
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                HyperlinkButton.NavigateUri.WithValue(Uri(uri)),
                ComponentHyperlinkButton.IsVisitedChanged.WithValue(ComponentValueEventData.create isVisited fn)
            )

        /// <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        static member HyperlinkButton(uri: Uri, content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
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
        static member HyperlinkButton(uri: Uri, isVisited: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
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
        static member HyperlinkButton(uri: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
                HyperlinkButton.WidgetKey,
                AttributesBundle(
                    StackList.one(HyperlinkButton.NavigateUri.WithValue(Uri(uri))),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        // <summary>Creates a HyperlinkButton widget.</summary>
        /// <param name="uri">The Uri to navigate to when the HyperlinkButton is clicked.</param>
        /// <param name="content">The content of the HyperlinkButton.</param>
        /// <param name="isVisited">Whether the HyperlinkButton is visited.</param>
        /// <param name="fn">Raised when the IsVisited value changes.</param>
        static member HyperlinkButton(uri: string, isVisited: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentHyperlinkButton>(
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

type ComponentHyperlinkButtonModifiers =
    /// <summary>Link a ViewRef to access the direct HyperlinkButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentHyperlinkButton>, value: ViewRef<HyperlinkButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
