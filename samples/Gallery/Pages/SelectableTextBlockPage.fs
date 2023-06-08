namespace Gallery.Pages

open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module SelectableTextBlockPage =
    type Model = { Text: string }

    type Msg = CopyingToClipboard of string

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Text = "" }, []

    let update msg model =
        match msg with
        | CopyingToClipboard s -> { model with Text = s }, []

    let view model =
        VStack(spacing = 15.) {

            TextBlock($"Copied to clipboard {model.Text}")

            SelectableTextBlock("Select some text. You can use the cursor to change the selection.", CopyingToClipboard)
                .selectionBrush(SolidColorBrush(Colors.LightBlue))
                .selectionStart(7)
                .selectionEnd(11)

            Border(
                SelectableTextBlock(CopyingToClipboard) {
                    Run("This ")

                    Span() { Run("is").fontWeight(FontWeight.Bold) }

                    Run(" a ")

                    Span() {
                        Run("TextBlock")
                            .background(SolidColorBrush(Colors.Silver))
                            .foreground(SolidColorBrush(Colors.Maroon))
                    }

                    Run(" with ")

                    Span() {
                        Run("several")
                            .textDecoration(TextDecoration(TextDecorationLocation.Underline))
                    }

                    Span() { Run("Span").fontStyle(FontStyle.Italic) }

                    Run(" elements, ")

                    Span() {
                        Run("using a ")
                        Bold("variety")
                        Run(" of ")
                        Italic("styles")
                    }
                }
            )
        }
