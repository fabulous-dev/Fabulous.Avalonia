namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
module MvuDrawingGroup =

    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "DrawingGroup_Children" (fun target -> (target :?> DrawingGroup).Children)

[<AutoOpen>]
module MvuDrawingGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DrawingGroup widget.</summary>
        static member DrawingGroup() =
            CollectionBuilder<'msg, IFabDrawingGroup, IFabDrawing>(DrawingGroup.WidgetKey, MvuDrawingGroup.Children, DrawingGroup.Opacity.WithValue(1.0))

        /// <summary>Creates a DrawingGroup widget.</summary>
        /// <param name="opacity">The opacity of the drawing group.</param>
        static member DrawingGroup(opacity: float) =
            CollectionBuilder<'msg, IFabDrawingGroup, IFabDrawing>(
                DrawingGroup.WidgetKey,
                MvuDrawingGroup.Children,
                DrawingGroup.Opacity.WithValue(opacity)
            )