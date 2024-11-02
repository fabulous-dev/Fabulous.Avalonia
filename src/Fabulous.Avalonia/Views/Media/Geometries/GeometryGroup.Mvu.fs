namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuGeometryGroup =
    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children)

[<AutoOpen>]
module MvuGeometryGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a GeometryGroup widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry group.</param>
        static member GeometryGroup(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabGeometryGroup, IFabGeometry>(
                GeometryGroup.WidgetKey,
                MvuGeometryGroup.Children,
                GeometryGroup.FillRule.WithValue(fillRule)
            )