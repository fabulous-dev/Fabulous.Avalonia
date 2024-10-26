namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabPathGeometry =
    inherit IFabGeometry

module PathGeometry =

    let WidgetKey = Widgets.register<PathGeometry>()

    let Figures =
        Attributes.defineAvaloniaPropertyWithEquality PathGeometry.FiguresProperty

    let FillRule =
        Attributes.defineAvaloniaPropertyWithEquality PathGeometry.FillRuleProperty

type PathGeometryBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabPathFigure>
        (_: CollectionBuilder<'msg, 'marker, IFabPathFigure>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabPathFigure>
        (_: CollectionBuilder<'msg, 'marker, IFabPathFigure>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type PathGeometryModifiers =

    /// <summary>Link a ViewRef to access the direct PathGeometry control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPathGeometry>, value: ViewRef<PathGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
