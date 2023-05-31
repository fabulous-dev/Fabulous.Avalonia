namespace Gallery.Pages

open System.ComponentModel
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Input
open Avalonia.Interactivity
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module FlyoutPage =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | MenuOpening
        | MenuClosing of CancelEventArgs
        | Opened
        | Closed
        | Increment
        | Decrement
        | Reset
        | OnTapped of RoutedEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Counter = 0; IsChecked = false }, []

    let update msg model =
        match msg with
        | OnTapped args ->
            match args.Source with
            | :? Panel as control ->
                FlyoutBase.ShowAttachedFlyout(control)
                model, []
            | _ -> model, []
        | MenuOpening _ -> model, []
        | MenuClosing _ -> model, []
        | Increment ->
            { model with
                Counter = model.Counter + 1 },
            []
        | Decrement ->
            { model with
                Counter = model.Counter - 1 },
            []
        | Reset -> { model with Counter = 0 }, []
        | Opened -> model, []
        | Closed -> model, []

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
            .onOpening(openMsg)
            .onClosing(closeMsg)

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
                        .onOpened(Opened)
                        .onClosed(Closed)
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
                        .flyout(sharedMenuFlyout MenuOpening MenuClosing)

                    Button("Launch Flyout on this button", Increment)
                        .flyout(sharedMenuFlyout MenuOpening MenuClosing)
                }
            )
                .borderThickness(1.)
                .borderBrush(Brushes.Red)
                .padding(10.)
        }
