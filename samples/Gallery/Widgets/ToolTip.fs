namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ToolTip =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model


    let view _ =
        VStack(spacing = 15.) {
            Border(TextBlock("Hover over me!"))
                .padding(10.)
                .background(SolidColorBrush(Colors.LightGray))
                .tooltip ("Im a tooltip!")

            Border(TextBlock("Hover over me!"))
                .padding(10.)
                .background(SolidColorBrush(Colors.LightGray))
                .tooltip(
                    VStack() {
                        TextBlock("ToolTip")
                        TextBlock("A control which pops up a hint when a control is hovered")
                    }
                )
                .tooltipShowDelay (1000)
        }


    let sample =
        { Name = "ToolTip"
          Description =
            "The ToolTip is a control that pops up with hint text when hovered over the appropriate control."
          Program = Helper.createProgram init update view }
