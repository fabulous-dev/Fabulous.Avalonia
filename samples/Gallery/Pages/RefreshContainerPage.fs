namespace Gallery.Pages

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Input

open type Fabulous.Avalonia.View

module RefreshContainerPage =
    type Model = { Items: int seq }

    type Msg = RefreshRequested of RefreshRequestedEventArgs

    let init () = { Items = [ 0..100 ] }

    let update msg model =
        match msg with
        | RefreshRequested _ -> model

    let visualizer =
        RefreshVisualizer(TextBlock("Pull to refresh").foreground(SolidColorBrush(Colors.Red)))
            .size(100., 100.)

    let view model =
        RefreshContainer(ListBox(model.Items, (fun x -> TextBlock $"Item %d{x}")).height(500.))
            .visualizer(visualizer)
            .onRefreshRequested(RefreshRequested)
            .pullDirection(PullDirection.TopToBottom)
            .horizontalAlignment(HorizontalAlignment.Stretch)
            .verticalAlignment(VerticalAlignment.Stretch)
            .margin(5.)
            .dock(Dock.Bottom)
