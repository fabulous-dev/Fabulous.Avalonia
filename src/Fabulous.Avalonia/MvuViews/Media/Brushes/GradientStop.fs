namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentGradientStop =
    inherit IFabComponentElement
    inherit IFabGradientStop

[<AutoOpen>]
module ComponentGradientStopBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a GradientStop widget.</summary>
        /// <param name="color">The color of the gradient stop.</param>
        /// <param name="offset">The offset of the gradient stop.</param>
        static member GradientStop(color: Color, offset: float) =
            WidgetBuilder<unit, IFabComponentGradientStop>(GradientStop.WidgetKey, GradientStop.Color.WithValue(color), GradientStop.Offset.WithValue(offset))

        /// <summary>Creates a GradientStop widget.</summary>
        /// <param name="color">The color of the gradient stop.</param>
        /// <param name="offset">The offset of the gradient stop.</param>
        static member GradientStop(color: string, offset: float) =
            WidgetBuilder<unit, IFabComponentGradientStop>(
                GradientStop.WidgetKey,
                GradientStop.Color.WithValue(Color.Parse(color)),
                GradientStop.Offset.WithValue(offset)
            )

type ComponentGradientStopBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGradientStop>
        (_: CollectionBuilder<'msg, 'marker, IFabGradientStop>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGradientStop>
        (_: CollectionBuilder<'msg, 'marker, IFabGradientStop>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type GradientStopModifiers =
    /// <summary>Link a ViewRef to access the direct GradientStop control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentGradientStop>, value: ViewRef<GradientStop>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
