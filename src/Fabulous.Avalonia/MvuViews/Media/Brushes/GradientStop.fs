namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuGradientStop =
    inherit IFabMvuElement
    inherit IFabGradientStop

[<AutoOpen>]
module MvuGradientStopBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a GradientStop widget.</summary>
        /// <param name="color">The color of the gradient stop.</param>
        /// <param name="offset">The offset of the gradient stop.</param>
        static member GradientStop(color: Color, offset: float) =
            WidgetBuilder<unit, IFabMvuGradientStop>(GradientStop.WidgetKey, GradientStop.Color.WithValue(color), GradientStop.Offset.WithValue(offset))

        /// <summary>Creates a GradientStop widget.</summary>
        /// <param name="color">The color of the gradient stop.</param>
        /// <param name="offset">The offset of the gradient stop.</param>
        static member GradientStop(color: string, offset: float) =
            WidgetBuilder<unit, IFabMvuGradientStop>(
                GradientStop.WidgetKey,
                GradientStop.Color.WithValue(Color.Parse(color)),
                GradientStop.Offset.WithValue(offset)
            )

type MvuGradientStopBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabGradientStop>
        (_: CollectionBuilder<'msg, 'marker, IFabGradientStop>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabGradientStop>
        (_: CollectionBuilder<'msg, 'marker, IFabGradientStop>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type GradientStopModifiers =
    /// <summary>Link a ViewRef to access the direct GradientStop control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuGradientStop>, value: ViewRef<GradientStop>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
