namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuThumb =
    inherit IFabMvuTemplatedControl
    inherit IFabThumb

module MvuThumb =
    let DragStarted =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragStarted" (fun target -> (target :?> Thumb).DragStarted)

    let DragDelta =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragDelta" (fun target -> (target :?> Thumb).DragDelta)

    let DragCompleted =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragCompleted" (fun target -> (target :?> Thumb).DragCompleted)

[<AutoOpen>]
module MvuThumbBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Thumb widget.</summary>
        static member Thumb() =
            WidgetBuilder<'msg, IFabMvuThumb>(Thumb.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a Thumb widget.</summary>
        /// <param name="template">The template to use for the Thumb.</param>
        static member Thumb(template: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuThumb>(
                Thumb.WidgetKey,
                AttributesBundle(StackList.one(TemplatedControl.Template.WithValue(template.Compile())), ValueNone, ValueNone)
            )

type MvuThumbModifiers =

    /// <summary>Listens to the Thumb DragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged started.</param>
    [<Extension>]
    static member inline onDragStarted(this: WidgetBuilder<unit, #IFabMvuThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(MvuThumb.DragStarted.WithValue(fn))

    /// <summary>Listens to the Thumb DragDelta event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged.</param>
    [<Extension>]
    static member inline onDragDelta(this: WidgetBuilder<unit, #IFabMvuThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(MvuThumb.DragDelta.WithValue(fn))

    /// <summary>Listens to the Thumb DragCompleted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged is completed.</param>
    [<Extension>]
    static member inline onDragCompleted(this: WidgetBuilder<unit, #IFabMvuThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(MvuThumb.DragCompleted.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct Thumb control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuThumb>, value: ViewRef<Thumb>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
