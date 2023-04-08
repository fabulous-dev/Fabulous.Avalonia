namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous

type IFabItalic =
    inherit IFabSpan

module Italic =
    let WidgetKey = Widgets.register<Italic>()

[<AutoOpen>]
module ItalicBuilders =
    type Fabulous.Avalonia.View with

        static member private Italic<'msg>() =
            CollectionBuilder<'msg, IFabItalic, IFabInline>(Italic.WidgetKey, Span.Inlines)

        static member Italic<'msg>(text: string) =
            Fabulous.Avalonia.View.Italic<'msg>() { View.Run<'msg>(text) }

[<Extension>]
type ItalicModifiers =
    /// <summary>Link a ViewRef to access the direct Italic control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabItalic>, value: ViewRef<Italic>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
