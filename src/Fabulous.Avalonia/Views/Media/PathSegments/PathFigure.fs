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

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality PathFigure.StartPointProperty

type PathFigureModifiers =

    /// <summary>Sets the IsClosed property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsClosed value.</param>
    [<Extension>]
    static member inline isClosed(this: WidgetBuilder<'msg, #IFabPathFigure>, value: bool) =
        this.AddScalar(PathFigure.IsClosed.WithValue(value))

    /// <summary>Sets the IsFilled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsFilled value.</param>
    [<Extension>]
    static member inline isFilled(this: WidgetBuilder<'msg, #IFabPathFigure>, value: bool) =
        this.AddScalar(PathFigure.IsFilled.WithValue(value))

    /// <summary>Link a ViewRef to access the direct PathFigure control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPathFigure>, value: ViewRef<PathFigure>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

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
