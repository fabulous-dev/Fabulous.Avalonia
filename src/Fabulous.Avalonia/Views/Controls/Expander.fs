namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabExpander =
    inherit IFabHeaderedContentControl

module Expander =
    let WidgetKey = Widgets.register<Expander>()

    let ContentTransition =
        Attributes.defineAvaloniaPropertyWithEquality Expander.ContentTransitionProperty

    let ExpandDirection =
        Attributes.defineAvaloniaPropertyWithEquality Expander.ExpandDirectionProperty

    let IsExpanded =
        Attributes.defineAvaloniaPropertyWithEquality Expander.IsExpandedProperty

    let ExpandedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Expander_IsExpandedChanged" Expander.IsExpandedProperty

    let Collapsing =
        Attributes.defineEvent "Expander_Collapsing" (fun target -> (target :?> Expander).Collapsing)

    let Expanding =
        Attributes.defineEvent "Expander_Expanding" (fun target -> (target :?> Expander).Expanding)

[<AutoOpen>]
module ExpanderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: string, content: string) =
            WidgetBuilder<'msg, IFabExpander>(
                Expander.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                ContentControl.ContentString.WithValue(content)
            )

        /// <summary>Creates a Expander widget.</summary>
        /// <param name="header">The header of the expander.</param>
        /// <param name="content">The content of the expander.</param>
        static member Expander(header: WidgetBuilder<'msg, #IFabControl>, content: string) =
            WidgetBuilder<'msg, IFabExpander>(
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
        static member Expander(header: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabExpander>(
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
        static member Expander(header: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabExpander>(
                Expander.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ExpanderModifiers =
    /// <summary>Sets the ContentTransition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContentTransition value.</param>
    [<Extension>]
    static member inline contentTransition(this: WidgetBuilder<'msg, #IFabExpander>, value: IPageTransition) =
        this.AddScalar(Expander.ContentTransition.WithValue(value))

    /// <summary>Sets the ExpandDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ExpandDirection value.</param>
    [<Extension>]
    static member inline expandDirection(this: WidgetBuilder<'msg, #IFabExpander>, value: ExpandDirection) =
        this.AddScalar(Expander.ExpandDirection.WithValue(value))

    /// <summary>Sets the IsExpanded property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsExpanded value.</param>
    [<Extension>]
    static member inline isExpanded(this: WidgetBuilder<'msg, #IFabExpander>, value: bool) =
        this.AddScalar(Expander.IsExpanded.WithValue(value))

    /// <summary>Listens to the Expander ExpandedChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isExpanded">The IsExpanded value.</param>
    /// <param name="fn">Raised when the ExpandedChanged event fires.</param>
    [<Extension>]
    static member inline onExpandedChanged(this: WidgetBuilder<'msg, #IFabExpander>, isExpanded: bool, fn: bool -> 'msg) =
        this.AddScalar(Expander.ExpandedChanged.WithValue(ValueEventData.create isExpanded (fun arg -> fn arg |> box)))

    /// <summary>Listens to the Expander Collapsing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Collapsing event fires.</param>
    [<Extension>]
    static member inline onCollapsing(this: WidgetBuilder<'msg, #IFabExpander>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(Expander.Collapsing.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the Expander Expanding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Expanding event fires.</param>
    [<Extension>]
    static member inline onExpanding(this: WidgetBuilder<'msg, #IFabExpander>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(Expander.Expanding.WithValue(fun args -> fn args |> box))

    /// <summary>Link a ViewRef to access the direct Expander control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabExpander>, value: ViewRef<Expander>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
