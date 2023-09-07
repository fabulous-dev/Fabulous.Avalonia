namespace Gallery.Root

open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
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
        let model, cmdMsgs = NavigationState.initRoute NavigationRoute.AcrylicPage

        { Navigation = NavigationModel.Init(model)
          IsPanOpen = false
          ThemeVariants = [ ThemeVariant.Default; ThemeVariant.Dark; ThemeVariant.Light ]
          FlowDirections = [ FlowDirection.LeftToRight; FlowDirection.RightToLeft ]
          HeaderText = "AcrylicPage"
          TransparencyLevels =
            [ WindowTransparencyLevel.None
              WindowTransparencyLevel.AcrylicBlur
              WindowTransparencyLevel.Blur
              WindowTransparencyLevel.Mica
              WindowTransparencyLevel.Transparent ]
          TransparencyLevel = [ WindowTransparencyLevel.None ] },
        [ SubpageCmdMsgs cmdMsgs ]

    let update msg model =
        match msg with
        | SubpageMsg subpageMsg ->
            let nav, cmdMsgs = NavigationState.update subpageMsg model.Navigation
            { model with Navigation = nav }, [ SubpageCmdMsgs cmdMsgs ]

        | OpenPanChanged x -> { model with IsPanOpen = x }, []

        | OnSelectionChanged args ->
            let route =
                args.AddedItems
                |> Seq.cast<ListBoxItem>
                |> Seq.tryHead
                |> Option.map(fun x -> unbox<string>(x.Content))

            let routeText =
                match route with
                | Some x -> x
                | None -> failwithf "Could not find route"

            let route = NavigationRoute.GetRoute(routeText)
            let modelRoute, cmdMsgs = NavigationState.initRoute route

            { model with
                Navigation = NavigationModel.Init(modelRoute)
#if MOBILE
                IsPanOpen = not model.IsPanOpen
#endif
                HeaderText = routeText },
            [ SubpageCmdMsgs cmdMsgs ]

        | DoNothing -> model, []

        | Update date ->
            match model.Navigation.CurrentPage with
            | CanvasPageModel _ -> model, [ NewMsg(SubpageMsg(CanvasPageMsg(CanvasPage.Msg.Update(date)))) ]
            | _ -> model, []

        | Settings -> model, []

        | DecorationsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let content = args.SelectedItem :?> ComboBoxItem
            let decoration = SystemDecorations.Parse(content.Content.ToString())
            FabApplication.Current.MainWindow.SystemDecorations <- decoration
            model, []

        | ThemeVariantsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let content = model.ThemeVariants[args.SelectedIndex]
            FabApplication.Current.RequestedThemeVariant <- content
            model, []

        | FlowDirectionsOnSelectionChanged selectionChangedEventArgs ->
            let args = selectionChangedEventArgs.Source :?> ComboBox
            let content = model.FlowDirections[args.SelectedIndex]
            FabApplication.Current.TopLevel.FlowDirection <- content
            model, []

        | TransparencyLevelsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let _content = model.TransparencyLevels[args.SelectedIndex]
            model, []
