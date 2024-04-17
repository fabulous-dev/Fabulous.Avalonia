namespace Playground

open Fabulous
open Fabulous.Avalonia

module AsyncImage =
    // see https://github.com/AvaloniaUtils/AsyncImageLoader.Avalonia?tab=readme-ov-file#imageloader-attached-property
    let Source =
        Attributes.defineAvaloniaPropertyWithEquality AsyncImageLoader.ImageLoader.SourceProperty

[<AutoOpen>]
module AsyncImageBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates an Async Image widget.</summary>
        /// <param name="url">The image web url to use as the source.</param>
        static member inline AsyncImage(url: string) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, AsyncImage.Source.WithValue(url))
