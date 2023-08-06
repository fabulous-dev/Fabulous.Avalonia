namespace Gallery.Root

open Avalonia.Controls
open Fabulous
open Gallery
open Gallery.Pages
open Types

module State =
    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NewMsg msg -> Cmd.ofMsg msg
        | SubpageCmdMsgs cmdMsgs ->
            let cmd = NavigationState.mapCmdMsgToMsg cmdMsgs
            Cmd.map SubpageMsg cmd

    let init () =
#if MOBILE
        let model, cmdMsgs = NavigationState.initRoute NavigationRoute.AcrylicPage

        { Navigation = NavigationModel.Init(model)
          IsPanOpen = false
          HeaderText = model.GetSubpageName()
          PaneLength = 150. },
        [ SubpageCmdMsgs cmdMsgs ]
#else
        let model, cmdMsgs = NavigationState.initRoute NavigationRoute.AcrylicPage

        { Navigation = NavigationModel.Init(model)
          IsPanOpen = false
          PaneLength = 250.
          HeaderText = model.GetSubpageName() },
        [ SubpageCmdMsgs cmdMsgs ]
#endif

    let update msg model =
        match msg with
        | OnLoaded _ ->
#if MOBILE
            { model with PaneLength = 180. }, []
#else
            model, []
#endif
        | SubpageMsg subpageMsg ->
            let nav, cmdMsgs = NavigationState.update subpageMsg model.Navigation
            { model with Navigation = nav }, [ SubpageCmdMsgs cmdMsgs ]

        | OpenPanChanged x -> { model with IsPanOpen = x }, []

        | OpenPan ->
            { model with
                IsPanOpen = not model.IsPanOpen },
            []

        | OnSelectionChanged args ->
            let route =
                args.AddedItems
                |> Seq.cast<ListBoxItem>
                |> Seq.tryHead
                |> Option.map(fun x -> unbox<string>(x.Content))

            let route =
                match route with
                | Some x -> x
                | None -> failwithf "Could not find route"

            let route = NavigationRoute.GetRoute(route)
            let modelRoute, cmdMsgs = NavigationState.initRoute route

            { model with
                Navigation = NavigationModel.Init(modelRoute)
                HeaderText = modelRoute.GetSubpageName() },
            [ SubpageCmdMsgs cmdMsgs ]

        | DoNothing -> model, []

        | Update date ->
            match model.Navigation.CurrentPage with
            | CanvasPageModel _ -> model, [ NewMsg(SubpageMsg(CanvasPageMsg(CanvasPage.Msg.Update(date)))) ]
            | _ -> model, []
