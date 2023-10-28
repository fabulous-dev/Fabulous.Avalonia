namespace Gallery

open System.Collections.ObjectModel

open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module TreeViewPage =
    type Node(name: string, ?nodes: ObservableCollection<Node>) =
        member this.Name = name

        member this.Nodes = defaultArg nodes (ObservableCollection<Node>([]))

    type Model = { Nodes: ObservableCollection<Node> }

    type Msg = DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Nodes =
            ObservableCollection<Node>(
                [ Node("Animals", ObservableCollection<Node>([ Node("Mammals", ObservableCollection<Node>([ Node("Lion"); Node("Cat"); Node("Zebra") ])) ])) ]
            ) },
        []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view model =
        VStack() {
            TreeView(model.Nodes, (fun x -> TextBlock(x.Name)))

            TreeView() { TreeViewItem("Animals") }
        }
