namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabDrawingGroup =
    inherit IFabDrawing

module DrawingGroup =
    let WidgetKey = Widgets.register<DrawingGroup>()

    let Opacity =
        Attributes.defineAvaloniaPropertyWithEquality DrawingGroup.OpacityProperty

    let Transform =
        Attributes.defineAvaloniaPropertyWithEquality DrawingGroup.TransformProperty

    let TransformWidget =
        Attributes.defineAvaloniaPropertyWidget DrawingGroup.TransformProperty

    let ClipGeometry =
        Attributes.defineAvaloniaPropertyWidget DrawingGroup.ClipGeometryProperty

    let OpacityMaskWidget =
        Attributes.defineAvaloniaPropertyWidget DrawingGroup.OpacityMaskProperty

    let OpacityMask =
        Attributes.defineAvaloniaPropertyWithEquality DrawingGroup.OpacityMaskProperty

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "DrawingGroup_Children" (fun target -> (target :?> DrawingGroup).Children)

[<AutoOpen>]
module DrawingGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DrawingGroup widget.</summary>
        static member DrawingGroup<'msg>() =
            CollectionBuilder<'msg, IFabDrawingGroup, IFabDrawing>(DrawingGroup.WidgetKey, DrawingGroup.Children, DrawingGroup.Opacity.WithValue(1.0))

        /// <summary>Creates a DrawingGroup widget.</summary>
        /// <param name="opacity">The opacity of the drawing group.</param>
        static member DrawingGroup<'msg>(opacity: float) =
            CollectionBuilder<'msg, IFabDrawingGroup, IFabDrawing>(DrawingGroup.WidgetKey, DrawingGroup.Children, DrawingGroup.Opacity.WithValue(opacity))

[<Extension>]
type DrawingGroupModifiers =

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(DrawingGroup.OpacityMaskWidget.WithValue(value.Compile()))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: IBrush) =
        this.AddScalar(DrawingGroup.OpacityMask.WithValue(value))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: Color) =
        this.AddScalar(DrawingGroup.OpacityMask.WithValue(value |> ImmutableSolidColorBrush))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: string) =
        this.AddScalar(DrawingGroup.OpacityMask.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Sets the Transform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transform value.</param>
    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(DrawingGroup.TransformWidget.WithValue(value.Compile()))

    /// <summary>Sets the Transform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transform value.</param>
    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: string) =
        this.AddScalar(DrawingGroup.Transform.WithValue(Transform.Parse(value)))

    /// <summary>Sets the ClipGeometry property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClipGeometry value.</param>
    [<Extension>]
    static member inline clipGeometry(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: WidgetBuilder<'msg, #IFabGeometry>) =
        this.AddWidget(DrawingGroup.ClipGeometry.WithValue(value.Compile()))

[<Extension>]
type DrawingGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabDrawing>
        (
            _: CollectionBuilder<'msg, 'marker, IFabDrawing>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabDrawing>
        (
            _: CollectionBuilder<'msg, 'marker, IFabDrawing>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
