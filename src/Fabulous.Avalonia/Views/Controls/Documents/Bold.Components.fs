namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia


[<AutoOpen>]
module ComponentBoldBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Bold widget.</summary>
        static member private Bold() =
            CollectionBuilder<'mag, IFabBold, IFabInline>(Bold.WidgetKey, ComponentSpan.Inlines)

        /// <summary>Creates a Bold widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Bold(text: string) = View.Bold() { View.Run(text) }
