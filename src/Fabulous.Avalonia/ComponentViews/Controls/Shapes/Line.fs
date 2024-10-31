namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentLine =
    inherit IFabComponentShape
    inherit IFabLine

[<AutoOpen>]
module ComponentLineBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Line widget.</summary>
        /// <param name="starPoint">The start point of the line.</param>
        /// <param name="endPoint">The end point of the line.</param>
        static member Line(starPoint: Point, endPoint: Point) =
            WidgetBuilder<unit, IFabComponentLine>(Line.WidgetKey, Line.StartPoint.WithValue(starPoint), Line.EndPoint.WithValue(endPoint))
