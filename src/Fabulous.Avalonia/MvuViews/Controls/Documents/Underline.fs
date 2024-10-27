namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

type IFabMvuUnderline =
    inherit IFabMvuSpan
    inherit IFabUnderline

[<AutoOpen>]
module MvuUnderlineBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Underline widget.</summary>
        static member private Underline() =
            CollectionBuilder<'msg, IFabMvuUnderline, IFabMvuInline>(Underline.WidgetKey, MvuSpan.Inlines)

        /// <summary>Creates a Underline widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Underline(text: string) = View.Underline() { View.Run(text) }
