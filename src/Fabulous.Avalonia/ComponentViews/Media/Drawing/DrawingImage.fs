namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentDrawingImage =
    inherit IFabComponentDrawing
    inherit IFabDrawingImage

module ComponentDrawingImage =
    let Invalidated =
        Attributes.defineEventNoArgNoDispatch "DrawingImage_Invalidated" (fun target -> (target :?> DrawingImage).Invalidated)

[<AutoOpen>]
module ComponentDrawingImageBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DrawingImage widget.</summary>
        /// <param name="source">The source of the drawing.</param>
        static member DrawingImage(source: WidgetBuilder<'msg, #IFabComponentDrawing>) =
            WidgetBuilder<'msg, IFabComponentDrawingImage>(
                DrawingImage.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingImage.Drawing.WithValue(source.Compile()) |], ValueNone)
            )

type ComponentDrawingImageModifiers =
    /// <summary>Listens the DrawingImage Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the DrawingImage is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabComponentDrawingImage>, msg: unit -> unit) =
        this.AddScalar(ComponentDrawingImage.Invalidated.WithValue(msg))
