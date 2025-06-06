namespace ComponentNavigation

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PageC =
    // type Model =
    //     { IsActive: bool
    //       Args: string
    //       StepCount: int
    //       Count: int }
    //
    // type Msg =
    //     | Active
    //     | Inactive
    //     | Increment
    //     | Decrement
    //     | GoBack
    //     | GoToPageA
    //     | GoToPageB
    //
    // let init (args, stepCount) =
    //     { IsActive = false
    //       Args = args
    //       StepCount = stepCount
    //       Count = 0 },
    //     Cmd.none
    //
    // let update (nav: NavigationController) msg model =
    //     match msg with
    //     | Active -> { model with IsActive = true }, Cmd.none
    //     | Inactive -> { model with IsActive = false }, Cmd.none
    //     | Increment ->
    //         { model with
    //             Count = model.Count + model.StepCount },
    //         Cmd.none
    //     | Decrement ->
    //         { model with
    //             Count = model.Count - model.StepCount },
    //         Cmd.none
    //     | GoBack -> model, Navigation.navigateBack nav
    //     | GoToPageA -> model, Navigation.navigateToPageA nav
    //     | GoToPageB -> model, Navigation.navigateToPageB nav model.Count
    //
    // let subscribe (appMsgDispatcher: IAppMessageDispatcher) model =
    //     let localAppMsgSub dispatch =
    //         appMsgDispatcher.Dispatched.Subscribe(fun msg ->
    //             match msg with
    //             | AppMsg.BackButtonPressed -> dispatch GoBack)
    //
    //     [ if model.IsActive then
    //           [ nameof localAppMsgSub ], localAppMsgSub ]
    //
    // let program nav appMsgDispatcher =
    //     Program.statefulWithCmd init (update nav)
    //     |> Program.withSubscription(subscribe appMsgDispatcher)

    let view nav appMsgDispatcher args =
        Component("Page C") {
            //let! model = Context.Mvu(program nav appMsgDispatcher)

            Grid(coldefs = [ Star ], rowdefs = [ Star; Auto ]) {
                VStack() {
                    Label("Page C")
                //Label($"Count: {model.Count}") //.centerTextHorizontal()

                // Button("Increment", Increment)
                // Button("Decrement", Decrement)
                }

                (VStack
                    ()
                    {
                    // Button("Go back", GoBack)
                    // Button("Go to Page B", GoToPageB)
                    // Button("Go to Page C", GoToPageC)
                    })
                    .gridRow(1)
            }

        // .title("Page A")
        // .onNavigatedTo(Active)
        // .onNavigatedFrom(Inactive)
        }
