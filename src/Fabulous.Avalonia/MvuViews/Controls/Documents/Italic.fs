namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

type IFabMvuItalic =
    inherit IFabMvuSpan
    inherit IFabItalic

[<AutoOpen>]
module MvuItalicBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Italic widget.</summary>
        static member private Italic() =
            CollectionBuilder<'msg, IFabMvuItalic, IFabMvuInline>(Italic.WidgetKey, MvuSpan.Inlines)

        /// <summary>Creates a Italic widget.</summary>
        /// <param name="text">Text to display.</param>
        static member Italic(text: string) = Mvu.View.Italic() { View.Run(text) }
