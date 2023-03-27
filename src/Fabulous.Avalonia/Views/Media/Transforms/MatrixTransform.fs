namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabMatrixTransform =
    inherit IFabTransform

module MatrixTransform =

    let WidgetKey = Widgets.register<MatrixTransform>()

    let Matrix =
        Attributes.defineAvaloniaPropertyWithEquality MatrixTransform.MatrixProperty

[<AutoOpen>]
module MatrixTransformBuilders =
    type Fabulous.Avalonia.View with

        static member MatrixTransform(matrix: Matrix) =
            WidgetBuilder<'msg, IFabMatrixTransform>(MatrixTransform.WidgetKey, MatrixTransform.Matrix.WithValue(matrix))
