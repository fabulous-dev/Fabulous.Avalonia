namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentTextBlock =
    let TextDecorations =
        ComponentAttributes.defineAvaloniaListWidgetCollection "TextBlock_TextDecorations" (fun target ->
            let target = target :?> TextBlock

            if target.TextDecorations = null then
                let newColl = TextDecorationCollection()
                target.TextDecorations <- newColl
                newColl
            else
                target.TextDecorations)

    let Inlines =
        ComponentAttributes.defineAvaloniaListWidgetCollection "TextBlock_Inlines" (fun target ->
            let target = target :?> TextBlock

            if target.Inlines = null then
                let newColl = InlineCollection()
                target.Inlines <- newColl
                newColl
            else
                target.Inlines)

[<AutoOpen>]
module ComponentTextBlockBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        static member inline TextBlock(text: string) =
            WidgetBuilder<unit, IFabTextBlock>(TextBlock.WidgetKey, TextBlock.Text.WithValue(text))

        /// <summary>Creates a TextBlock widget.</summary>
        static member inline TextBlock() =
            CollectionBuilder<unit, IFabTextBlock, IFabInline>(TextBlock.WidgetKey, ComponentTextBlock.Inlines)

type ComponentInlineCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'marker :> IFabInline>(this: WidgetBuilder<unit, 'marker>) =
        AttributeCollectionBuilder<unit, 'marker, IFabTextDecoration>(this, ComponentInline.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<unit, #IFabInline>, value: WidgetBuilder<unit, IFabTextDecoration>) =
        AttributeCollectionBuilder<unit, 'marker, IFabTextDecoration>(this, ComponentInline.TextDecorations) { value }

type ComponentTextBlockCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'marker :> IFabTextBlock>(this: WidgetBuilder<unit, 'marker>) =
        AttributeCollectionBuilder<unit, 'marker, IFabTextDecoration>(this, ComponentTextBlock.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<unit, #IFabTextBlock>, value: WidgetBuilder<unit, IFabTextDecoration>) =
        AttributeCollectionBuilder<unit, 'marker, IFabTextDecoration>(this, ComponentTextBlock.TextDecorations) { value }
