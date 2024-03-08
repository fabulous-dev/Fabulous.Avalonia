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

        /// <summary>Creates a DrawingImage widget.</summary>
        /// <param name="source">The source of the drawing.</param>
        static member DrawingImage(source: WidgetBuilder<'msg, #IFabDrawing>) =
            WidgetBuilder<'msg, IFabDrawingImage>(
                DrawingImage.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingImage.Drawing.WithValue(source.Compile()) |], ValueNone)
            )

type DrawingImageModifiers =
    /// <summary>Listens the DrawingImage Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the DrawingImage is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabDrawingImage>, msg: 'msg) =
        this.AddScalar(DrawingImage.Invalidated.WithValue(MsgValue msg))

    /// <summary>Link a ViewRef to access the direct DrawingImage control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDrawingImage>, value: ViewRef<DrawingImage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
