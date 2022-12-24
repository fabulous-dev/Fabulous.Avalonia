namespace Gallery

open System
open Avalonia.Controls
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module AutoCompleteBox =
    type Model = { Items: string list }

    type Msg = Id

    let init () =
        { Items = [ "Item 1"; "Item 2"; "Item 3"; "Product 1"; "Product 2"; "Product 3" ] }

    let update msg model =
        match msg with
        | Id -> model

    let view model =
        VStack(spacing = 15.) {
            AutoCompleteBox("Select an item", model.Items)
                .minimumPrefixLength(3)
                .minimumPopulateDelay(TimeSpan.FromSeconds(0.5))
                .isTextCompletionEnabled(true)
                .isDropDownOpen(true)
                .filterMode(AutoCompleteFilterMode.Contains)
                .itemFilter(fun text item ->
                    let item = item :?> string
                    item.Contains(text))
                .textFilter(fun text item ->
                    let item = item
                    item.Contains(text))
                .selectedItem ("Item 2")
        }

    let sample =
        { Name = "AutoCompleteBox"
          Description =
            "Represents a control that provides a text box for user input and a drop-down that contains possible matches based on the input in the text box."
          Program = Helper.createProgram init update view }
