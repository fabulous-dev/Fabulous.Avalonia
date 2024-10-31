namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentMatrixTransform =
    inherit IFabComponentTransform
    inherit IFabMatrixTransform

[<AutoOpen>]
module ComponentMatrixTransformBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a MatrixTransform widget.</summary>
        /// <param name="matrix">The Matrix to apply.</param>
        static member MatrixTransform(matrix: Matrix) =
            WidgetBuilder<'msg, IFabComponentMatrixTransform>(MatrixTransform.WidgetKey, MatrixTransform.Matrix.WithValue(matrix))
