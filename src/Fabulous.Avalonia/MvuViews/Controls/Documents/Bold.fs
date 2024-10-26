namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

type IFabMvuBold =
    inherit IFabMvuSpan
    inherit IFabBold

[<AutoOpen>]
module MvuBoldBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Bold widget.</summary>
        static member private Bold() =
            CollectionBuilder<unit, IFabMvuBold, IFabMvuInline>(Bold.WidgetKey, MvuSpan.Inlines)

        /// <summary>Creates a Bold widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Bold(text: string) = View.Bold() { View.Run(text) }

type MvuBoldModifiers =
    /// <summary>Link a ViewRef to access the direct Bold control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuBold>, value: ViewRef<Bold>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
