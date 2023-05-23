namespace Gallery.Root

open Fabulous
open Gallery
open Types

module State =
    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NewMsg msg -> Cmd.ofMsg msg
        | SubpageCmdMsgs cmdMsgs ->
            let cmd = NavigationState.mapCmdMsgToMsg nav cmdMsgs
            Cmd.map SubpageMsg cmd

    let init () =
        let model, cmdMsgs = NavigationState.initRoute NavigationRoute.AcrylicPage None

        { SafeAreaInsets = 0.
          Navigation = NavigationModel.Init(model) },
        [ SubpageCmdMsgs cmdMsgs ]

    let update msg model =
        match msg with
        | OnLoaded _ ->
#if MOBILE
            { model with SafeAreaInsets = 32. }, []
#else
            model, []
#endif
        | SubpageMsg subpageMsg ->
            let nav, cmdMsgs = NavigationState.update subpageMsg model.Navigation
            { model with Navigation = nav }, [ SubpageCmdMsgs cmdMsgs ]

        | NavigationMsg route ->
            let m, c = NavigationState.initRoute route (Some model.Navigation)

            { model with
                Navigation = model.Navigation.Push(m) },
            [ SubpageCmdMsgs c ]
