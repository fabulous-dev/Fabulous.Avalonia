namespace Gallery.Pages

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TextBoxPage =
    type Model =
        { SingleLineText: string
          MultiLineText: string }

    type Msg =
        | SingleLineTextChanged of string
        | MultiLineTextChanged of string

    let init () =
        { SingleLineText = ""
          MultiLineText = "" }

    let update msg model =
        match msg with
        | SingleLineTextChanged text -> { model with SingleLineText = text }
        | MultiLineTextChanged text -> { model with MultiLineText = text }

    let view model =
        VStack(spacing = 15) {
            TextBox(model.SingleLineText, SingleLineTextChanged)
                .textAlignment(TextAlignment.Center)
                .watermark("Enter some text...")
                .useFloatingWatermark(false)
                .caretBrush(SolidColorBrush(Colors.DarkBlue))
                .selectionBrush(SolidColorBrush(Colors.DarkBlue))
                .selectionForegroundBrush(SolidColorBrush(Colors.White))
                .width(300)
                .horizontalAlignment(HorizontalAlignment.Left)

            TextBlock($"You Entered: {model.SingleLineText}").margin(0, 0, 0, 30)

            TextBox(model.MultiLineText, MultiLineTextChanged)
                .height(120)
                .textAlignment(TextAlignment.Left)
                .verticalContentAlignment(VerticalAlignment.Top)
                .acceptsReturn(true)
                .acceptsTab(true)
                .maxLines(5)
                .watermark("Enter up to 5 lines of text...")
                .useFloatingWatermark(true)
                .caretBrush(SolidColorBrush(Colors.DarkBlue))
                .selectionBrush(SolidColorBrush(Colors.DarkBlue))
                .selectionForegroundBrush(SolidColorBrush(Colors.White))

            TextBlock($"You Entered: {model.MultiLineText}")
        }
