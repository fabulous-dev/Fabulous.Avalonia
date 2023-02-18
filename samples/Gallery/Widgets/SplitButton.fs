namespace Gallery

open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module SplitButton =
    type Model = { Colors: Color list }

    type Msg = | Clicked

    let init () =
        { Colors =
            [ Colors.Red
              Colors.Green
              Colors.Blue
              Colors.Yellow
              Colors.Purple
              Colors.Orange
              Colors.Pink
              Colors.Brown
              Colors.Black
              Colors.White
              Colors.Gray
              Colors.Cyan
              Colors.Magenta
              Colors.Lime
              Colors.Turquoise
              Colors.Black
              Colors.Red
              Colors.Bisque
              Colors.White ] }

    let update msg model =
        match msg with
        | Clicked -> model

    let menuFlyout () =
        (MenuFlyout() {
            MenuItems("Item 1") {
                MenuItem("Subitem 1")
                MenuItem("Subitem 2")
                MenuItem("Subitem 3")
            }

            MenuItem("Item 2").inputGesture(KeyGesture(Key.A, KeyModifiers.Control))
            MenuItem("Item 3")
        })
            .placement(FlyoutPlacementMode.Bottom)

    let availableColors colors =
        (MenuFlyout() {
            MenuItem(
                ScrollViewer(
                    (HWrap() {
                        for color in colors do
                            Rectangle().size(50., 50.).fill(SolidColorBrush(color))
                    })
                )

            )
        })
            .placement(FlyoutPlacementMode.Bottom)


    let view model =
        (VStack(spacing = 16.) {
            SplitButton("Content", Clicked).flyout(menuFlyout())

            SplitButton("Disabled", Clicked).isEnabled(false)

            SplitButton("Re-themed", Clicked)
                .flyout(menuFlyout())
                .foreground(SolidColorBrush(Colors.White))

            SplitButton(Clicked, Rectangle().size(32., 32.).fill(SolidColorBrush(Colors.Red)))
                .flyout(availableColors model.Colors)
        })
            .horizontalAlignment(HorizontalAlignment.Center)

    let sample =
        { Name = "SplitButton"
          Description =
            "The SplitButton functions as a Button with primary and secondary parts that can each be pressed separately. The primary part behaves like normal Button and the secondary part opens a Flyout with additional actions."
          Program = Helper.createProgram init update view }
