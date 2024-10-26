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

type ComponentFlyoutModifiers =
    /// <summary>Link a ViewRef to access the direct Flyout control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabFlyout>, value: ViewRef<Flyout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ComponentFlyoutAttachedModifiers =
    /// <summary>Sets the AttachedFlyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AttachedFlyout value.</param>
    [<Extension>]
    static member inline attachedFlyout(this: WidgetBuilder<'msg, #IFabComponentControl>, value: WidgetBuilder<'msg, #IFabComponentFlyoutBase>) =
        this.AddWidget(FlyoutBase.AttachedFlyout.WithValue(value.Compile()))
