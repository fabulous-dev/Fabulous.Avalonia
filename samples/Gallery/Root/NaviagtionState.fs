namespace Gallery.Root

open Gallery
open Gallery.Pages
open Fabulous
open Fabulous.Avalonia

type SubpageModel =
    //| HomePageModel of Pages.Types.Model
    | AcrylicPageModel of AcrylicPage.Model
    | AdornerLayerPageModel of AdornerLayerPage.Model

type SubpageMsg =
    //| HomePageMsg of Pages.Types.Msg
    | AcrylicPageMsg of AcrylicPage.Msg
    | AdornerLayerPageMsg of AdornerLayerPage.Msg

type SubpageCmdMsg =
    //| HomePageCmdMsgs of Pages.Types.CmdMsg list
    | AcrylicPageCmdMsgs of AcrylicPage.CmdMsg list
    | AdornerLayerPageCmdMsgs of AdornerLayerPage.CmdMsg list

type NavigationModel =
    { BackStack: SubpageModel list
      CurrentPage: SubpageModel
      ForwardStack: SubpageModel list }

    static member Init(root: SubpageModel) =
        { BackStack = []
          CurrentPage = root
          ForwardStack = [] }

    member this.Push(page: SubpageModel) =
        { BackStack = this.CurrentPage :: this.BackStack
          CurrentPage = page
          ForwardStack = [] }

    member this.PushToRoot(page: SubpageModel) =
        { BackStack = []
          CurrentPage = page
          ForwardStack = [] }

    member this.Pop() =
        match this.BackStack with
        | [] -> this
        | previous :: rest ->
            { BackStack = rest
              CurrentPage = previous
              ForwardStack = [] }

    member this.Forward() =
        match this.ForwardStack with
        | [] -> this
        | next :: rest ->
            { BackStack = this.CurrentPage :: this.BackStack
              CurrentPage = next
              ForwardStack = rest }

    member this.Backward() =
        match this.BackStack with
        | [] -> this
        | previous :: rest ->
            { BackStack = rest
              CurrentPage = previous
              ForwardStack = this.CurrentPage :: this.ForwardStack }

module NavigationState =
    let mapCmdMsgToMsg nav cmdMsgs =
        let mapSubpageCmdMsg (cmdMsg: SubpageCmdMsg) =
            let map (mapCmdMsgFn: NavigationController -> 'subCmdMsg -> Cmd<'subMsg>) (mapFn: 'subMsg -> 'msg) (subCmdMsgs: 'subCmdMsg list) =
                subCmdMsgs
                |> List.map(fun c ->
                    let cmd = mapCmdMsgFn nav c
                    Cmd.map mapFn cmd)

            match cmdMsg with
            | AcrylicPageCmdMsgs subCmdMsgs -> map AcrylicPage.mapCmdMsgToCmd AcrylicPageMsg subCmdMsgs
            | AdornerLayerPageCmdMsgs subCmdMsgs -> map AdornerLayerPage.mapCmdMsgToCmd AdornerLayerPageMsg subCmdMsgs
        //| HomePageCmdMsgs cmdMsgs -> map Pages.State.mapCmdMsgToCmd HomePageMsg cmdMsgs

        cmdMsgs |> List.map mapSubpageCmdMsg |> List.collect id |> Cmd.batch

    let initRoute (route: NavigationRoute) (_navigationModel: NavigationModel option) =
        match route with
        | NavigationRoute.AcrylicPage ->
            let m, c = AcrylicPage.init()
            AcrylicPageModel m, [ AcrylicPageCmdMsgs c ]

        | NavigationRoute.AdornerLayerPage ->
            let m, c = AdornerLayerPage.init()
            AdornerLayerPageModel m, [ AdornerLayerPageCmdMsgs c ]

    // | NavigationRoute.HomePage ->
    //     let m, c = Pages.State.init()
    //     HomePageModel m, [] //[  HomePageCmdMsgs c ]

    let update (msg: SubpageMsg) (model: NavigationModel) =
        let subpageModel, cmdMsgs =
            match msg, model.CurrentPage with
            | AcrylicPageMsg subMsg, AcrylicPageModel m ->
                let m, c = AcrylicPage.update subMsg m
                AcrylicPageModel m, [ AcrylicPageCmdMsgs c ]

            | AdornerLayerPageMsg subMsg, AdornerLayerPageModel m ->
                let m, c = AdornerLayerPage.update subMsg m
                AdornerLayerPageModel m, [ AdornerLayerPageCmdMsgs c ]
            // | HomePageMsg subMsg, HomePageModel m ->
            //     let m, c = State.update subMsg m
            //     HomePageModel m, [ HomePageCmdMsgs c ]
            | _, currentPage -> currentPage, []

        { model with
            CurrentPage = subpageModel },
        cmdMsgs

    let view mapFn (model: SubpageModel) =
        let map viewFn subpageMsg model =
            let view = viewFn model
            View.AnyView(View.map (subpageMsg >> mapFn) view)

        match model with
        | AcrylicPageModel m -> map AcrylicPage.view AcrylicPageMsg m
        | AdornerLayerPageModel m -> map AdornerLayerPage.view AdornerLayerPageMsg m
    //| HomePageModel model -> map Pages.View.view HomePageMsg model

    let updateBackButtonPressed (model: NavigationModel) =
        match model.CurrentPage with
        | AcrylicPageModel _ -> update (AcrylicPageMsg AcrylicPage.Msg.Previous) model
        | AdornerLayerPageModel _ -> update (AdornerLayerPageMsg AdornerLayerPage.Msg.Previous) model
//| HomePageModel _ -> update (HomePageMsg Pages.Types.Msg.Previous) model
