namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuPathFigure =
    let Segments =
        Attributes.defineAvaloniaListWidgetCollection "PathFigure_Segments" (fun target -> (target :?> PathFigure).Segments)

[<AutoOpen>]
module MvuPathFigureBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a PathFigure widget.</summary>
        /// <param name="startPoint">The start point of the path.</param>
        static member PathFigure(startPoint: Point) =
            CollectionBuilder<'msg, IFabPathFigure, IFabPathSegment>(PathFigure.WidgetKey, MvuPathFigure.Segments, PathFigure.StartPoint.WithValue(startPoint))
