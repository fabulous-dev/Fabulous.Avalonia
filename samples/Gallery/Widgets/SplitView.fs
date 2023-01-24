namespace Gallery

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module SplitView =
    type Model = { IsOpen: bool }

    type Msg = | Open

    let init () = { IsOpen = false }

    let update msg model =
        match msg with
        | Open -> { model with IsOpen = not model.IsOpen }

    let view model =
        VStack() {
            Button("Open", Open)

            SplitView(
                TextBlock("Pane")
                    .fontSize(24.)
                    .verticalAlignment(VerticalAlignment.Center)
                    .horizontalAlignment(HorizontalAlignment.Center),

                Grid() {
                    TextBlock("Content")
                        .fontSize(24.)
                        .verticalAlignment(VerticalAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center)

                }
            )
                .isPaneOpen(model.IsOpen)
                .paneBackground(SolidColorBrush(Colors.LightGray))
                .useLightDismissOverlayMode(true)

                .displayMode(SplitViewDisplayMode.Inline)
                .openPaneLength(296.0)
        }


    let sample =
        { Name = "SplitView"
          Description = "Control that displays a pane and content"
          Program = Helper.createProgram init update view }
