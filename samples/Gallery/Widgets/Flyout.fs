namespace Gallery

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Input
open Avalonia.Interactivity
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Flyout =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | MenuOpened
        | MenuClosed
        | Increment
        | Decrement
        | Reset
        | OnTapped of RoutedEventArgs

    let init () = { Counter = 0; IsChecked = false }

    let update msg model =
        match msg with
        | OnTapped args ->
            let panel = args.Source :?> Panel
            FlyoutBase.ShowAttachedFlyout(panel)
            model
        | MenuOpened _ -> model
        | MenuClosed _ -> model
        | Increment ->
            { model with
                Counter = model.Counter + 1 }
        | Decrement ->
            { model with
                Counter = model.Counter - 1 }
        | Reset -> { model with Counter = 0 }


    let sharedMenuFlyout openMsg closeMsg =
        (MenuFlyout() {
            MenuItem("Standard _Menu Item")
                .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

            MenuItem("Standard _Menu Item")
                .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

            MenuItem("_Disabled Menu Item")
                .inputGesture(KeyGesture(Key.D, KeyModifiers.Control))
                .isEnabled(false)

            Separator()

            MenuItems("Menu with _Submenu") {
                MenuItem("Submenu _1")
                MenuItem("Submenu _1")
                MenuItem("Submenu _2")
                MenuItem("Submenu _2")
            }
        })
            .onOpened(openMsg)
            .onClosed(closeMsg)



    let view _ =
        VStack(spacing = 15.) {
            TextBlock("MenuFlyout")

            Button("Click me", Increment)
                .flyout(
                    Flyout(
                        VStack() {
                            Button("Increment", Increment).width(100)
                            Button("Decrement", Decrement).width(100)
                            Button("Reset", Reset).width(100)
                        }
                    )
                        .showMode(FlyoutShowMode.Standard)
                        .placement(PlacementMode.RightEdgeAlignedTop)
                        .onOpened(MenuOpened)
                        .onClosed(MenuClosed)
                )

            TextBlock("Attached Flyouts")

            Border(
                (VWrap() {
                    TextBlock("Click panel to launch AttachedFlyout")
                        .verticalAlignment(VerticalAlignment.Center)
                        .margin(10.)
                })
                    .attachedFlyout(
                        Flyout(
                            VWrap() {
                                TextBlock("Attached Flyout")
                                    .verticalAlignment(VerticalAlignment.Center)
                                    .margin(10.)
                            }
                        )
                            .showMode(FlyoutShowMode.Standard)
                            .placement(PlacementMode.RightEdgeAlignedTop)
                    )
                    .background(Brushes.Blue)
                    .onTapped(OnTapped)
            )
                .borderBrush(Brushes.Red)
                .borderThickness(1.)
                .padding(10.)

            TextBlock("Shared MenuFlyout")

            Border(
                VStack() {
                    Button("Launch Flyout on this button", Increment)
                        .flyout(sharedMenuFlyout MenuOpened MenuClosed)

                    Button("Launch Flyout on this button", Increment)
                        .flyout(sharedMenuFlyout MenuOpened MenuClosed)
                }
            )
                .borderThickness(1.)
                .borderBrush(Brushes.Red)
                .padding(10.)
        }

    let sample =
        { Name = "Flyout"
          Description = "Control the display of a Flyout"
          Program = Helper.createProgram init update view }
