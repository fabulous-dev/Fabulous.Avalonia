namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabFlyout =
    inherit IFabPopupFlyoutBase

module Flyout =

    let WidgetKey = Widgets.register<Flyout>()

    let Content = Attributes.defineAvaloniaPropertyWidget Flyout.ContentProperty

[<AutoOpen>]
module FlyoutBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Flyout widget</summary>
        /// <param name="content">The content of the Flyout</param>
        static member Flyout(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabFlyout>(
                Flyout.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Flyout.Content.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type FlyoutModifiers =
    /// <summary>Link a ViewRef to access the direct Flyout control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabFlyout>, value: ViewRef<Flyout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type FlyoutAttachedModifiers =
    /// <summary>Sets the AttachedFlyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AttachedFlyout value</param>
    [<Extension>]
    static member inline attachedFlyout(this: WidgetBuilder<'msg, #IFabControl>, value: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(FlyoutBase.AttachedFlyout.WithValue(value.Compile()))
