namespace Fabulous.Avalonia

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
