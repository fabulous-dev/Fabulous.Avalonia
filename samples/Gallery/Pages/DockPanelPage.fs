namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module DockPanelPage =
    let view () =
        (Dock() {
            Rectangle()
                .fill(SolidColorBrush(Colors.Red))
                .height(100.)
                .dock(Dock.Top)

            Rectangle()
                .fill(SolidColorBrush(Colors.Blue))
                .width(100.)
                .dock(Dock.Left)

            Rectangle()
                .fill(SolidColorBrush(Colors.Green))
                .height(100.)
                .dock(Dock.Bottom)

            Rectangle()
                .fill(SolidColorBrush(Colors.Orange))
                .width(100.)
                .dock(Dock.Right)

            Rectangle().fill(SolidColorBrush(Colors.Gray))
        })
            .size(300., 300.)
            .horizontalSpacing(10.)
            .verticalSpacing(10.)
