namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentTransitioningContentControl =
    inherit IFabComponentContentControl
    inherit IFabTransitioningContentControl

[<AutoOpen>]
module ComponentTransitioningContentControlBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TransitioningContentControl widget.</summary>
        static member TransitioningContentControl(content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentTransitioningContentControl>(
                TransitioningContentControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentTransitioningContentControlModifiers =
    /// <summary>Link a ViewRef to access the direct TransitioningContentControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentTransitioningContentControl>, value: ViewRef<TransitioningContentControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
