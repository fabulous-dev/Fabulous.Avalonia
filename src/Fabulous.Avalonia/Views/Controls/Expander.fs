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

    /// <summary>Link a ViewRef to access the direct Expander control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabExpander>, value: ViewRef<Expander>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
