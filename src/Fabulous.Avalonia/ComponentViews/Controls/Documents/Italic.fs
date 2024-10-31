namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

type IFabComponentItalic =
    inherit IFabComponentSpan
    inherit IFabItalic

[<AutoOpen>]
module ComponentItalicBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Italic widget.</summary>
        static member private Italic() =
            CollectionBuilder<unit, IFabComponentItalic, IFabComponentInline>(Italic.WidgetKey, ComponentSpan.Inlines)

        /// <summary>Creates a Italic widget.</summary>
        /// <param name="text">Text to display.</param>
        static member Italic(text: string) =
            Components.View.Italic() { View.Run(text) }
