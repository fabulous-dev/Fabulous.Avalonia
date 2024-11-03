namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module ComponentItalicBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Italic widget.</summary>
        static member private Italic() =
            CollectionBuilder<'msg, IFabItalic, IFabInline>(Italic.WidgetKey, ComponentSpan.Inlines)

        /// <summary>Creates a Italic widget.</summary>
        /// <param name="text">Text to display.</param>
        static member Italic(text: string) = View.Italic() { View.Run(text) }
