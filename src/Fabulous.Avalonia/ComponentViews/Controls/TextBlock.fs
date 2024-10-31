namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentTextBlock =
    inherit IFabComponentControl
    inherit IFabTextBlock

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
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        static member inline TextBlock(text: string) =
            WidgetBuilder<unit, IFabComponentTextBlock>(TextBlock.WidgetKey, TextBlock.Text.WithValue(text))

        /// <summary>Creates a TextBlock widget.</summary>
        static member inline TextBlock() =
            CollectionBuilder<unit, IFabComponentTextBlock, IFabComponentInline>(TextBlock.WidgetKey, ComponentTextBlock.Inlines)


type ComponentTextBlockExtraModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabComponentTextBlock>, value: Color) =
        TextBlockModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<unit, #IFabComponentTextBlock>, value: string) =
        TextBlockModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabComponentTextBlock>, value: Color) =
        TextBlockModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, #IFabComponentTextBlock>, value: string) =
        TextBlockModifiers.foreground(this, View.SolidColorBrush(value))


type ComponentTextBlockCollectionBuilderExtensions =

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentTextDecoration>
        (_: AttributeCollectionBuilder<unit, 'marker, IFabComponentTextDecoration>, x: WidgetBuilder<unit, 'itemType>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentTextDecoration>
        (_: AttributeCollectionBuilder<unit, 'marker, IFabComponentTextDecoration>, x: WidgetBuilder<unit, Memo.Memoized<'itemType>>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentInline>
        (_: AttributeCollectionBuilder<unit, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, 'itemType>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentInline>
        (_: AttributeCollectionBuilder<unit, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, Memo.Memoized<'itemType>>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type ComponentInlineCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'marker :> IFabComponentInline>(this: WidgetBuilder<unit, 'marker>) =
        AttributeCollectionBuilder<unit, 'marker, IFabComponentTextDecoration>(this, ComponentInline.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<unit, #IFabComponentInline>, value: WidgetBuilder<unit, IFabComponentTextDecoration>) =
        AttributeCollectionBuilder<unit, 'marker, IFabComponentTextDecoration>(this, ComponentInline.TextDecorations) { value }

type ComponentTextBlockCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'marker :> IFabTextBlock>(this: WidgetBuilder<unit, 'marker>) =
        AttributeCollectionBuilder<unit, 'marker, IFabComponentTextDecoration>(this, ComponentTextBlock.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<unit, #IFabTextBlock>, value: WidgetBuilder<unit, IFabComponentTextDecoration>) =
        AttributeCollectionBuilder<unit, 'marker, IFabComponentTextDecoration>(this, ComponentTextBlock.TextDecorations) { value }
