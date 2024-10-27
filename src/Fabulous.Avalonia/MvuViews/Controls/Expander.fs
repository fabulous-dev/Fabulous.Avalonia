namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuExpander =
    inherit IFabMvuHeaderedContentControl
    inherit IFabExpander

module MvuExpander =
    let ExpandedChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "Expander_IsExpandedChanged" Expander.IsExpandedProperty

    let Collapsing =
        Attributes.defineEvent "Expander_Collapsing" (fun target -> (target :?> Expander).Collapsing)

    let Expanding =
        Attributes.defineEvent "Expander_Expanding" (fun target -> (target :?> Expander).Expanding)

[<AutoOpen>]
module MvuExpanderBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: string, content: string) =
            WidgetBuilder<'msg, IFabMvuExpander>(
                Expander.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                ContentControl.ContentString.WithValue(content)
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: WidgetBuilder<'msg, #IFabMvuControl>, content: string) =
            WidgetBuilder<'msg, IFabMvuExpander>(
                Expander.WidgetKey,
                AttributesBundle(
                    StackList.one(ContentControl.ContentString.WithValue(content)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: string, content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuExpander>(
                Expander.WidgetKey,
                AttributesBundle(
                    StackList.one(HeaderedContentControl.HeaderString.WithValue(header)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: WidgetBuilder<'msg, #IFabMvuControl>, content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuExpander>(
                Expander.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type ExpanderModifiers =
    /// <summary>Listens to the Expander ExpandedChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isExpanded">The IsExpanded value.</param>
    /// <param name="fn">Raised when the ExpandedChanged event fires.</param>
    [<Extension>]
    static member inline onExpandedChanged(this: WidgetBuilder<'msg, #IFabMvuExpander>, isExpanded: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuExpander.ExpandedChanged.WithValue(MvuValueEventData.create isExpanded fn))

    /// <summary>Listens to the Expander Collapsing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Collapsing event fires.</param>
    [<Extension>]
    static member inline onCollapsing(this: WidgetBuilder<'msg, #IFabMvuExpander>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(MvuExpander.Collapsing.WithValue(fn))

    /// <summary>Listens to the Expander Expanding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Expanding event fires.</param>
    [<Extension>]
    static member inline onExpanding(this: WidgetBuilder<'msg, #IFabExpander>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(MvuExpander.Expanding.WithValue(fn))
