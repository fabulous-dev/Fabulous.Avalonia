namespace Gallery.Pages

open System.ComponentModel
open Avalonia.Input
open Fabulous.Avalonia


open Fabulous.Avalonia.DataGid
open type Fabulous.Avalonia.View

module DataGridPage =
    type Model = { Nothing: int }

    type Msg = | DoNothing

    let init () = { Nothing = 0 }

    let update msg model =
        match msg with
        | DoNothing -> model

    let view model =
        DataGrid([ "A"; "B" ], (fun x -> TextBlock(x)))
