namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Easings
open Fabulous

type IFabDoubleTransition =
    inherit IFabTransition

module DoubleTransition =
    let WidgetKey = Widgets.register<DoubleTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module DoubleTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a DoubleTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member DoubleTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabDoubleTransition>(
                DoubleTransition.WidgetKey,
                DoubleTransition.Property.WithValue(property),
                DoubleTransition.Duration.WithValue(duration)
            )

type DoubleTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabDoubleTransition>, value: TimeSpan) =
        this.AddScalar(DoubleTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabDoubleTransition>, value: Easing) =
        this.AddScalar(DoubleTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct DoubleTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDoubleTransition>, value: ViewRef<DoubleTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabBoxShadowsTransition =
    inherit IFabTransition

module BoxShadowsTransition =

    let WidgetKey = Widgets.register<BoxShadowsTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty


[<AutoOpen>]
module BoxShadowsTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a BoxShadowsTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member BoxShadowsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabBoxShadowsTransition>(
                BoxShadowsTransition.WidgetKey,
                BoxShadowsTransition.Property.WithValue(property),
                BoxShadowsTransition.Duration.WithValue(duration)
            )

type BoxShadowsTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabBoxShadowsTransition>, value: TimeSpan) =
        this.AddScalar(BoxShadowsTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabBoxShadowsTransition>, value: Easing) =
        this.AddScalar(BoxShadowsTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct BoxShadowsTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBoxShadowsTransition>, value: ViewRef<BoxShadowsTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))


type IFabBrushTransition =
    inherit IFabTransition

module BrushTransition =

    let WidgetKey = Widgets.register<BrushTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module BrushTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a BrushTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member BrushTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabBrushTransition>(
                BrushTransition.WidgetKey,
                BrushTransition.Property.WithValue(property),
                BrushTransition.Duration.WithValue(duration)
            )

type BrushTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabBrushTransition>, value: TimeSpan) =
        this.AddScalar(BrushTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabBrushTransition>, value: Easing) =
        this.AddScalar(BrushTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct BrushTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBrushTransition>, value: ViewRef<BrushTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabColorTransition =
    inherit IFabTransition

module ColorTransition =
    let WidgetKey = Widgets.register<ColorTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module ColorTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a ColorTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member ColorTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabColorTransition>(
                ColorTransition.WidgetKey,
                ColorTransition.Property.WithValue(property),
                ColorTransition.Duration.WithValue(duration)
            )

type ColorTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabColorTransition>, value: TimeSpan) =
        this.AddScalar(ColorTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabColorTransition>, value: Easing) =
        this.AddScalar(ColorTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ColorTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorTransition>, value: ViewRef<ColorTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabCornerRadiusTransition =
    inherit IFabTransition

module CornerRadiusTransition =

    let WidgetKey = Widgets.register<CornerRadiusTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module CornerRadiusTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a CornerRadiusTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member CornerRadiusTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabCornerRadiusTransition>(
                CornerRadiusTransition.WidgetKey,
                CornerRadiusTransition.Property.WithValue(property),
                CornerRadiusTransition.Duration.WithValue(duration)
            )

type CornerRadiusTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabCornerRadiusTransition>, value: TimeSpan) =
        this.AddScalar(CornerRadiusTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabCornerRadiusTransition>, value: Easing) =
        this.AddScalar(CornerRadiusTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct CornerRadiusTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCornerRadiusTransition>, value: ViewRef<CornerRadiusTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabFloatTransition =
    inherit IFabTransition

module FloatTransition =
    let WidgetKey = Widgets.register<FloatTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module FloatTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a FloatTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member FloatTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabFloatTransition>(
                FloatTransition.WidgetKey,
                FloatTransition.Property.WithValue(property),
                FloatTransition.Duration.WithValue(duration)
            )

type FloatTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabFloatTransition>, value: TimeSpan) =
        this.AddScalar(FloatTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabFloatTransition>, value: Easing) =
        this.AddScalar(FloatTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct FloatTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabFloatTransition>, value: ViewRef<FloatTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabIntegerTransition =
    inherit IFabTransition

module IntegerTransition =
    let WidgetKey = Widgets.register<IntegerTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module IntegerTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a IntegerTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member IntegerTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabIntegerTransition>(
                IntegerTransition.WidgetKey,
                IntegerTransition.Property.WithValue(property),
                IntegerTransition.Duration.WithValue(duration)
            )

type IntegerTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabIntegerTransition>, value: TimeSpan) =
        this.AddScalar(IntegerTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabIntegerTransition>, value: Easing) =
        this.AddScalar(IntegerTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct IntegerTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabIntegerTransition>, value: ViewRef<IntegerTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabPointTransition =
    inherit IFabTransition

module PointTransition =

    let WidgetKey = Widgets.register<PointTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module PointTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a PointTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member PointTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabPointTransition>(
                PointTransition.WidgetKey,
                PointTransition.Property.WithValue(property),
                PointTransition.Duration.WithValue(duration)
            )

type PointTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabPointTransition>, value: TimeSpan) =
        this.AddScalar(PointTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabPointTransition>, value: Easing) =
        this.AddScalar(PointTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct PointTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPointTransition>, value: ViewRef<PointTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabSizeTransition =
    inherit IFabTransition

module SizeTransition =

    let WidgetKey = Widgets.register<SizeTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module SizeTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a SizeTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member SizeTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabSizeTransition>(
                SizeTransition.WidgetKey,
                SizeTransition.Property.WithValue(property),
                SizeTransition.Duration.WithValue(duration)
            )

type SizeTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabSizeTransition>, value: TimeSpan) =
        this.AddScalar(SizeTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabSizeTransition>, value: Easing) =
        this.AddScalar(SizeTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct SizeTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSizeTransition>, value: ViewRef<SizeTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabThicknessTransition =
    inherit IFabTransition

module ThicknessTransition =

    let WidgetKey = Widgets.register<ThicknessTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module ThicknessTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a ThicknessTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member ThicknessTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabThicknessTransition>(
                ThicknessTransition.WidgetKey,
                ThicknessTransition.Property.WithValue(property),
                ThicknessTransition.Duration.WithValue(duration)
            )

type ThicknessTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabThicknessTransition>, value: TimeSpan) =
        this.AddScalar(ThicknessTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabThicknessTransition>, value: Easing) =
        this.AddScalar(ThicknessTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ThicknessTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabThicknessTransition>, value: ViewRef<ThicknessTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabTransformOperationsTransition =
    inherit IFabTransition

module TransformOperationsTransition =

    let WidgetKey = Widgets.register<TransformOperationsTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module TransformOperationsTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a TransformOperationsTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member TransformOperationsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabTransformOperationsTransition>(
                TransformOperationsTransition.WidgetKey,
                TransformOperationsTransition.Property.WithValue(property),
                TransformOperationsTransition.Duration.WithValue(duration)
            )

type TransformOperationsTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabTransformOperationsTransition>, value: TimeSpan) =
        this.AddScalar(TransformOperationsTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabTransformOperationsTransition>, value: Easing) =
        this.AddScalar(TransformOperationsTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TransformOperationsTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTransformOperationsTransition>, value: ViewRef<TransformOperationsTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))


type IFabVectorTransition =
    inherit IFabTransition

module VectorTransition =

    let WidgetKey = Widgets.register<VectorTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module VectorTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a VectorTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member VectorTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabVectorTransition>(
                VectorTransition.WidgetKey,
                VectorTransition.Property.WithValue(property),
                VectorTransition.Duration.WithValue(duration)
            )

type VectorTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabVectorTransition>, value: TimeSpan) =
        this.AddScalar(VectorTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabVectorTransition>, value: Easing) =
        this.AddScalar(VectorTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct VectorTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabVectorTransition>, value: ViewRef<VectorTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type IFabEffectTransition =
    inherit IFabTransition

module EffectTransition =
    let WidgetKey = Widgets.register<EffectTransition>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DurationProperty

    let Delay =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.DelayProperty

    let Easing =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.EasingProperty

    let Property =
        Attributes.defineAvaloniaPropertyWithEquality TransitionBase.PropertyProperty

[<AutoOpen>]
module EffectTransitionBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a EffectTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member EffectTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabEffectTransition>(
                EffectTransition.WidgetKey,
                EffectTransition.Property.WithValue(property),
                EffectTransition.Duration.WithValue(duration)
            )

type EffectTransitionModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabEffectTransition>, value: TimeSpan) =
        this.AddScalar(EffectTransition.Delay.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabEffectTransition>, value: Easing) =
        this.AddScalar(EffectTransition.Easing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct EffectTransition control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabEffectTransition>, value: ViewRef<EffectTransition>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
