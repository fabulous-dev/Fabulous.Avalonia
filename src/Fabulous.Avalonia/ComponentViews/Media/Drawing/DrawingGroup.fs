namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentDrawingGroup =
    inherit IFabComponentDrawing
    inherit IFabDrawingGroup

module ComponentDrawingGroup =

    let Children =
        ComponentAttributes.defineAvaloniaListWidgetCollection "DrawingGroup_Children" (fun target -> (target :?> DrawingGroup).Children)

[<AutoOpen>]
module ComponentDrawingGroupBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DrawingGroup widget.</summary>
        static member DrawingGroup() =
            CollectionBuilder<'msg, IFabComponentDrawingGroup, IFabComponentDrawing>(
                DrawingGroup.WidgetKey,
                ComponentDrawingGroup.Children,
                DrawingGroup.Opacity.WithValue(1.0)
            )

        /// <summary>Creates a DrawingGroup widget.</summary>
        /// <param name="opacity">The opacity of the drawing group.</param>
        static member DrawingGroup(opacity: float) =
            CollectionBuilder<'msg, IFabComponentDrawingGroup, IFabComponentDrawing>(
                DrawingGroup.WidgetKey,
                ComponentDrawingGroup.Children,
                DrawingGroup.Opacity.WithValue(opacity)
            )


type ComponentDrawingGroupExtraModifiers =
    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<unit, #IFabDrawingGroup>, value: Color) =
        DrawingGroupModifiers.opacityMask(this, View.SolidColorBrush(value))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<unit, #IFabDrawingGroup>, value: string) =
        DrawingGroupModifiers.opacityMask(this, View.SolidColorBrush(value))


type ComponentDrawingGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabDrawing>
        (_: CollectionBuilder<'msg, 'marker, IFabDrawing>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabDrawing>
        (_: CollectionBuilder<'msg, 'marker, IFabDrawing>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
