namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuDrawingGroup =
    inherit IFabMvuDrawing
    inherit IFabDrawingGroup

module MvuDrawingGroup =

    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "DrawingGroup_Children" (fun target -> (target :?> DrawingGroup).Children)

[<AutoOpen>]
module MvuDrawingGroupBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DrawingGroup widget.</summary>
        static member DrawingGroup() =
            CollectionBuilder<'msg, IFabMvuDrawingGroup, IFabMvuDrawing>(DrawingGroup.WidgetKey, MvuDrawingGroup.Children, DrawingGroup.Opacity.WithValue(1.0))

        /// <summary>Creates a DrawingGroup widget.</summary>
        /// <param name="opacity">The opacity of the drawing group.</param>
        static member DrawingGroup(opacity: float) =
            CollectionBuilder<'msg, IFabMvuDrawingGroup, IFabMvuDrawing>(
                DrawingGroup.WidgetKey,
                MvuDrawingGroup.Children,
                DrawingGroup.Opacity.WithValue(opacity)
            )

type MvuDrawingGroupExtraModifiers =
    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: Color) =
        DrawingGroupModifiers.opacityMask(this, View.SolidColorBrush(value))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: string) =
        DrawingGroupModifiers.opacityMask(this, View.SolidColorBrush(value))


type MvuDrawingGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuDrawing>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuDrawing>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuDrawing>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuDrawing>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
