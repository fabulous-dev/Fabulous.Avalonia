namespace Gallery

open Avalonia.Media
open Avalonia.Controls
open Fabulous.Avalonia
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module ToolTipPage =
    let view () =
        VStack(spacing = 15.) {
            Border(TextBlock("Hover over me!"))
                .padding(10.)
                .background(SolidColorBrush(Colors.LightGray))
                .tip(ToolTip("Im a tooltip!"))

            Border(TextBlock("Hover over me!"))
                .padding(10.)
                .background(SolidColorBrush(Colors.LightGray))
                .tip(ToolTip("Im a tooltip!").isOpen(true))
                .tooltipPlacement(PlacementMode.Top)


            Border(TextBlock("Hover over me!"))
                .padding(10.)
                .background(SolidColorBrush(Colors.LightGray))
                .tip(
                    ToolTip(
                        VStack() {
                            TextBlock("ToolTip")
                            TextBlock("A control which pops up a hint when a control is hovered")
                        }
                    )
                )
                .tooltipShowDelay(1000)
                .tooltipHorizontalOffset(50.)
                .tooltipVerticalOffset(50.)
        }
