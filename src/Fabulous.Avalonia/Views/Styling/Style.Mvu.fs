namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Avalonia

type MvuStyleModifiers =
    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabAnimation>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, MvuStyledElement.StylesWidget) {
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, Style.Animations) { value }
        }

    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabStyle>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, MvuStyledElement.StylesWidget) { value }
