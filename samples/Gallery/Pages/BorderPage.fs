namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module BorderPage =
    let view () =
        VStack(spacing = 4) {
            TextBlock("A control which decorates a child with a border and background")

            (VStack(16.) {
                Border(TextBlock("Border"))
                    .background(SolidColorBrush(Colors.ForestGreen))
                    .borderBrush(SolidColorBrush(Colors.BlueViolet))
                    .borderThickness(2.)
                    .padding(16.)

            })
                .margin(0., 16.)
                .horizontalAlignment(HorizontalAlignment.Center)


            Border(TextBlock("Border and Background"))
                .background(SolidColorBrush(Colors.ForestGreen))
                .borderBrush(SolidColorBrush(Colors.BlueViolet))
                .borderThickness(4.)
                .padding(16.)
                .horizontalAlignment(HorizontalAlignment.Center)

            Border(TextBlock("Rounded Corners"))
                .borderBrush(Brushes.BlueViolet)
                .borderThickness(4.)
                .cornerRadius(8.)
                .padding(16.)
                .horizontalAlignment(HorizontalAlignment.Center)

            Border(TextBlock("Rounded Corners"))
                .background(Colors.Magenta)
                .cornerRadius(8.)
                .padding(16.)
                .horizontalAlignment(HorizontalAlignment.Center)

            Border(Image("avares://Gallery/Assets/Icons/fabulous-icon.png"))
                .width(100.)
                .height(100.)
                .borderThickness(0.)
                .background("#00fa9a")
                .cornerRadius(100.)
                .clipToBounds(true)
        }
