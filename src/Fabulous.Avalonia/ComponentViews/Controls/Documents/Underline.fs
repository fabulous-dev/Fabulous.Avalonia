namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

type IFabComponentUnderline =
    inherit IFabComponentSpan
    inherit IFabUnderline

[<AutoOpen>]
module ComponentUnderlineBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Underline widget.</summary>
        static member private Underline() =
            CollectionBuilder<unit, IFabComponentUnderline, IFabComponentInline>(Underline.WidgetKey, ComponentSpan.Inlines)

        /// <summary>Creates a Underline widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Underline(text: string) = View.Underline() { View.Run(text) }

type ComponentUnderlineModifiers =
    /// <summary>Link a ViewRef to access the direct Underline control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentUnderline>, value: ViewRef<Underline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
