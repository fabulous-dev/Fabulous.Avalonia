namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabCombinedGeometry =
    inherit IFabGeometry

module CombinedGeometry =

    let WidgetKey = Widgets.register<CombinedGeometry>()

    let Geometry1 =
        Attributes.defineAvaloniaPropertyWidget CombinedGeometry.Geometry1Property

    let Geometry2 =
        Attributes.defineAvaloniaPropertyWidget CombinedGeometry.Geometry2Property

    let GeometryCombineMode =
        Attributes.defineAvaloniaPropertyWithEquality CombinedGeometry.GeometryCombineModeProperty


type CombinedGeometryModifiers =
    /// <summary>Sets the GeometryCombineMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The GeometryCombineMode value.</param>
    [<Extension>]
    static member inline geometryCombineMode(this: WidgetBuilder<'msg, #IFabCombinedGeometry>, value: GeometryCombineMode) =
        this.AddScalar(CombinedGeometry.GeometryCombineMode.WithValue(value))

    /// <summary>Link a ViewRef to access the direct CombinedGeometry control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCombinedGeometry>, value: ViewRef<CombinedGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
