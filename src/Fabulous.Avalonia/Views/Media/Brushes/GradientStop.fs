namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabGradientStop =
    inherit IFabElement

module GradientStop =

    let WidgetKey = Widgets.register<GradientStop>()

    let Color = Attributes.defineAvaloniaPropertyWithEquality GradientStop.ColorProperty

    let Offset =
        Attributes.defineAvaloniaPropertyWithEquality GradientStop.OffsetProperty

type GradientStopBuilderExtensions =
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
    static member inline reference(this: WidgetBuilder<'msg, #IFabGradientStop>, value: ViewRef<GradientStop>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
