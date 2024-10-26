namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentGeometryGroup =
    inherit IFabComponentGeometry
    inherit IFabGeometryGroup

module ComponentGeometryGroup =
    let Children =
        ComponentAttributes.defineAvaloniaListWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children)

[<AutoOpen>]
module ComponentGeometryGroupBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a GeometryGroup widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry group.</param>
        static member GeometryGroup(fillRule: FillRule) =
            CollectionBuilder<unit, IFabComponentGeometryGroup, IFabComponentGeometry>(
                GeometryGroup.WidgetKey,
                ComponentGeometryGroup.Children,
                GeometryGroup.FillRule.WithValue(fillRule)
            )

type ComponentGeometryGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentGeometry>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentGeometry>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
