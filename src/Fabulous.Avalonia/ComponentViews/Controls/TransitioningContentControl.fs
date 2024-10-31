namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
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
