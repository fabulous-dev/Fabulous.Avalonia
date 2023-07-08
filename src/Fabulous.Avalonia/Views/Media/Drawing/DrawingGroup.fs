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

        static member DrawingGroup<'msg>() =
            CollectionBuilder<'msg, IFabDrawingGroup, IFabDrawing>(DrawingGroup.WidgetKey, DrawingGroup.Children, DrawingGroup.Opacity.WithValue(1.0))

        static member DrawingGroup<'msg>(opacity: float) =
            CollectionBuilder<'msg, IFabDrawingGroup, IFabDrawing>(DrawingGroup.WidgetKey, DrawingGroup.Children, DrawingGroup.Opacity.WithValue(opacity))

[<Extension>]
type DrawingGroupModifiers =

    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(DrawingGroup.OpacityMaskWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, brush: IBrush) =
        this.AddScalar(DrawingGroup.OpacityMask.WithValue(brush))

    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabDrawingGroup>, brush: string) =
        this.AddScalar(DrawingGroup.OpacityMask.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabDrawingGroup>, content: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(DrawingGroup.TransformWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabDrawingGroup>, content: string) =
        this.AddScalar(DrawingGroup.Transform.WithValue(Transform.Parse(content)))

    [<Extension>]
    static member inline clipGeometry(this: WidgetBuilder<'msg, #IFabDrawingGroup>, content: WidgetBuilder<'msg, #IFabGeometry>) =
        this.AddWidget(DrawingGroup.ClipGeometry.WithValue(content.Compile()))

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
