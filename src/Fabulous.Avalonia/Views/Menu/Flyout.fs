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
    [<Extension>]
    static member inline attachedFlyout(this: WidgetBuilder<'msg, #IFabControl>, widget: WidgetBuilder<'msg, IFabFlyout>) =
        this.AddWidget(FlyoutBase.AttachedFlyout.WithValue(widget.Compile()))
