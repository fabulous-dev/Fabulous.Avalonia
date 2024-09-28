namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
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
            CollectionBuilder<unit, IFabMvuItalic, IFabMvuInline>(Italic.WidgetKey, MvuSpan.Inlines)

        /// <summary>Creates a Italic widget.</summary>
        /// <param name="text">Text to display.</param>
        static member Italic(text: string) =
            Mvu.View.Italic() { View.Run(text) }

type MvuItalicModifiers =
    /// <summary>Link a ViewRef to access the direct Italic control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuItalic>, value: ViewRef<Italic>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
