namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module SelectableTextBlock =
    type Model = { Text: string }

    type Msg = CopyingToClipboard of string

    let init () = { Text = "" }

    let update msg model =
        match msg with
        | CopyingToClipboard s -> { model with Text = s }

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

                    Span() { Run("several").textDecorations() { TextDecoration(TextDecorationLocation.Underline) } }

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

    let sample =
        { Name = "SelectableTextBlock"
          Description = "A text block with selectable text"
          Program = Helper.createProgram init update view }
