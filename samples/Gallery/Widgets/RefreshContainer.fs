namespace Gallery

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Input

open type Fabulous.Avalonia.View

module RefreshContainer =
    type Model = Id

    type Msg = RefreshRequested of RefreshRequestedEventArgs

    let init () = Id

    let update msg model =
        match msg with
        | RefreshRequested _ -> model

    let visualizer =
        RefreshVisualizer(TextBlock("Pull to refresh").foreground(SolidColorBrush(Colors.Red)))
            .size(100., 100.)

    let view _ =
        RefreshContainer(
            (ListBox() {
                for x = 0 to 100 do
                    TextBlock(sprintf "Item %d" x)
            })
                .height(500.)
        )
            .visualizer(visualizer)
            .onRefreshRequested(RefreshRequested)
            .pullDirection(PullDirection.TopToBottom)
            .horizontalAlignment(HorizontalAlignment.Stretch)
            .verticalAlignment(VerticalAlignment.Stretch)
            .margin(5.)
            .dock(Dock.Bottom)


    let sample =
        { Name = "RefreshContainer"
          Description = "Pull to refresh container"
          Program = Helper.createProgram init update view }
