namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDrawingImage =
    inherit IFabDrawing

module DrawingImage =
    let WidgetKey = Widgets.register<DrawingImage>()

    let Drawing = Attributes.defineAvaloniaPropertyWidget DrawingImage.DrawingProperty

    let Invalidated =
        Attributes.defineEventNoArg "DrawingImage_Invalidated" (fun target -> (target :?> DrawingImage).Invalidated)

[<AutoOpen>]
module DrawingImageBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DrawingImage widget</summary>
        /// <param name="source">The source of the drawing</param>
        static member DrawingImage(source: WidgetBuilder<'msg, #IFabDrawing>) =
            WidgetBuilder<'msg, IFabDrawingImage>(
                DrawingImage.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingImage.Drawing.WithValue(source.Compile()) |], ValueNone)
            )

[<Extension>]
type DrawingImageModifiers =
    /// <summary>Listens the DrawingImage Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DrawingImage is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabDrawingImage>, fn: 'msg) =
        this.AddScalar(DrawingImage.Invalidated.WithValue(fun _ -> fn |> box))
