namespace Gallery.Pages

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module TickBarPage =
    type Model = { Nothing: bool }

    let init () = { Nothing = true }, []

    type Msg = DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view _ =
        Grid(coldefs = [ Stars(0.5); Stars(0.5) ], rowdefs = [ Stars(0.5); Stars(0.5) ]) {
            TickBar(0., 300.)
                .fill(SolidColorBrush(Colors.LightGreen))
                .tickFrequency(10.0)
                .placement(TickBarPlacement.Top)
                .width(300.)
                .height(50.)


            TickBar(0., 300.)
                .fill(SolidColorBrush(Colors.LightGreen))
                .orientation(Orientation.Horizontal)
                .tickFrequency(10.0)
                .placement(TickBarPlacement.Bottom)
                .gridColumn(1)
                .width(300.)
                .height(50.)

            TickBar(0., 300.)
                .fill(SolidColorBrush(Colors.LightGreen))
                .tickFrequency(10.0)
                .placement(TickBarPlacement.Left)
                .gridRow(1)
                .gridColumn(0)
                .width(50.)
                .height(300.)

            TickBar(0., 100.)
                .fill(SolidColorBrush(Colors.LightGreen))
                .placement(TickBarPlacement.Right)
                .ticks([ 0.; 10.; 20.; 30.; 40.; 50.; 60.; 70.; 80.; 90.; 100. ])
                .gridRow(1)
                .gridColumn(1)
                .width(50.)
                .height(300.)
        }
