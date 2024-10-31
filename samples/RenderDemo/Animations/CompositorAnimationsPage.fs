namespace RenderDemo

open Fabulous.Avalonia

open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View

module CompositorAnimationsPage =

    let view () =
        TabControl() {
            TabItem("Sliding", SlidingAnimation.view())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("Vector3KeyFrameAnimation", Vector3KeyFrameAnimation.view())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("ExpressionAnimation", ExpressionAnimation.view())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("GalaxyAnimation", GalaxyAnimation.view())
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)
        }
