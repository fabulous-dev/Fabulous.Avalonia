namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabRotateTransform =
    inherit IFabTransform

module RotateTransform =

    let WidgetKey = Widgets.register<RotateTransform>()

    let Angle =
        Attributes.defineAvaloniaPropertyWithEquality RotateTransform.AngleProperty

    let CenterX =
        Attributes.defineAvaloniaPropertyWithEquality RotateTransform.CenterXProperty

    let CenterY =
        Attributes.defineAvaloniaPropertyWithEquality RotateTransform.CenterYProperty

type RotateTransformTransformModifiers =
    /// <summary>Link a ViewRef to access the direct RotateTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabRotateTransform>, value: ViewRef<RotateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
