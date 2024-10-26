namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuTextBlock =
    inherit IFabMvuControl
    inherit IFabTextBlock

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
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        static member inline TextBlock(text: string) =
            WidgetBuilder<'msg, IFabMvuTextBlock>(TextBlock.WidgetKey, TextBlock.Text.WithValue(text))

        /// <summary>Creates a TextBlock widget.</summary>
        static member inline TextBlock() =
            CollectionBuilder<'msg, IFabMvuTextBlock, IFabMvuInline>(TextBlock.WidgetKey, MvuTextBlock.Inlines)

type MvuTextBlockModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, value: Color) =
        TextBlockModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, value: string) =
        TextBlockModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, value: Color) =
        TextBlockModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, value: string) =
        TextBlockModifiers.foreground(this, View.SolidColorBrush(value))

type MvuTextBlockCollectionBuilderExtensions =

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuTextDecoration>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuTextDecoration>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type MvuInlineCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'msg: equality and 'marker :> IFabMvuInline>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>(this, MvuInline.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #IFabMvuInline>, value: WidgetBuilder<'msg, IFabMvuTextDecoration>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>(this, MvuInline.TextDecorations) { value }

type MvuTextBlockCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'msg: equality and 'marker :> IFabTextBlock>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>(this, MvuTextBlock.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #IFabTextBlock>, value: WidgetBuilder<'msg, IFabMvuTextDecoration>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>(this, MvuTextBlock.TextDecorations) { value }
