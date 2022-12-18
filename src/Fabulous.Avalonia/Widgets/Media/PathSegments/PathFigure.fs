namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabPathFigure =
    inherit IFabElement

module PathFigure =
    let WidgetKey = Widgets.register<PathFigure>()

    let IsClosed =
        Attributes.defineAvaloniaPropertyWithEquality PathFigure.IsClosedProperty

    let IsFilled =
        Attributes.defineAvaloniaPropertyWithEquality PathFigure.IsFilledProperty

    let Segments =
        Attributes.defineAvaloniaListWidgetCollection "PathFigure_Segments" (fun target ->
            (target :?> PathFigure).Segments)

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality PathFigure.StartPointProperty

[<AutoOpen>]
module PathFigureBuilders =
    type Fabulous.Avalonia.View with

        static member PathFigure(startPoint: Point) =
            CollectionBuilder<'msg, IFabPathFigure, IFabPathSegment>(
                PathFigure.WidgetKey,
                PathFigure.Segments,
                PathFigure.StartPoint.WithValue(startPoint)
            )

[<Extension>]
type PathFigureModifiers =

    [<Extension>]
    static member inline isClosed(this: WidgetBuilder<'msg, #IFabPathFigure>, value: bool) =
        this.AddScalar(PathFigure.IsClosed.WithValue(value))

    [<Extension>]
    static member inline isFilled(this: WidgetBuilder<'msg, #IFabPathFigure>, value: bool) =
        this.AddScalar(PathFigure.IsFilled.WithValue(value))

[<Extension>]
type PathFigureBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabPathSegment>
        (
            _: CollectionBuilder<'msg, 'marker, IFabPathSegment>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabPathSegment>
        (
            _: CollectionBuilder<'msg, 'marker, IFabPathSegment>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
