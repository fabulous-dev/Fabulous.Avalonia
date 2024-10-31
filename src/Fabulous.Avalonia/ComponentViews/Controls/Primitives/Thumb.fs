namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentThumb =
    inherit IFabComponentTemplatedControl
    inherit IFabThumb

module ComponentThumb =
    let DragStarted =
        Attributes.defineEventNoDispatch<VectorEventArgs> "Thumb_DragStarted" (fun target -> (target :?> Thumb).DragStarted)

    let DragDelta =
        Attributes.defineEventNoDispatch<VectorEventArgs> "Thumb_DragDelta" (fun target -> (target :?> Thumb).DragDelta)

    let DragCompleted =
        Attributes.defineEventNoDispatch<VectorEventArgs> "Thumb_DragCompleted" (fun target -> (target :?> Thumb).DragCompleted)

[<AutoOpen>]
module ComponentThumbBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Thumb widget.</summary>
        static member Thumb() =
            WidgetBuilder<unit, IFabComponentThumb>(Thumb.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a Thumb widget.</summary>
        /// <param name="template">The template to use for the Thumb.</param>
        static member Thumb(template: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentThumb>(
                Thumb.WidgetKey,
                AttributesBundle(StackList.one(TemplatedControl.Template.WithValue(template.Compile())), ValueNone, ValueNone)
            )

type ComponentThumbModifiers =

    /// <summary>Listens to the Thumb DragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged started.</param>
    [<Extension>]
    static member inline onDragStarted(this: WidgetBuilder<unit, #IFabComponentThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(ComponentThumb.DragStarted.WithValue(fn))

    /// <summary>Listens to the Thumb DragDelta event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged.</param>
    [<Extension>]
    static member inline onDragDelta(this: WidgetBuilder<unit, #IFabComponentThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(ComponentThumb.DragDelta.WithValue(fn))

    /// <summary>Listens to the Thumb DragCompleted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged is completed.</param>
    [<Extension>]
    static member inline onDragCompleted(this: WidgetBuilder<unit, #IFabComponentThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(ComponentThumb.DragCompleted.WithValue(fn))
