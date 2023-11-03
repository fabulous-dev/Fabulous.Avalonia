namespace Gallery

open System.Collections.ObjectModel

open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module TreeViewPage =
    type Node = { Name: string; Children: Node list }

    type Model = { Nodes: Node list }

    type Msg = DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Nodes =
            [ { Name = "Animals"
                Children =
                  [ { Name = "Mammals"
                      Children =
                        [ { Name = "Lion"; Children = [] }
                          { Name = "Cat"; Children = [] }
                          { Name = "Zebra"; Children = [] } ] } ] } ] },
        []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view model =
        VStack() { TreeView(model.Nodes, (fun node -> node.Children), (fun x -> TextBlock(x.Name))) }
