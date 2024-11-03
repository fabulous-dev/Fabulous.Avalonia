namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

module MvuDrawingImage =
    let Invalidated =
        Attributes.defineEventNoArg "DrawingImage_Invalidated" (fun target -> (target :?> DrawingImage).Invalidated)

[<AutoOpen>]
module MvuDrawingImageBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DrawingImage widget.</summary>
        /// <param name="source">The source of the drawing.</param>
        static member DrawingImage(source: WidgetBuilder<'msg, #IFabDrawing>) =
            WidgetBuilder<'msg, IFabDrawingImage>(
                DrawingImage.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingImage.Drawing.WithValue(source.Compile()) |], ValueNone)
            )

type MvuDrawingImageModifiers =
    /// <summary>Listens the DrawingImage Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the DrawingImage is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabDrawingImage>, msg: 'msg) =
        this.AddScalar(MvuDrawingImage.Invalidated.WithValue(MsgValue msg))
