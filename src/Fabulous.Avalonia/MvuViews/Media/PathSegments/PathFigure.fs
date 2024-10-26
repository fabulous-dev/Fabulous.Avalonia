namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuPathFigure =
    inherit IFabMvuElement
    inherit IFabPathFigure

module MvuPathFigure =
    let Segments =
        MvuAttributes.defineAvaloniaListWidgetCollection "PathFigure_Segments" (fun target -> (target :?> PathFigure).Segments)


[<AutoOpen>]
module PathFigureBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a PathFigure widget.</summary>
        /// <param name="startPoint">The start point of the path.</param>
        static member PathFigure(startPoint: Point) =
            CollectionBuilder<'msg, IFabMvuPathFigure, IFabPathSegment>(
                PathFigure.WidgetKey,
                MvuPathFigure.Segments,
                PathFigure.StartPoint.WithValue(startPoint)
            )

type PathFigureBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabPathSegment>
        (_: CollectionBuilder<'msg, 'marker, IFabPathSegment>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabPathSegment>
        (_: CollectionBuilder<'msg, 'marker, IFabPathSegment>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
