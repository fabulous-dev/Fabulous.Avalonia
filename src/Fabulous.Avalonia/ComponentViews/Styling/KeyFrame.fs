namespace Fabulous.Avalonia.Components

open Avalonia
open Avalonia.Animation
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

type IFabComponentKeyFrame =
    inherit IFabComponentElement
    inherit IFabKeyFrame

[<AutoOpen>]
module ComponentKeyFrameBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a KeyFrame widget.</summary>
        /// <param name="setters">The animation setters to apply.</param>
        static member KeyFrames(setters: IAnimationSetter seq) =
            WidgetBuilder<unit, IFabComponentKeyFrame>(KeyFrame.WidgetKey, KeyFrame.Setters.WithValue(setters))

        /// <summary>Creates a KeyFrame widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="value">The value to animate to.</param>
        static member KeyFrame(property: AvaloniaProperty, value: obj) =
            WidgetBuilder<unit, IFabComponentKeyFrame>(KeyFrame.WidgetKey, KeyFrame.Setter.WithValue(Setter(property, value)))
