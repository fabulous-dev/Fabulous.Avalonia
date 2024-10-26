namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabScaleTransform =
    inherit IFabTransform

module ScaleTransform =

    let WidgetKey = Widgets.register<ScaleTransform>()

    let ScaleX =
        Attributes.defineAvaloniaPropertyWithEquality ScaleTransform.ScaleXProperty

    let ScaleY =
        Attributes.defineAvaloniaPropertyWithEquality ScaleTransform.ScaleYProperty


type ScaleTransformModifiers =
    /// <summary>Link a ViewRef to access the direct ScaleTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabScaleTransform>, value: ViewRef<ScaleTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
