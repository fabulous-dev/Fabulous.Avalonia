namespace Fabulous.Avalonia.Components

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentSolidColorBrush =
    inherit IFabComponentBrush
    inherit IFabSolidColorBrush

[<AutoOpen>]
module ComponentSolidColorBrushBuilders =
    type Fabulous.Avalonia.Components.View with
        /// <summary>Creates a SolidColorBrush widget.</summary>
        /// <param name="color">The color of the brush.</param>
        static member SolidColorBrush(color: Color) =
            WidgetBuilder<unit, IFabComponentSolidColorBrush>(SolidColorBrush.WidgetKey, SolidColorBrush.Color.WithValue(color))

        /// <summary>Creates a SolidColorBrush widget.</summary>
        /// <param name="color">The color of the brush.</param>
        static member SolidColorBrush(color: string) =
            View.SolidColorBrush(Color.Parse(color))
