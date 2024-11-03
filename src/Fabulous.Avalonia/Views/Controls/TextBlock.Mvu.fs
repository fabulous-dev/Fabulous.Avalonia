namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuTextBlock =
    let TextDecorations =
        MvuAttributes.defineAvaloniaListWidgetCollection "TextBlock_TextDecorations" (fun target ->
            let target = target :?> TextBlock

            if target.TextDecorations = null then
                let newColl = TextDecorationCollection()
                target.TextDecorations <- newColl
                newColl
            else
                target.TextDecorations)

    let Inlines =
        MvuAttributes.defineAvaloniaListWidgetCollection "TextBlock_Inlines" (fun target ->
            let target = target :?> TextBlock

            if target.Inlines = null then
                let newColl = InlineCollection()
                target.Inlines <- newColl
                newColl
            else
                target.Inlines)

[<AutoOpen>]
module MvuTextBlockBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        static member inline TextBlock(text: string) =
            WidgetBuilder<'msg, IFabTextBlock>(TextBlock.WidgetKey, TextBlock.Text.WithValue(text))

        /// <summary>Creates a TextBlock widget.</summary>
        static member inline TextBlock() =
            CollectionBuilder<'msg, IFabTextBlock, IFabInline>(TextBlock.WidgetKey, MvuTextBlock.Inlines)

type MvuInlineCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'msg: equality and 'marker :> IFabInline>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, MvuInline.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #IFabInline>, value: WidgetBuilder<'msg, IFabTextDecoration>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, MvuInline.TextDecorations) { value }

type MvuTextBlockCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'msg: equality and 'marker :> IFabTextBlock>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, MvuTextBlock.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #IFabTextBlock>, value: WidgetBuilder<'msg, IFabTextDecoration>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, MvuTextBlock.TextDecorations) { value }
