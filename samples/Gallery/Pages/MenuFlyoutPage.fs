namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Input
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module MenuFlyoutPage =
    type Model = { Counter: int }

    type Msg =
        | PressMe
        | Increment

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Counter = 0 }, []

    let update msg model =
        match msg with
        | PressMe -> model, []
        | Increment -> { Counter = model.Counter + 1 }, []

    let program =
        Program.statefulWithCmdMsg init update mapCmdMsgToCmd
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component(program) {
            let! model = Mvu.State

            VStack(spacing = 15.) {

                TextBlock($"{model.Counter}")

                Button("Open Flyout", PressMe)
                    .flyout(
                        (MenuFlyout() {
                            MenuItem("Item 1")
                                .icon(Image("avares://Gallery/Assets/Icons/fabulous-icon.png"))

                            MenuItems("Item 2", Increment) {
                                MenuItem("Subitem 1")
                                MenuItem("Subitem 2")
                                MenuItem("Subitem 3")
                                MenuItem("Subitem 4")
                                MenuItem("Subitem 5")
                            }

                            MenuItem("Item 4").inputGesture(KeyGesture.Parse("Ctrl+A"))
                            MenuItem("Item 5").inputGesture(KeyGesture.Parse("Ctrl+A"))
                            MenuItem(TextBlock("Item 6"), Increment)
                            MenuItem("Item 7")
                        })
                            .placement(PlacementMode.BottomEdgeAlignedRight)
                    )
            }
        }
