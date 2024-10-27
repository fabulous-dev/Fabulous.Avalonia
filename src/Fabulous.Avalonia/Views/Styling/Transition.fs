namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Animation.Easings
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabTransition =
    inherit IFabElement

module TransitionBase =
    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

type TransitionBaseModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabTransition>, value: TimeSpan) =
        this.AddScalar(TransitionBase.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabTransition>, value: Easing) =
        this.AddScalar(TransitionBase.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct DoubleTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabTransition>, value: ViewRef<#TransitionBase>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabDoubleTransition =
    inherit IFabTransition

module DoubleTransition =
    let WidgetKey = Widgets.register<DoubleTransition>()

type IFabBoxShadowsTransition =
    inherit IFabTransition

module BoxShadowsTransition =

    let WidgetKey = Widgets.register<BoxShadowsTransition>()


type IFabBrushTransition =
    inherit IFabTransition

module BrushTransition =

    let WidgetKey = Widgets.register<BrushTransition>()


type IFabColorTransition =
    inherit IFabTransition

module ColorTransition =
    let WidgetKey = Widgets.register<ColorTransition>()


type IFabCornerRadiusTransition =
    inherit IFabTransition

module CornerRadiusTransition =

    let WidgetKey = Widgets.register<CornerRadiusTransition>()


type IFabFloatTransition =
    inherit IFabTransition

module FloatTransition =
    let WidgetKey = Widgets.register<FloatTransition>()


type IFabIntegerTransition =
    inherit IFabTransition

module IntegerTransition =
    let WidgetKey = Widgets.register<IntegerTransition>()

type IFabPointTransition =
    inherit IFabTransition

module PointTransition =

    let WidgetKey = Widgets.register<PointTransition>()


type IFabSizeTransition =
    inherit IFabTransition

module SizeTransition =

    let WidgetKey = Widgets.register<SizeTransition>()


type IFabThicknessTransition =
    inherit IFabTransition

module ThicknessTransition =

    let WidgetKey = Widgets.register<ThicknessTransition>()


type IFabTransformOperationsTransition =
    inherit IFabTransition

module TransformOperationsTransition =

    let WidgetKey = Widgets.register<TransformOperationsTransition>()


type IFabVectorTransition =
    inherit IFabTransition

module VectorTransition =

    let WidgetKey = Widgets.register<VectorTransition>()


type IFabEffectTransition =
    inherit IFabTransition

module EffectTransition =
    let WidgetKey = Widgets.register<EffectTransition>()


type TransitionBaseCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabAnimatable and 'itemType :> IFabTransition>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabTransition>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabAnimatable and 'itemType :> IFabTransition>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabTransition>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
