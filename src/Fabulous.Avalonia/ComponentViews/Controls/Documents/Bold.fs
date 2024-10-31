namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

type IFabComponentBold =
    inherit IFabComponentSpan
    inherit IFabBold

[<AutoOpen>]
module ComponentBoldBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Bold widget.</summary>
        static member private Bold() =
            CollectionBuilder<unit, IFabComponentBold, IFabComponentInline>(Bold.WidgetKey, ComponentSpan.Inlines)

        /// <summary>Creates a Bold widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Bold(text: string) = View.Bold() { View.Run(text) }
