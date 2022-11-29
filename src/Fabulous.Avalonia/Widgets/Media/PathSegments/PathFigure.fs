namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabPathFigure =
    inherit IFabElement

module PathFigure =
    let WidgetKey = Widgets.register<PathFigure> ()

    let IsClosed =
        Attributes.defineAvaloniaPropertyWithEquality PathFigure.IsClosedProperty

    let IsFilled =
        Attributes.defineAvaloniaPropertyWithEquality PathFigure.IsFilledProperty

    let Segments =
        Attributes.defineAvaloniaListWidgetCollection "PathFigure_Segments" (fun target ->
            (target :?> PathFigure).Segments)

[<AutoOpen>]
module PathFigureBuilders =
    type Fabulous.Avalonia.View with

        static member PathFigure(?isClosed: bool, ?isFilled: bool) =
            CollectionBuilder<'msg, IFabPathFigure, IFabPathSegment>(
                PathFigure.WidgetKey,
                PathFigure.Segments,
                PathFigure.IsClosed.WithValue(isClosed |> Option.defaultValue true),
                PathFigure.IsFilled.WithValue(isFilled |> Option.defaultValue true)
            )

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
