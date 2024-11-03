namespace Fabulous.Avalonia.Components

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentGeometryGroup =
    let Children =
        Attributes.defineAvaloniaListWidgetCollectionNoLifecycle "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children)

[<AutoOpen>]
module ComponentGeometryGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a GeometryGroup widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry group.</param>
        static member GeometryGroup(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabGeometryGroup, IFabGeometry>(
                GeometryGroup.WidgetKey,
                ComponentGeometryGroup.Children,
                GeometryGroup.FillRule.WithValue(fillRule)
            )
