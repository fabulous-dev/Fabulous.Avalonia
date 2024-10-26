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
        static member TransitioningContentControl(content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuTransitioningContentControl>(
                TransitioningContentControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
