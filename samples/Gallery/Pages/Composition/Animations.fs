namespace Gallery.Pages

open System
open System.Numerics
open Avalonia
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Fabulous.Avalonia
open System.Threading

open type Fabulous.Avalonia.View


module Animations =

    type Model = { Title: string }

    type Msg =
        | ButtonThreadSleep
        | AttachAnimatedSolidVisual of VisualTreeAttachmentEventArgs

    let init () = { Title = "Animations" }

    let mutable _solidVisual: CompositionSolidColorVisual = null

    let updateSolidVisual (v: Visual) =

        if (_solidVisual = null) then
            ()
        else
            _solidVisual.Size <- Vector(v.Bounds.Width / float 3, v.Bounds.Height / float 3)
            _solidVisual.Offset <- Vector3D(v.Bounds.Width / float 3, v.Bounds.Height / float 3, 0)


    let update msg model =
        match msg with
        | ButtonThreadSleep ->
            Thread.Sleep(10000)
            model
        | AttachAnimatedSolidVisual args ->
            let v = args.Parent :?> Control
            let compositor = ElementComposition.GetElementVisual(v).Compositor

            if
                compositor = null
                || (_solidVisual <> null && _solidVisual.Compositor = compositor)
            then
                ()
            else
                _solidVisual <- compositor.CreateSolidColorVisual()
                ElementComposition.SetElementChildVisual(v, _solidVisual)
                _solidVisual.Color <- Colors.Red
                let animation = _solidVisual.Compositor.CreateColorKeyFrameAnimation()
                animation.InsertKeyFrame(float32 0, Colors.Red)
                animation.InsertKeyFrame(0.5f, Colors.Blue)
                animation.InsertKeyFrame(float32 1, Colors.Green)
                animation.Duration <- TimeSpan.FromSeconds(5)
                animation.IterationBehavior <- AnimationIterationBehavior.Forever
                animation.Direction <- PlaybackDirection.Alternate
                _solidVisual.StartAnimation("Color", animation)
                _solidVisual.AnchorPoint <- Vector2(float32 0.0, float32 0.0)
                let scale = _solidVisual.Compositor.CreateVector3KeyFrameAnimation()
                scale.Duration <- TimeSpan.FromSeconds(5)
                scale.IterationBehavior <- AnimationIterationBehavior.Forever
                scale.InsertKeyFrame(float32 0, Vector3(float32 1.0, float32 1.0, float32 0.0))
                scale.InsertKeyFrame(0.5f, Vector3(1.5f, 1.5f, float32 0.0))
                scale.InsertKeyFrame(float32 1, Vector3(float32 1.0, float32 1.0, float32 0.0))
                _solidVisual.StartAnimation("Scale", scale)

                let center =
                    _solidVisual.Compositor.CreateExpressionAnimation("Vector3(this.Target.Size.X * 0.5, this.Target.Size.Y * 0.5, 1)")

                _solidVisual.StartAnimation("CenterPoint", center)
                updateSolidVisual v

            v.PropertyChanged.AddHandler(fun _ a ->
                if a.Property = Visual.BoundsProperty then
                    updateSolidVisual v)

            model

    let view model =
        TabItem(
            "Animation",
            Dock() {
                Button("Thread.Sleep(10000);", ButtonThreadSleep)
                    .dock(Dock.Top)

                Border().onAttachedToVisualTree(AttachAnimatedSolidVisual)
            }
        )
