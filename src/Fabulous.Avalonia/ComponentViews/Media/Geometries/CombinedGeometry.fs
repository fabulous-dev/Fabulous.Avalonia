namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentCombinedGeometry =
    inherit IFabComponentGeometry
    inherit IFabCombinedGeometry


[<AutoOpen>]
module ComponentCombinedGeometryBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a CombinedGeometry widget.</summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        static member CombinedGeometry(geometry1: WidgetBuilder<unit, #IFabGeometry>, geometry2: WidgetBuilder<unit, #IFabComponentGeometry>) =
            WidgetBuilder<'msg, IFabComponentCombinedGeometry>(
                CombinedGeometry.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| CombinedGeometry.Geometry1.WithValue(geometry1.Compile())
                           CombinedGeometry.Geometry2.WithValue(geometry2.Compile()) |],
                    ValueNone
                )
            )