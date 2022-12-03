namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabThumb =
    inherit IFabTemplatedControl

module Thumb =
    let WidgetKey = Widgets.register<Thumb> ()
    
    let DragStartedEvent =
        Attributes.defineEvent<VectorEventArgs>
            "Thumb_DragStartedEvent"
            (fun target -> (target :?> Thumb).DragStarted)
            
    let DragDeltaEvent =
        Attributes.defineEvent<VectorEventArgs>
            "Thumb_DragDeltaEvent"
            (fun target -> (target :?> Thumb).DragDelta)
            
    let DragCompletedEvent =
        Attributes.defineEvent<VectorEventArgs>
            "Thumb_DragCompletedEvent"
            (fun target -> (target :?> Thumb).DragCompleted)

[<AutoOpen>]
module ThumbBuilders =
    type Fabulous.Avalonia.View with

        static member inline Thumb() =
            WidgetBuilder<'msg, IFabThumb>(
                Thumb.WidgetKey,
                AttributesBundle(
                    StackList.empty (),
                    ValueNone,
                    ValueNone
                )
            )
