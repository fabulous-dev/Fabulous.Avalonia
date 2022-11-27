namespace Fabulous.Avalonia


open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList


type IFabPathGeometry =
    inherit IFabGeometry

module PathGeometry =

    let WidgetKey = Widgets.register<PathGeometry> ()

    let Figures =
        Attributes.defineAvaloniaListWidgetCollection "PathGeometry_Figures" (fun target ->
            (target :?> PathGeometry).Figures)

    let FillRule =
        Attributes.defineAvaloniaPropertyWithEquality PathGeometry.FillRuleProperty

[<AutoOpen>]
module PathGeometryBuilders =
    type Fabulous.Avalonia.View with

        static member PathGeometry() =
            WidgetBuilder<'msg, IFabPathGeometry>(
                PolylineGeometry.WidgetKey,
                AttributesBundle(StackList.empty (), ValueNone, ValueNone)
            )
