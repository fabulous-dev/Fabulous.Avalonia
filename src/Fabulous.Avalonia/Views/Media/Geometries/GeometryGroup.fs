namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabGeometryGroup =
    inherit IFabGeometry

module GeometryGroup =
    let WidgetKey = Widgets.register<GeometryGroup>()

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children)

    let FillRule =
        Attributes.defineAvaloniaPropertyWithEquality GeometryGroup.FillRuleProperty

[<AutoOpen>]
module GeometryGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a GeometryGroup widget</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry group</param>
        static member GeometryGroup<'msg>(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabGeometryGroup, IFabGeometry>(
                GeometryGroup.WidgetKey,
                GeometryGroup.Children,
                GeometryGroup.FillRule.WithValue(fillRule)
            )

[<Extension>]
type GeometryGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGeometry>
        (
            _: CollectionBuilder<'msg, 'marker, IFabGeometry>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGeometry>
        (
            _: CollectionBuilder<'msg, 'marker, IFabGeometry>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
