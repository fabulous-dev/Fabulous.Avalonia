namespace Gallery.Root

open Fabulous
open Gallery
open Types

module State =
    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NewMsg msg -> Cmd.ofMsg msg
        | SubpageCmdMsgs cmdMsgs ->
            let cmd = NavigationState.mapCmdMsgToMsg cmdMsgs
            Cmd.map SubpageMsg cmd

    let init () =
#if MOBILE || BROWSER
        let model, cmdMsgs = NavigationState.initRoute NavigationRoute.AcrylicPage None

        { Navigation = NavigationModel.Init(model)
          IsPanOpen = false
          SafeAreaInsets = 0.
          Pages = NavigationRoute.GetNames()
          SelectedIndex = 0
          PaneLength = 150. },
        [ SubpageCmdMsgs cmdMsgs ]
#else
        let model, cmdMsgs = NavigationState.initRoute NavigationRoute.AcrylicPage None

        { Navigation = NavigationModel.Init(model)
          IsPanOpen = true
          Pages = NavigationRoute.GetNames()
          SafeAreaInsets = 0.
          SelectedIndex = 0
          PaneLength = 250. },
        [ SubpageCmdMsgs cmdMsgs ]
#endif

    let update msg model =
        match msg with
        | OnLoaded _ ->
#if MOBILE
            { model with
                SafeAreaInsets = 32.
                PaneLength = 180. },
            []
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

        | SelectedIndexChanged index ->
            let route = NavigationRoute.GetRoute(model.Pages.[index])
            let modelRoute, cmdMsgs = NavigationState.initRoute route None

            let model =
                { model with
                    SelectedIndex = index
                    Navigation = NavigationModel.Init(modelRoute) }

            model, [ SubpageCmdMsgs cmdMsgs ]
