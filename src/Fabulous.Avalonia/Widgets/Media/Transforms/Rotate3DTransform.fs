namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabRotate3DTransform =
    inherit IFabTransform

module Rotate3DTransform =

    let WidgetKey = Widgets.register<Rotate3DTransform>()

    let Angle =
        Attributes.defineSimpleScalarWithEquality<struct (float * float * float)> "Border_BorderDashArray" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone ->
                target.ClearValue(Rotate3DTransform.AngleXProperty)
                target.ClearValue(Rotate3DTransform.AngleYProperty)
                target.ClearValue(Rotate3DTransform.AngleZProperty)
            | ValueSome(x, y, z) ->
                target.SetValue(Rotate3DTransform.AngleXProperty, x) |> ignore
                target.SetValue(Rotate3DTransform.AngleYProperty, y) |> ignore
                target.SetValue(Rotate3DTransform.AngleZProperty, z) |> ignore)


    let Center =
        Attributes.defineSimpleScalarWithEquality<struct (float * float * float)> "Border_BorderDashArray" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone ->
                target.ClearValue(Rotate3DTransform.CenterXProperty)
                target.ClearValue(Rotate3DTransform.CenterYProperty)
                target.ClearValue(Rotate3DTransform.CenterZProperty)
            | ValueSome(x, y, z) ->
                target.SetValue(Rotate3DTransform.CenterXProperty, x) |> ignore
                target.SetValue(Rotate3DTransform.CenterYProperty, y) |> ignore
                target.SetValue(Rotate3DTransform.CenterZProperty, z) |> ignore)

    let Depth =
        Attributes.defineAvaloniaPropertyWithEquality Rotate3DTransform.DepthProperty


[<AutoOpen>]
module Rotate3DTransformBuilders =
    type Fabulous.Avalonia.View with

        static member Rotate3DTransform(angleX: float, angleY: float, angleZ: float, centerX: float, centerY: float, centerZ: float, depth: float) =
            WidgetBuilder<'msg, IFabRotate3DTransform>(
                Rotate3DTransform.WidgetKey,
                Rotate3DTransform.Angle.WithValue(angleX, angleY, angleZ),
                Rotate3DTransform.Center.WithValue(centerX, centerY, centerZ),
                Rotate3DTransform.Depth.WithValue(depth)
            )
