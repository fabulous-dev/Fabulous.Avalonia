namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components

[<AutoOpen>]
module ComponentItalicBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Italic widget.</summary>
        static member private Italic() =
            CollectionBuilder<unit, IFabItalic, IFabInline>(Italic.WidgetKey, ComponentSpan.Inlines)

        /// <summary>Creates a Italic widget.</summary>
        /// <param name="text">Text to display.</param>
        static member Italic(text: string) =
            View.Italic() { View.Run(text) }
