namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabSkewTransform =
    inherit IFabTransform

module SkewTransform =

    let WidgetKey = Widgets.register<SkewTransform>()

    let AngleX =
        Attributes.defineAvaloniaPropertyWithEquality SkewTransform.AngleXProperty

    let AngleY =
        Attributes.defineAvaloniaPropertyWithEquality SkewTransform.AngleYProperty

type SkewTransformTransformModifiers =
    /// <summary>Link a ViewRef to access the direct SkewTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSkewTransform>, value: ViewRef<SkewTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
