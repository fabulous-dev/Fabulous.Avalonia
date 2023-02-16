namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TreeView =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack(spacing = 15.) {
            TreeView([], (fun x -> TextBlock(x)))
        // TreeView(model.Conferences, fun conference ->
        //     TreeNode(TextBlock(conference.Name), conference.Teams, fun team ->
        //         TreeNode(TextBlock(team.Name), team.Rosters, fun roster ->
        //             match roster with
        //             | :? Player as player -> TextBlock(player.Name)
        //             | :? Coach as coach -> TextBlock(coach.Name)
        //         )
        //     )
        // )

        // TreeNode -> TreeDataTemplate
        // Other widget -> DataTemplate
        }

    let sample =
        { Name = "TreeView"
          Description = "TreeView is a control that displays hierarchical data in a tree structure."
          Program = Helper.createProgram init update view }
