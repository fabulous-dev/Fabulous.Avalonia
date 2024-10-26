namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabRotate3DTransform =
    inherit IFabTransform

module Rotate3DTransform =

    let WidgetKey = Widgets.register<Rotate3DTransform>()

    let Angle =
        Attributes.defineSimpleScalarWithEquality<struct (float * float * float)> "Rotate3DTransform_Angle" (fun _ newValueOpt node ->
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


type Rotate3DTransformModifiers =
    /// <summary>Link a ViewRef to access the direct Rotate3DTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabRotate3DTransform>, value: ViewRef<Rotate3DTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
