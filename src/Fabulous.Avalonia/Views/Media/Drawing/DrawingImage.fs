namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabDrawingImage =
    inherit IFabDrawing

module DrawingImage =
    let WidgetKey = Widgets.register<DrawingImage>()

    let Drawing = Attributes.defineAvaloniaPropertyWidget DrawingImage.DrawingProperty

type DrawingImageModifiers =
    /// <summary>Link a ViewRef to access the direct DrawingImage control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDrawingImage>, value: ViewRef<DrawingImage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
