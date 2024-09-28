namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
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
            CollectionBuilder<unit, IFabMvuUnderline, IFabMvuInline>(Underline.WidgetKey, MvuSpan.Inlines)

        /// <summary>Creates a Underline widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Underline(text: string) = View.Underline() { View.Run(text) }

type MvuUnderlineModifiers =
    /// <summary>Link a ViewRef to access the direct Underline control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuUnderline>, value: ViewRef<Underline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
