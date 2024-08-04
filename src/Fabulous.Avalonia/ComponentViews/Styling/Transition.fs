namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentTransition =
    inherit IFabComponentElement
    inherit IFabTransition

type IFabComponentDoubleTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentDoubleTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DoubleTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member DoubleTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabDoubleTransition>(
                DoubleTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentBoxShadowsTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentBoxShadowsTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a BoxShadowsTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member BoxShadowsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentBoxShadowsTransition>(
                BoxShadowsTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentBrushTransition =
    inherit IFabComponentTransition


[<AutoOpen>]
module ComponentBrushTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a BrushTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member BrushTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentBrushTransition>(
                BrushTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentColorTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentColorTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ColorTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member ColorTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentColorTransition>(
                ColorTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentCornerRadiusTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module CornerRadiusTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a CornerRadiusTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member CornerRadiusTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentCornerRadiusTransition>(
                CornerRadiusTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentFloatTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentFloatTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a FloatTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member FloatTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentFloatTransition>(
                FloatTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentIntegerTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentIntegerTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a IntegerTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member IntegerTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentIntegerTransition>(
                IntegerTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentPointTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentPointTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a PointTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member PointTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentPointTransition>(
                PointTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentSizeTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentSizeTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a SizeTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member SizeTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentSizeTransition>(
                SizeTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentThicknessTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentThicknessTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ThicknessTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member ThicknessTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentThicknessTransition>(
                ThicknessTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentTransformOperationsTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentTransformOperationsTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TransformOperationsTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member TransformOperationsTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentTransformOperationsTransition>(
                TransformOperationsTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentVectorTransition =
    inherit IFabComponentTransition

[<AutoOpen>]
module ComponentVectorTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a VectorTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member VectorTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentVectorTransition>(
                VectorTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type IFabComponentEffectTransition =
    inherit IFabTransition

[<AutoOpen>]
module ComponentEffectTransitionBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a EffectTransition widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member EffectTransition(property: AvaloniaProperty, duration: TimeSpan) =
            WidgetBuilder<unit, IFabComponentEffectTransition>(
                EffectTransition.WidgetKey,
                TransitionBase.Property.WithValue(property),
                TransitionBase.Duration.WithValue(duration)
            )

type ComponentTransitionBaseCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabComponentAnimatable and 'itemType :> IFabComponentTransition>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabComponentTransition>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabComponentAnimatable and 'itemType :> IFabComponentTransition>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabComponentTransition>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type ComponentTransitionCollectionModifiers =
    /// <summary>Sets the Transitions property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<unit, #IFabComponentAnimatable>) =
        AttributeCollectionBuilder<unit, #IFabComponentAnimatable, IFabComponentTransition>(this, ComponentAnimatable.Transitions)

    /// <summary>Sets the Transition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transition value.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<unit, #IFabAnimatable>, value: WidgetBuilder<unit, #IFabComponentTransition>) =
        AttributeCollectionBuilder<unit, #IFabComponentAnimatable, IFabComponentTransition>(this, ComponentAnimatable.Transitions) { value }
