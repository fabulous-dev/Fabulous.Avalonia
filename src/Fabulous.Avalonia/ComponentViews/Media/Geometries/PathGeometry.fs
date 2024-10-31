namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentPathGeometry =
    inherit IFabComponentGeometry
    inherit IFabPathGeometry

module ComponentPathGeometry =
    let FiguresWidget =
        ComponentAttributes.defineAvaloniaListWidgetCollection "PathGeometry_Figures" (fun target -> (target :?> PathGeometry).Figures)

[<AutoOpen>]
module PathGeometryBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a PathGeometry widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry.</param>
        static member PathGeometry(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabComponentPathGeometry, IFabComponentPathFigure>(
                PathGeometry.WidgetKey,
                ComponentPathGeometry.FiguresWidget,
                PathGeometry.FillRule.WithValue(fillRule)
            )

        /// <summary>Creates a PathGeometry widget.</summary>
        /// <param name="pathData">The path data to parse.</param>
        /// <param name="fillRule">The fill rule to apply to the geometry.</param>
        static member PathGeometry(pathData: string, fillRule: FillRule) =
            WidgetBuilder<'msg, IFabComponentPathGeometry>(
                PathGeometry.WidgetKey,
                PathGeometry.Figures.WithValue(PathFigures.Parse(pathData)),
                PathGeometry.FillRule.WithValue(fillRule)
            )

type PathGeometryBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentPathFigure>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentPathFigure>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabPathFigure>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentPathFigure>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
