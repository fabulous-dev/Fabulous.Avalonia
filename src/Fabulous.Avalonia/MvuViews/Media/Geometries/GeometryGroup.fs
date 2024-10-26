namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuGeometryGroup =
    inherit IFabMvuGeometry
    inherit IFabGeometryGroup

module MvuGeometryGroup =
    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children)

[<AutoOpen>]
module MvuGeometryGroupBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a GeometryGroup widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry group.</param>
        static member GeometryGroup(fillRule: FillRule) =
            CollectionBuilder<unit, IFabMvuGeometryGroup, IFabMvuGeometry>(
                GeometryGroup.WidgetKey,
                MvuGeometryGroup.Children,
                GeometryGroup.FillRule.WithValue(fillRule)
            )

type MvuGeometryGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuGeometry>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuGeometry>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
