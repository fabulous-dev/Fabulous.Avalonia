namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuTransitioningContentControl =
    inherit IFabMvuContentControl
    inherit IFabTransitioningContentControl

[<AutoOpen>]
module MvuTransitioningContentControlBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TransitioningContentControl widget.</summary>
        static member TransitioningContentControl(content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuTransitioningContentControl>(
                TransitioningContentControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type MvuTransitioningContentControlModifiers =
    /// <summary>Link a ViewRef to access the direct TransitioningContentControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuTransitioningContentControl>, value: ViewRef<TransitioningContentControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))