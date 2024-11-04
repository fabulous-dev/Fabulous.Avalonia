namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

module MvuStyle =
    let Animations =
        Attributes.defineAvaloniaListWidgetCollectionNoDispatch "Style_Animations" (fun target -> (target :?> Style).Animations)

[<AutoOpen>]
module MvuStyleBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates an Animations widget.</summary>
        static member Animations() =
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, MvuStyle.Animations)


type MvuStyleModifiers =
    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabAnimation>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, MvuStyledElement.StylesWidget) {
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, MvuStyle.Animations) { value }
        }

    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabStyle>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, MvuStyledElement.StylesWidget) { value }
