namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuTransition =
    inherit IFabMvuElement
    inherit IFabTransition

type IFabMvuDoubleTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuDoubleTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DoubleTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member DoubleTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuDoubleTransition>(
                DoubleTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuBoxShadowsTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuBoxShadowsTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a BoxShadowsTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member BoxShadowsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuBoxShadowsTransition>(
                BoxShadowsTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuBrushTransition =
    inherit IFabMvuTransition


[<AutoOpen>]
module MvuBrushTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a BrushTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member BrushTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuBrushTransition>(
                BrushTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuColorTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuColorTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ColorTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member ColorTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuColorTransition>(
                ColorTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuCornerRadiusTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module CornerRadiusTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a CornerRadiusTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member CornerRadiusTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuCornerRadiusTransition>(
                CornerRadiusTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuFloatTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuFloatTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a FloatTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member FloatTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuFloatTransition>(
                FloatTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuIntegerTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuIntegerTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a IntegerTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member IntegerTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuIntegerTransition>(
                IntegerTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuPointTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuPointTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a PointTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member PointTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuPointTransition>(
                PointTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuSizeTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuSizeTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a SizeTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member SizeTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuSizeTransition>(
                SizeTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuThicknessTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuThicknessTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ThicknessTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member ThicknessTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuThicknessTransition>(
                ThicknessTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuTransformOperationsTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuTransformOperationsTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TransformOperationsTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member TransformOperationsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuTransformOperationsTransition>(
                TransformOperationsTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuVectorTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuVectorTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a VectorTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member VectorTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuVectorTransition>(
                VectorTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabMvuEffectTransition =
    inherit IFabMvuTransition

[<AutoOpen>]
module MvuEffectTransitionBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a EffectTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member EffectTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabMvuEffectTransition>(
                EffectTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

// type MvuTransitionBaseCollectionBuilderExtensions =
//     [<Extension>]
//     static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabMvuAnimatable and 'itemType :> IFabMvuTransition>
//         (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuTransition>, x: WidgetBuilder<'msg, 'itemType>)
//         : Content<'msg> =
//         { Widgets = MutStackArray1.One(x.Compile()) }
//
//     [<Extension>]
//     static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabMvuAnimatable and 'itemType :> IFabMvuTransition>
//         (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuTransition>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
//         : Content<'msg> =
//         { Widgets = MutStackArray1.One(x.Compile()) }

type MvuTransitionCollectionModifiers =
    /// <summary>Sets the Transitions property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<'msg, #IFabAnimatable>) =
        AttributeCollectionBuilder<'msg, #IFabAnimatable, #IFabTransition>(this, MvuAnimatable.Transitions)

    /// <summary>Sets the Transition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transition value.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<'msg, #IFabAnimatable>, value: WidgetBuilder<'msg, #IFabTransition>) =
        MvuTransitionCollectionModifiers.transition(this) { value }
