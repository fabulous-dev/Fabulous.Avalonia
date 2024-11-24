namespace Navigation

open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open type Fabulous.Context

/// This is the root of the app
module App =
    /// The Model needs only to store the current navigation stack
    // type Model = { Navigation: NavigationStack }

    // type Msg =
    //     | NavigationMsg of NavigationRoute
    //     | BackNavigationMsg
    //     | BackButtonPressed

    let notifyBackButtonPressed (appMessageDispatcher: IAppMessageDispatcher) =
        Cmd.ofEffect(fun _ -> appMessageDispatcher.Dispatch(AppMsg.BackButtonPressed))

    /// In the init function, we initialize the NavigationStack
    // let init () =
    //     { Navigation = NavigationStack.Init(NavigationRoute.PageA) }, Cmd.none

    // let update appMsgDispatcher msg model =
    //     match msg with
    //     | NavigationMsg route -> { Navigation = model.Navigation.Push(route) }, Cmd.none
    //     | BackNavigationMsg -> { Navigation = model.Navigation.Pop() }, Cmd.none
    //     | BackButtonPressed -> model, notifyBackButtonPressed appMsgDispatcher

    // let subscribe (nav: NavigationController) (_: Model) =
    //     let navRequestedSub dispatch =
    //         nav.NavigationRequested.Subscribe(fun route -> dispatch(NavigationMsg route))
    //
    //     let backNavRequestedSub dispatch =
    //         nav.BackNavigationRequested.Subscribe(fun () -> dispatch BackNavigationMsg)
    //
    //     [ [ nameof navRequestedSub ], navRequestedSub
    //       [ nameof backNavRequestedSub ], backNavRequestedSub ]
    //
    // let program nav appMsgDispatcher =
    //     Program.statefulWithCmd init (update appMsgDispatcher)
    //     |> Program.withSubscription(subscribe nav)

    let navView nav appMsgDispatcher (path: NavigationRoute) =
        match path with
        | NavigationRoute.PageA -> AnyView(PageA.view nav appMsgDispatcher)
        | NavigationRoute.PageB initialCount -> AnyView(PageB.view nav appMsgDispatcher initialCount)
        | NavigationRoute.PageC(someArgs, stepCount) -> AnyView(PageC.view nav appMsgDispatcher (someArgs, stepCount))

    let content () =
        let nav = NavigationController()
        let appMsgDispatcher = AppMessageDispatcher()

        Component("App") {
            // let! model = Context.Mvu(program nav appMsgDispatcher)
            let! navigation = State(NavigationStack.Init(NavigationRoute.PageA))

            VStack() {
                // The page currently displayed is the one on top of the stack
                navView nav appMsgDispatcher navigation.Current.CurrentPage
            }
        }

    let view () =

#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
