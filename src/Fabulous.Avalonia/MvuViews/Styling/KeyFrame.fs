namespace Fabulous.Avalonia.Mvu

open System
open System.Globalization
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

type IFabMvuKeyFrame =
    inherit IFabMvuElement
    inherit IFabKeyFrame

[<AutoOpen>]
module MvuKeyFrameBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a KeyFrame widget.</summary>
        /// <param name="setters">The animation setters to apply.</param>
        static member KeyFrames(setters: IAnimationSetter seq) =
            WidgetBuilder<unit, IFabMvuKeyFrame>(KeyFrame.WidgetKey, KeyFrame.Setters.WithValue(setters))

        /// <summary>Creates a KeyFrame widget.</summary>
        /// <param name="property">The property to animate.</param>
        /// <param name="value">The value to animate to.</param>
        static member KeyFrame(property: AvaloniaProperty, value: obj) =
            WidgetBuilder<unit, IFabMvuKeyFrame>(KeyFrame.WidgetKey, KeyFrame.Setter.WithValue(Setter(property, value)))
