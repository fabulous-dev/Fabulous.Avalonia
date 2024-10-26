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

type ComponentItalicModifiers =
    /// <summary>Link a ViewRef to access the direct Italic control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentItalic>, value: ViewRef<Italic>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
