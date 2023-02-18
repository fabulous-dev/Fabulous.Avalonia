namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module DockPanel =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        (Dock() {
            Rectangle()
                .fill(SolidColorBrush(Colors.Red))
                .height(100.)
                .dockPanelDock(Dock.Top)

            Rectangle()
                .fill(SolidColorBrush(Colors.Blue))
                .width(100.)
                .dockPanelDock(Dock.Left)

            Rectangle()
                .fill(SolidColorBrush(Colors.Green))
                .height(100.)
                .dockPanelDock(Dock.Bottom)

            Rectangle()
                .fill(SolidColorBrush(Colors.Orange))
                .width(100.)
                .dockPanelDock(Dock.Right)

            Rectangle().fill(SolidColorBrush(Colors.Gray))
        })
            .size(300., 300.)

    let sample =
        { Name = "DockPanel"
          Description = "The DockPanel control is a Panel which lays out its children by 'docking' them to the sides or floating in the center."
          Program = Helper.createProgram init update view }
