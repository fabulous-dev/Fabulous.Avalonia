namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabGeometryGroup =
    inherit IFabGeometry

module GeometryGroup =
    let WidgetKey = Widgets.register<GeometryGroup>()

    let FillRule =
        Attributes.defineAvaloniaPropertyWithEquality GeometryGroup.FillRuleProperty

type GeometryGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabGeometry>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabGeometry>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type GeometryGroupModifiers =

    /// <summary>Link a ViewRef to access the direct GeometryGroup control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGeometryGroup>, value: ViewRef<GeometryGroup>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
