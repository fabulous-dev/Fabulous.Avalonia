namespace Fabulous.Avalonia

open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

type IFabImageBrush =
    inherit IFabTileBrush

module ImageBrush =
    let WidgetKey = Widgets.register<ImageBrush>()

    let Source = Attributes.defineAvaloniaPropertyWithEquality ImageBrush.SourceProperty

[<AutoOpen>]
module ImageBrushBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ImageBrush widget</summary>
        /// <param name="source">The image source</param>
        static member ImageBrush<'msg>(source: Bitmap) =
            WidgetBuilder<'msg, IFabImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(source))
