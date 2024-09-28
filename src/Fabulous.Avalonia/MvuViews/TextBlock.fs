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
            WidgetBuilder<unit, IFabMvuTextBlock>(TextBlock.WidgetKey, TextBlock.Text.WithValue(text))

        /// <summary>Creates a TextBlock widget.</summary>
        static member inline TextBlock() =
            CollectionBuilder<unit, IFabMvuTextBlock, IFabMvuInline>(TextBlock.WidgetKey, MvuTextBlock.Inlines)

type MvuTextBlockModifiers =
    /// <summary>Link a ViewRef to access the direct TextBlock control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTextBlock>, value: ViewRef<TextBlock>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))


type MvuTextBlockCollectionBuilderExtensions =

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuTextDecoration>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuTextDecoration>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuTextDecoration>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type MvuInlineCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'marker :> IFabMvuInline>(this: WidgetBuilder<unit, 'marker>) =
        AttributeCollectionBuilder<unit, 'marker, IFabMvuTextDecoration>(this, MvuInline.TextDecorations)

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
    static member inline textDecorations<'msg, 'marker when 'marker :> IFabTextBlock>(this: WidgetBuilder<unit, 'marker>) =
        AttributeCollectionBuilder<unit, 'marker, IFabMvuTextDecoration>(this, TextBlock.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<unit, #IFabTextBlock>, value: WidgetBuilder<unit, IFabMvuTextDecoration>) =
        AttributeCollectionBuilder<unit, 'marker, IFabMvuTextDecoration>(this, MvuTextBlock.TextDecorations) { value }
