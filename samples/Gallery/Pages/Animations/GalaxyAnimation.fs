namespace Gallery.Pages

open System
open System.Numerics
open Avalonia
open Avalonia.Animation.Easings
open Avalonia.Controls
open Avalonia.Controls.Shapes
open Avalonia.Reactive
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module GalaxyAnimation =
    type Model = { Value: int }

    type Msg = OnLoaded of bool

    let init () = { Value = 0 }

    // let mutable _orbitVisual: CompositionVisual = null

    let Apply (rootVisual: Visual) (orbit: Visual) (satellite: Visual) (starField: Visual) (planet: Visual) =

        let compositor = ElementComposition.GetElementVisual(rootVisual).Compositor

        if (compositor = null) then
            ()
        else

            let _orbitVisual = ElementComposition.GetElementVisual(orbit)

            if (_orbitVisual = null) then
                ()
            else
                let orbitAnimation = compositor.CreateScalarKeyFrameAnimation()
                orbitAnimation.Duration <- TimeSpan.FromSeconds(10)
                orbitAnimation.IterationBehavior <- AnimationIterationBehavior.Forever
                orbitAnimation.InsertKeyFrame(1f, float32(4.0 * Math.PI), LinearEasing())
                _orbitVisual.CenterPoint <- Vector3(float32 orbit.Bounds.Width / float32 2, float32 orbit.Bounds.Height / float32 2., float32 0.)
                _orbitVisual.StartAnimation("RotationAngle", orbitAnimation)

                let planetVisual = ElementComposition.GetElementVisual(planet)

                if (planetVisual = null) then
                    ()
                else
                    // FIXME: This was removed in rc2.1. We might need to use a different method to set the transform matrix.
                    //planetVisual.TransformMatrix <- Matrix4x4.CreateTranslation(Vector3(float32 100., float32 0., float32 0.))

                    let satelliteVisual = ElementComposition.GetElementVisual(satellite)

                    if (satelliteVisual = null) then
                        ()
                    else
                        // FIXME: This was removed in rc2.1, We might need to use a different method to set the transform matrix.
                        // satelliteVisual.TransformMatrix <- Matrix4x4.CreateTranslation(Vector3(float32 30, float32 0., float32 0.))

                        satelliteVisual.CenterPoint <-
                            Vector3(float32 satellite.Bounds.Width / float32(2.), float32 satellite.Bounds.Height / float32 2., float32 0)

                        let satelliteAnimation = compositor.CreateExpressionAnimation()
                        satelliteAnimation.Expression <- "3 * orbitVisual.RotationAngle"
                        satelliteAnimation.SetReferenceParameter("orbitVisual", _orbitVisual)
                        satelliteVisual.StartAnimation("RotationAngle", satelliteAnimation)

                        let starsVisual = ElementComposition.GetElementVisual(starField)

                        if (starsVisual = null) then
                            ()
                        else

                            let starsAnimation = compositor.CreateExpressionAnimation()
                            starsAnimation.Expression <- "Max(0.3, Abs(Cos(ToDegrees(orbitVisual.RotationAngle) * 0.02)))"
                            starsAnimation.SetReferenceParameter("orbitVisual", _orbitVisual)
                            starsVisual.StartAnimation("Opacity", starsAnimation)

    // rootVisual.GetObservable(Visual.BoundsProperty).Subscribe(AnonymousObserver<Rect>(
    //     fun _ ->
    //         _orbitVisual.CenterPoint <- Vector3(float32 rootVisual.Bounds.Width / float32 2, (float32)rootVisual.Bounds.Height / float32 2, float32 0)
    //         satelliteVisual.CenterPoint <- Vector3(float32 satellite.Bounds.Width / float32 2., (float32)satellite.Bounds.Height / float32 2, float32 0)
    //     ))
    // |> ignore


    let orbit = ViewRef<Grid>()
    let planet = ViewRef<Grid>()
    let satellite = ViewRef<Ellipse>()
    let startField = ViewRef<Grid>()

    let rootVisual = ViewRef<Grid>()


    let update msg model =
        match msg with
        | OnLoaded _ ->
            Apply rootVisual.Value orbit.Value satellite.Value startField.Value planet.Value
            model

    let view (_: Model) =
        (Grid() {
            Ellipse()
                .width(15.)
                .height(15.)
                .fill(SolidColorBrush(Colors.Orange))

            (Grid() {
                Rectangle()
                    .width(15.)
                    .height(15.)
                    .fill(SolidColorBrush(Colors.Yellow))
                    .renderTransform(TranslateTransform(200., 120.))

                Rectangle()
                    .width(5.)
                    .height(5.)
                    .fill(SolidColorBrush(Colors.Yellow))
                    .renderTransform(TranslateTransform(-200., 150.))

                Rectangle()
                    .width(10.)
                    .height(10.)
                    .fill(SolidColorBrush(Colors.Yellow))
                    .renderTransform(TranslateTransform(-150., -150.))

                Rectangle()
                    .width(5.)
                    .height(5.)
                    .fill(SolidColorBrush(Colors.Yellow))
                    .renderTransform(TranslateTransform(150., -200.))
            })
                .reference(startField)

            (Grid() {
                (Grid() {
                    Ellipse()
                        .width(30.)
                        .height(30.)
                        .fill(SolidColorBrush(Colors.DarkGreen))

                    Ellipse()
                        .width(15.)
                        .height(15.)
                        .fill(SolidColorBrush(Colors.DarkGray))
                        .renderTransform(TranslateTransform(200., 120.))
                        .reference(satellite)

                })
                    .reference(planet)
            })
                .reference(orbit)

        })
            .background(SolidColorBrush(Colors.Black))
            .onLoaded(OnLoaded)
            .reference(rootVisual)
