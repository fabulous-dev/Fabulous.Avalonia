namespace Gallery.Pages

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module CustomNotificationView =
    let view title message (yesCommand: 'msg) (noCommand: 'msg) =
        Border(
            Grid(coldefs = [ Auto; Star ], rowdefs = [ Auto ]) {
                (Panel() {
                    TextBlock("&#xE115;")
                        .foreground(SolidColorBrush(Colors.White))
                        .fontWeight(FontWeight.Bold)
                        .fontSize(20.)
                        .textAlignment(TextAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Center)
                })
                    .margin(0., 0., 12., 0.)
                    .width(25.)
                    .height(25.)
                    .verticalAlignment(VerticalAlignment.Top)

                (Dock() {
                    TextBlock(title).dock(Dock.Top).fontWeight(FontWeight.Medium)

                    (HStack(20.) {
                        Button("No", noCommand)
                            .closeOnClick(true)
                            .margin(0., 0., 8., 0.)
                            .dock(Dock.Right)

                        Button("Yes", yesCommand).closeOnClick(true).dock(Dock.Right)
                    })
                        .dock(Dock.Bottom)
                        .margin(0., 8., 0., 0.)

                    TextBlock(message)
                        .margin(0., 8., 0., 0.)
                        .textWrapping(TextWrapping.Wrap)
                        .opacity(0.8)

                })
                    .gridColumn(1)
            }
        )
            .padding(12.)
            .minHeight(20.)
            .background(SolidColorBrush(Colors.DodgerBlue))
