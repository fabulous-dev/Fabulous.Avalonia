namespace Gallery

open System.Diagnostics
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module MaskedTextBoxPage =
    type Model = { Text: string }

    type Msg = TextChanged of string

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Text = "" }, []

    let update msg model =
        match msg with
        | TextChanged text -> { Text = text }, []

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

            VStack(spacing = 15) {

                TextBlock("Enter a ten-digit number:")

                MaskedTextBox(model.Text, "(000) 000-0000", TextChanged)

                TextBlock($"You Entered: {model.Text}")
            }
        }
