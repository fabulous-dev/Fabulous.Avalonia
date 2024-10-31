namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentFlyout =
    inherit IFabComponentPopupFlyoutBase
    inherit IFabFlyout

[<AutoOpen>]
module ComponentFlyoutBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Flyout widget.</summary>
        /// <param name="content">The content of the Flyout.</param>
        static member Flyout(content: WidgetBuilder<'msg, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentFlyout>(
                Flyout.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Flyout.Content.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentFlyoutAttachedModifiers =
    /// <summary>Sets the AttachedFlyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AttachedFlyout value.</param>
    [<Extension>]
    static member inline attachedFlyout(this: WidgetBuilder<'msg, #IFabComponentControl>, value: WidgetBuilder<'msg, #IFabComponentFlyoutBase>) =
        this.AddWidget(FlyoutBase.AttachedFlyout.WithValue(value.Compile()))
