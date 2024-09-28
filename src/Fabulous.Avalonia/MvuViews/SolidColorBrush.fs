namespace Fabulous.Avalonia.Mvu

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuSolidColorBrush =
    inherit IFabMvuBrush
    inherit IFabSolidColorBrush

[<AutoOpen>]
module MvuSolidColorBrushBuilders =
    type Fabulous.Avalonia.Mvu.View with
        /// <summary>Creates a SolidColorBrush widget.</summary>
        /// <param name="color">The color of the brush.</param>
        static member SolidColorBrush(color: Color) =
            WidgetBuilder<unit, IFabMvuSolidColorBrush>(SolidColorBrush.WidgetKey, SolidColorBrush.Color.WithValue(color))

        /// <summary>Creates a SolidColorBrush widget.</summary>
        /// <param name="color">The color of the brush.</param>
        static member SolidColorBrush(color: string) =
            View.SolidColorBrush(Color.Parse(color))
