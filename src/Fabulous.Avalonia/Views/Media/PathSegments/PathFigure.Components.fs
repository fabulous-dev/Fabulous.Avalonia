namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentPathFigure =
    let Segments =
        ComponentAttributes.defineAvaloniaListWidgetCollection "PathFigure_Segments" (fun target -> (target :?> PathFigure).Segments)


[<AutoOpen>]
module ComponentPathFigureBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a PathFigure widget.</summary>
        /// <param name="startPoint">The start point of the path.</param>
        static member PathFigure(startPoint: Point) =
            CollectionBuilder<unit, IFabPathFigure, IFabPathSegment>(
                PathFigure.WidgetKey,
                ComponentPathFigure.Segments,
                PathFigure.StartPoint.WithValue(startPoint)
            )