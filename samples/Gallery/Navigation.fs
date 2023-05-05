namespace Gallery

open Gallery

[<RequireQualifiedAccess>]
type NavigationRoute =
    | HomePage
    | AcrylicPage
    | AdornerLayerPage

type NavigationController() =
    let navigationRequested = Event<NavigationRoute>()
    let backNavigationRequested = Event<unit>()

    member this.NavigationRequested = navigationRequested.Publish
    member this.BackNavigationRequested = backNavigationRequested.Publish

    member this.RequestNavigation(route: NavigationRoute) = navigationRequested.Trigger route
    member this.RequestBackNavigation() = backNavigationRequested.Trigger()

module Navigation =
    let internal navigateTo (nav: NavigationController) route =
        Cmd.perform(fun () -> nav.RequestNavigation(route))

    let goBack(nav: NavigationController) =
        Cmd.perform(fun () -> nav.RequestBackNavigation())

    let goToOnboarding nav =
        navigateTo nav NavigationRoute.AcrylicPage

    let goToHome nav = navigateTo nav NavigationRoute.AdornerLayerPage