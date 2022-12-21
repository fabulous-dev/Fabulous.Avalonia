namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

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

        static member PathGeometry(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabPathGeometry, IFabPathFigure>(
                PathGeometry.WidgetKey,
                PathGeometry.Figures,
                PathGeometry.FillRule.WithValue(fillRule)
            )

[<Extension>]
type PathGeometryBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabPathFigure>
        (
            _: CollectionBuilder<'msg, 'marker, IFabPathFigure>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabPathFigure>
        (
            _: CollectionBuilder<'msg, 'marker, IFabPathFigure>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
