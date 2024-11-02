namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

module MvuTransformGroup =

    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "TransformGroup_Children" (fun target -> (target :?> TransformGroup).Children)

[<AutoOpen>]
module MvuTransformGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TransformGroup widget.</summary>
        static member TransformGroup() =
            CollectionBuilder<'msg, IFabTransformGroup, IFabTransform>(TransformGroup.WidgetKey, MvuTransformGroup.Children)
