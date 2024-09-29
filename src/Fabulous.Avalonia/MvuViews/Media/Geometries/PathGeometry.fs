namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuPathGeometry =
    inherit IFabMvuGeometry
    inherit IFabPathGeometry

module MvuPathGeometry =
    let FiguresWidget =
        MvuAttributes.defineAvaloniaListWidgetCollection "PathGeometry_Figures" (fun target -> (target :?> PathGeometry).Figures)

[<AutoOpen>]
module PathGeometryBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a PathGeometry widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry.</param>
        static member PathGeometry(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabMvuPathGeometry, IFabMvuPathFigure>(
                PathGeometry.WidgetKey,
                MvuPathGeometry.FiguresWidget,
                PathGeometry.FillRule.WithValue(fillRule)
            )

        /// <summary>Creates a PathGeometry widget.</summary>
        /// <param name="pathData">The path data to parse.</param>
        /// <param name="fillRule">The fill rule to apply to the geometry.</param>
        static member PathGeometry(pathData: string, fillRule: FillRule) =
            WidgetBuilder<'msg, IFabMvuPathGeometry>(
                PathGeometry.WidgetKey,
                PathGeometry.Figures.WithValue(PathFigures.Parse(pathData)),
                PathGeometry.FillRule.WithValue(fillRule)
            )

type PathGeometryBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuPathFigure>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuPathFigure>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabPathFigure>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuPathFigure>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type PathGeometryModifiers =

    /// <summary>Link a ViewRef to access the direct PathGeometry control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPathGeometry>, value: ViewRef<PathGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
