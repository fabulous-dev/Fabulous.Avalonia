namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentExpander =
    inherit IFabComponentHeaderedContentControl
    inherit IFabExpander

module ComponentExpander =
    let ExpandedChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "Expander_IsExpandedChanged" Expander.IsExpandedProperty

    let Collapsing =
        Attributes.defineEventNoDispatch "Expander_Collapsing" (fun target -> (target :?> Expander).Collapsing)

    let Expanding =
        Attributes.defineEventNoDispatch "Expander_Expanding" (fun target -> (target :?> Expander).Expanding)

[<AutoOpen>]
module ComponentExpanderBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: string, content: string) =
            WidgetBuilder<unit, IFabComponentExpander>(
                Expander.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                ContentControl.ContentString.WithValue(content)
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: WidgetBuilder<unit, #IFabComponentControl>, content: string) =
            WidgetBuilder<unit, IFabComponentExpander>(
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
        static member Expander(header: string, content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentExpander>(
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
        static member Expander(header: WidgetBuilder<unit, #IFabComponentControl>, content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentExpander>(
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
    static member inline onExpandedChanged(this: WidgetBuilder<unit, #IFabComponentExpander>, isExpanded: bool, fn: bool -> unit) =
        this.AddScalar(ComponentExpander.ExpandedChanged.WithValue(ComponentValueEventData.create isExpanded fn))

    /// <summary>Listens to the Expander Collapsing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Collapsing event fires.</param>
    [<Extension>]
    static member inline onCollapsing(this: WidgetBuilder<unit, #IFabComponentExpander>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(ComponentExpander.Collapsing.WithValue(fn))

    /// <summary>Listens to the Expander Expanding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Expanding event fires.</param>
    [<Extension>]
    static member inline onExpanding(this: WidgetBuilder<unit, #IFabExpander>, fn: CancelRoutedEventArgs -> unit) =
        this.AddScalar(ComponentExpander.Expanding.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct Expander control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabExpander>, value: ViewRef<Expander>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
