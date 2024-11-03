namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia


module ComponentPathGeometry =
    let FiguresWidget =
        ComponentAttributes.defineAvaloniaListWidgetCollection "PathGeometry_Figures" (fun target -> (target :?> PathGeometry).Figures)

[<AutoOpen>]
module ComponentPathGeometryBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a PathGeometry widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry.</param>
        static member PathGeometry(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabPathGeometry, IFabPathFigure>(
                PathGeometry.WidgetKey,
                ComponentPathGeometry.FiguresWidget,
                PathGeometry.FillRule.WithValue(fillRule)
            )

        /// <summary>Creates a PathGeometry widget.</summary>
        /// <param name="pathData">The path data to parse.</param>
        /// <param name="fillRule">The fill rule to apply to the geometry.</param>
        static member PathGeometry(pathData: string, fillRule: FillRule) =
            WidgetBuilder<'msg, IFabPathGeometry>(
                PathGeometry.WidgetKey,
                PathGeometry.Figures.WithValue(PathFigures.Parse(pathData)),
                PathGeometry.FillRule.WithValue(fillRule)
            )
