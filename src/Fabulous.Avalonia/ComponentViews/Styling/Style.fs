namespace Fabulous.Avalonia.Components

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentStyle =
    inherit IFabComponentElement
    inherit IFabStyle

module ComponentStyle =

    let Animations =
        ComponentAttributes.defineListWidgetCollection "Style_Animations" (fun target -> (target :?> Style).Animations :> IList<_>)

[<AutoOpen>]
module ComponentStyleBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates an Animations widget.</summary>
        static member Animations() =
            CollectionBuilder<unit, IFabComponentStyle, IFabComponentAnimation>(Style.WidgetKey, ComponentStyle.Animations)

type ComponentStyleCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabComponentAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabComponentAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabComponentStyledElement, IFabComponentStyle>, x: WidgetBuilder<'msg, #IFabComponentStyle>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabComponentStyledElement, IFabComponentStyle>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabComponentStyle>>) : Content<
                                                                                                                                                                 'msg
                                                                                                                                                              >
        =
        { Widgets = MutStackArray1.One(x.Compile()) }

type ComponentStyleModifiers =
    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabComponentAnimation>) =
        AttributeCollectionBuilder<'msg, #IFabComponentStyledElement, IFabComponentStyle>(this, ComponentStyledElement.StylesWidget) {
            CollectionBuilder<'msg, IFabComponentStyle, IFabComponentAnimation>(Style.WidgetKey, ComponentStyle.Animations) { value }
        }

    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabComponentStyledElement>, value: WidgetBuilder<'msg, IFabComponentStyle>) =
        AttributeCollectionBuilder<'msg, #IFabComponentStyledElement, IFabStyle>(this, ComponentStyledElement.StylesWidget) { value }

    /// <summary>Link a ViewRef to access the direct Style control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentStyle>, value: ViewRef<Style>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
