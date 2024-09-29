namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuMatrixTransform =
    inherit IFabMvuTransform
    inherit IFabMatrixTransform

[<AutoOpen>]
module MvuMatrixTransformBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a MatrixTransform widget.</summary>
        /// <param name="matrix">The Matrix to apply.</param>
        static member MatrixTransform(matrix: Matrix) =
            WidgetBuilder<'msg, IFabMvuMatrixTransform>(MatrixTransform.WidgetKey, MatrixTransform.Matrix.WithValue(matrix))

type MvuMatrixTransformModifiers =
    /// <summary>Link a ViewRef to access the direct MatrixTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuMatrixTransform>, value: ViewRef<MatrixTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
