namespace Gallery

open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks
open Avalonia.Controls
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module AutoCompleteBox =
    type Model =
        { IsOpen: bool
          SelectedItem: string
          Text: string
          Items: string list }

    type Msg =
        | TextChanged of string
        | SelectionChanged of SelectionChangedEventArgs
        | OnPopulating of string
        | OnPopulated of System.Collections.IEnumerable
        | OnDropDownOpen of bool

    let init () =
        { IsOpen = false
          SelectedItem = "Item 2"
          Text = ""
          Items = [ "Item 1"; "Item 2"; "Item 3"; "Product 1"; "Product 2"; "Product 3" ] }

    let update msg model =
        match msg with
        | TextChanged s -> { model with Text = s }
        | SelectionChanged _ -> model
        | OnPopulating _ -> model
        | OnPopulated _ -> model
        | OnDropDownOpen isOpen -> { model with IsOpen = isOpen }

    let getItemsAsync (_: string) (token: CancellationToken) : Task<IEnumerable<obj>> =
        task {
            return
                [ "Async Item 1"
                  "Async Item 2"
                  "Async Item 3"
                  "Async Product 1"
                  "Async Product 2"
                  "Async Product 3" ]
        }

    let view model =
        VStack(spacing = 15.) {
            TextBlock().textInlines () {
                Bold("Text: ")
                Run(model.Text)
                LineBreak()
                Bold("Selected item: ")
                Run(model.SelectedItem)
                LineBreak()
                Bold("Is open: ")
                Run($"{model.IsOpen}")
                LineBreak()
                Bold("Items: ")
                Run(model.Items |> String.concat ", ")
            }

            AutoCompleteBox("Select an item", model.Items)
                .minimumPopulateDelay(TimeSpan.FromSeconds(0.5))
                .isTextCompletionEnabled(true)
                .isDropDownOpen(true)
                .filterMode(AutoCompleteFilterMode.Contains)
                .onTextChanged(TextChanged)
                .onSelectionChanged(SelectionChanged)
                .onPopulating(OnPopulating)
                .onPopulated(OnPopulated)
                .onDropDownOpened (model.IsOpen, OnDropDownOpen)

            AutoCompleteBox("Select an async item", getItemsAsync)
        }

    let sample =
        { Name = "AutoCompleteBox"
          Description =
            "Represents a control that provides a text box for user input and a drop-down that contains possible matches based on the input in the text box."
          Program = Helper.createProgram init update view }
