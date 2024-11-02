namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

type ComponentStyleModifiers =
    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabAnimation>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, ComponentStyledElement.StylesWidget) {
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, Style.Animations) { value }
        }

    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabStyle>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, ComponentStyledElement.StylesWidget) { value }
