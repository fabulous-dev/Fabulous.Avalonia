namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentPathFigure =
    inherit IFabComponentElement
    inherit IFabPathFigure

module ComponentPathFigure =
    let Segments =
        ComponentAttributes.defineAvaloniaListWidgetCollection "PathFigure_Segments" (fun target -> (target :?> PathFigure).Segments)


[<AutoOpen>]
module PathFigureBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a PathFigure widget.</summary>
        /// <param name="startPoint">The start point of the path.</param>
        static member PathFigure(startPoint: Point) =
            CollectionBuilder<unit, IFabComponentPathFigure, IFabPathSegment>(
                PathFigure.WidgetKey,
                ComponentPathFigure.Segments,
                PathFigure.StartPoint.WithValue(startPoint)
            )

type PathFigureBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabPathSegment>
        (_: CollectionBuilder<'msg, 'marker, IFabPathSegment>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabPathSegment>
        (_: CollectionBuilder<'msg, 'marker, IFabPathSegment>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
