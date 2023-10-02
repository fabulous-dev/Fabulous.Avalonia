namespace RenderDemo

open System
open System.Numerics
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ExpressionAnimation =
    type Model = { Value: int }

    type Msg = OnAttachedToVisualTree of VisualTreeAttachmentEventArgs

    let init () = { Value = 0 }

    let Apply (visual: Border) (visualRoot: Visual) =
        let compositionVisual = ElementComposition.GetElementVisual(visual)
        let compositionVisualWindow = ElementComposition.GetElementVisual(visualRoot)

        if compositionVisual <> null && compositionVisualWindow <> null then
            let compositor = compositionVisual.Compositor

            let animation =
                compositor.CreateExpressionAnimation("Clamp(this.Target.Size.X / Window.Size.X, 0.0, 1.0)")

            animation.SetReferenceParameter("Window", compositionVisualWindow)
            compositionVisual.StartAnimation("Opacity", animation)

    let borderRef = ViewRef<Border>()
    let visualRootRef = ViewRef<ScrollViewer>()

    let update msg model =
        match msg with
        | OnAttachedToVisualTree _ ->
            Apply borderRef.Value visualRootRef.Value
            model

    let view (_: Model) =
        (ScrollViewer(
            Dock() {
                TextBlock("Resize window horizontally to change Border opacity.")
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .dock(Dock.Top)
                    .margin(12.)

                EmptyBorder()
                    .background(SolidColorBrush(Colors.Red))
                    .width(200.)
                    .height(200.)
                    .reference(borderRef)
                    .onAttachedToVisualTree(OnAttachedToVisualTree)
            }
        ))
            .reference(visualRootRef)
