namespace Fabulous.Avalonia.Mvu

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuStyle =
    inherit IFabMvuElement
    inherit IFabStyle

module MvuStyle =

    let Animations =
        Attributes.defineListWidgetCollection "Style_Animations" (fun target -> (target :?> Style).Animations :> IList<_>)

[<AutoOpen>]
module MvuStyleBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates an Animations widget.</summary>
        static member Animations() =
            CollectionBuilder<'msg, IFabMvuStyle, IFabMvuAnimation>(Style.WidgetKey, MvuStyle.Animations)

type MvuStyleCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabMvuStyledElement, IFabMvuStyle>, x: WidgetBuilder<'msg, #IFabMvuStyle>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabMvuStyledElement, IFabMvuStyle>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabMvuStyle>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type MvuStyleModifiers =
    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabMvuStyledElement>, value: WidgetBuilder<'msg, IFabMvuAnimation>) =
        AttributeCollectionBuilder<'msg, #IFabMvuStyledElement, IFabMvuStyle>(this, MvuStyledElement.StylesWidget) {
            CollectionBuilder<'msg, IFabMvuStyle, IFabMvuAnimation>(Style.WidgetKey, MvuStyle.Animations) { value }
        }

    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabMvuStyledElement>, value: WidgetBuilder<'msg, IFabMvuStyle>) =
        AttributeCollectionBuilder<'msg, #IFabMvuStyledElement, IFabMvuStyle>(this, MvuStyledElement.StylesWidget) { value }
