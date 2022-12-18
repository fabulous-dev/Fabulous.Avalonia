namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabThumb =
    inherit IFabTemplatedControl

module Thumb =
    let WidgetKey = Widgets.register<Thumb>()

    let DragStarted =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragStarted" (fun target -> (target :?> Thumb).DragStarted)

    let DragDelta =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragDelta" (fun target -> (target :?> Thumb).DragDelta)

    let DragCompleted =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragCompleted" (fun target -> (target :?> Thumb).DragCompleted)

[<AutoOpen>]
module ThumbBuilders =
    type Fabulous.Avalonia.View with

        static member inline Thumb() =
            WidgetBuilder<'msg, IFabThumb>(Thumb.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

[<Extension>]
type ThumbModifiers =
    [<Extension>]
    static member inline onDragStarted(this: WidgetBuilder<'msg, #IFabThumb>, onDragStarted: Vector -> 'msg) =
        this.AddScalar(Thumb.DragStarted.WithValue(fun args -> onDragStarted args.Vector |> box))

    [<Extension>]
    static member inline onDragDelta(this: WidgetBuilder<'msg, #IFabThumb>, onDragDelta: Vector -> 'msg) =
        this.AddScalar(Thumb.DragDelta.WithValue(fun args -> onDragDelta args.Vector |> box))

    [<Extension>]
    static member inline onDragCompleted(this: WidgetBuilder<'msg, #IFabThumb>, onDragCompleted: Vector -> 'msg) =
        this.AddScalar(Thumb.DragCompleted.WithValue(fun args -> onDragCompleted args.Vector |> box))
