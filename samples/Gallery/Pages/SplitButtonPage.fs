namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module SplitButtonPage =
    let colors =
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
          Colors.White ]

    let menuFlyout () =
        (MenuFlyout() {
            MenuItems("Item 1") {
                MenuItem("Subitem 1")
                MenuItem("Subitem 2")
                MenuItem("Subitem 3")
            }

            MenuItem("Item 2")
                .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

            MenuItem("Item 3")
        })
            .placement(PlacementMode.Bottom)

    let availableColors (colors: Color list) (value: StateValue<Color>) =
        Component() {
            let! selectedColor = Context.Binding(value)

            (MenuFlyout() {
                MenuItem(
                    ScrollViewer(
                        HWrap() {
                            for color in colors do
                                Rectangle()
                                    .size(50., 50.)
                                    .fill(SolidColorBrush(color))
                                    .onPointerPressed(fun _ -> selectedColor.Set(color))
                        }
                    )
                )
            })
                .placement(PlacementMode.Bottom)
        }


    let view () =
        Component() {
            let! color = Context.State(colors[0])

            (VStack(spacing = 16.) {
                SplitButton("Content").flyout(menuFlyout())

                SplitButton("Disabled").isEnabled(false)

                SplitButton("Re-themed")
                    .flyout(menuFlyout())
                    .foreground(SolidColorBrush(Colors.White))

                SplitButton(
                    Rectangle()
                        .size(32., 32.)
                        .fill(SolidColorBrush(color.Current))
                )
                    .flyout(availableColors colors color)
            })
                .horizontalAlignment(HorizontalAlignment.Center)

        }
