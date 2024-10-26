namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuLine =
    inherit IFabMvuShape
    inherit IFabLine

[<AutoOpen>]
module MvuLineBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Line widget.</summary>
        /// <param name="starPoint">The start point of the line.</param>
        /// <param name="endPoint">The end point of the line.</param>
        static member Line(starPoint: Point, endPoint: Point) =
            WidgetBuilder<'msg, IFabMvuLine>(Line.WidgetKey, Line.StartPoint.WithValue(starPoint), Line.EndPoint.WithValue(endPoint))
