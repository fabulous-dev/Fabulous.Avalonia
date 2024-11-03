namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia


[<AutoOpen>]
module MvuBoldBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Bold widget.</summary>
        static member private Bold() =
            CollectionBuilder<'msg, IFabBold, IFabInline>(Bold.WidgetKey, MvuSpan.Inlines)

        /// <summary>Creates a Bold widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Bold(text: string) = View.Bold() { View.Run(text) }
