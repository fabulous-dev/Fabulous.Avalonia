namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuDrawingImage =
    inherit IFabMvuDrawing
    inherit IFabDrawingImage

module MvuDrawingImage =
    let Invalidated =
        MvuAttributes.defineEventNoArg "DrawingImage_Invalidated" (fun target -> (target :?> DrawingImage).Invalidated)

[<AutoOpen>]
module MvuDrawingImageBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DrawingImage widget.</summary>
        /// <param name="source">The source of the drawing.</param>
        static member DrawingImage(source: WidgetBuilder<'msg, #IFabMvuDrawing>) =
            WidgetBuilder<'msg, IFabMvuDrawingImage>(
                DrawingImage.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingImage.Drawing.WithValue(source.Compile()) |], ValueNone)
            )

type MvuDrawingImageModifiers =
    /// <summary>Listens the DrawingImage Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the DrawingImage is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabMvuDrawingImage>, msg: 'msg) =
        this.AddScalar(MvuDrawingImage.Invalidated.WithValue(MsgValue msg))

    /// <summary>Link a ViewRef to access the direct DrawingImage control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuDrawingImage>, value: ViewRef<DrawingImage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
