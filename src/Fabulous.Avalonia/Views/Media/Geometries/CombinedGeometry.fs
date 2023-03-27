namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

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

[<AutoOpen>]
module CombinedGeometryBuilders =
    type Fabulous.Avalonia.View with

        static member CombinedGeometry(geometry1: WidgetBuilder<'msg, #IFabGeometry>, geometry2: WidgetBuilder<'msg, #IFabGeometry>) =
            WidgetBuilder<'msg, IFabCombinedGeometry>(
                CombinedGeometry.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| CombinedGeometry.Geometry1.WithValue(geometry1.Compile())
                           CombinedGeometry.Geometry2.WithValue(geometry2.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type CombinedGeometryModifiers =
    [<Extension>]
    static member inline geometryCombineMode(this: WidgetBuilder<'msg, #IFabCombinedGeometry>, value: GeometryCombineMode) =
        this.AddScalar(CombinedGeometry.GeometryCombineMode.WithValue(value))
