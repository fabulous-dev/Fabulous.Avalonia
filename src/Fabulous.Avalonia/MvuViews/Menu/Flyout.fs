namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuFlyout =
    inherit IFabMvuPopupFlyoutBase
    inherit IFabFlyout

[<AutoOpen>]
module MvuFlyoutBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Flyout widget.</summary>
        /// <param name="content">The content of the Flyout.</param>
        static member Flyout(content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuFlyout>(
                Flyout.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Flyout.Content.WithValue(content.Compile()) |], ValueNone)
            )

type MvuFlyoutAttachedModifiers =
    /// <summary>Sets the AttachedFlyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AttachedFlyout value.</param>
    [<Extension>]
    static member inline attachedFlyout(this: WidgetBuilder<'msg, #IFabMvuControl>, value: WidgetBuilder<'msg, #IFabMvuFlyoutBase>) =
        this.AddWidget(FlyoutBase.AttachedFlyout.WithValue(value.Compile()))
