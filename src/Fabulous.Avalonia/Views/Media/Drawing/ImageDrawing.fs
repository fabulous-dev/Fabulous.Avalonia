namespace Fabulous.Avalonia

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabImageDrawing =
    inherit IFabDrawing

module ImageDrawing =
    let WidgetKey = Widgets.register<ImageDrawing>()

    let ImageSource =
        Attributes.defineBindableImageSource ImageDrawing.ImageSourceProperty

    let ImageSourceWidget =
        Attributes.defineAvaloniaPropertyWidget ImageDrawing.ImageSourceProperty

    let Rect = Attributes.defineAvaloniaPropertyWithEquality ImageDrawing.RectProperty

type ImageDrawingModifiers =

    /// <summary>Link a ViewRef to access the direct ImageDrawing control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabImageDrawing>, value: ViewRef<ImageDrawing>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
