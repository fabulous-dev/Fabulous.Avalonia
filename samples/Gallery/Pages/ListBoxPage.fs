namespace Gallery.Pages

open System
open System.Collections.ObjectModel
open Avalonia.Controls
open Avalonia.Controls.Selection
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ListBoxPage =
    type ItemModel =
        { ID: int }

        override x.ToString() = $"Item {x.ID}"

    type Model =
        { Multiple: bool
          Toggle: bool
          AlwaysSelected: bool
          AutoScrollToSelectedItem: bool
          WrappedSelection: bool
          Items: ObservableCollection<ItemModel>
          Selection: SelectionModel<ItemModel>
          SelectedIndex: int
          SelectionMode: SelectionMode }

    type Msg =
        | MultipleChanged of bool
        | ToggleChanged of bool
        | AlwaysSelectedChanged of bool
        | AutoScrollToSelectedItemChanged of bool
        | WrappedSelectionChanged of bool
        | AddItem
        | RemoveItem
        | SelectRandomItem

    type CmdMsg = | NoCmdMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoCmdMsg -> Cmd.none

    let init () =
        { Multiple = false
          Toggle = false
          AlwaysSelected = false
          Items = ObservableCollection([ 0..10 ] |> List.map(fun x -> { ID = x + 1 }))
          AutoScrollToSelectedItem = true
          WrappedSelection = false
          Selection = SelectionModel<ItemModel>()
          SelectedIndex = 0
          SelectionMode = SelectionMode.Single },
        []

    let update (msg: Msg) model =
        match msg with
        | MultipleChanged m ->
            let value =
                if m then SelectionMode.Multiple
                elif model.Toggle then SelectionMode.Toggle
                elif model.AlwaysSelected then SelectionMode.AlwaysSelected
                else SelectionMode.Single

            { model with
                SelectionMode = value
                Multiple = m },
            []
        | ToggleChanged b ->
            let value =
                if b then SelectionMode.Multiple
                elif model.Toggle then SelectionMode.Toggle
                elif model.AlwaysSelected then SelectionMode.AlwaysSelected
                else SelectionMode.Single

            { model with
                SelectionMode = value
                Toggle = b },
            []
        | AlwaysSelectedChanged b ->
            let value =
                if b then SelectionMode.Multiple
                elif model.Toggle then SelectionMode.Toggle
                elif model.AlwaysSelected then SelectionMode.AlwaysSelected
                else SelectionMode.Single

            { model with
                SelectionMode = value
                AlwaysSelected = b },
            []
        | AutoScrollToSelectedItemChanged b ->
            { model with
                AutoScrollToSelectedItem = b },
            []
        | WrappedSelectionChanged b -> { model with WrappedSelection = b }, []
        | AddItem ->
            model.Items.Add({ ID = model.Items.Count + 1 })
            { model with Items = model.Items }, []

        | RemoveItem ->
            let items = model.Selection.SelectedItems

            for item in items do
                model.Items.Remove(item) |> ignore

            { model with Items = model.Items }, []

        | SelectRandomItem ->
            let random = Random()
            let index = random.Next(0, model.Items.Count - 1)
            { model with SelectedIndex = index }, []


    let view model =
        (Dock() {
            (VStack() {
                TextBlock("Hosts a collection of ListBoxItem.")
                TextBlock("Each 5th item is highlighted with nth-child(5n+3) and nth-last-child(5n+4) rules.")
            })
                .margin(4.0)
                .dock(Dock.Top)

            (VStack() {
                CheckBox("Multiple", model.Multiple, MultipleChanged)
                CheckBox("Toggle", model.Toggle, ToggleChanged)
                CheckBox("AlwaysSelected", model.AlwaysSelected, AlwaysSelectedChanged)
                CheckBox("AutoScrollToSelectedItem", model.AutoScrollToSelectedItem, AutoScrollToSelectedItemChanged)
                CheckBox("WrappedSelection", model.WrappedSelection, WrappedSelectionChanged)
            })
                .margin(4.)
                .dock(Dock.Right)

            (HStack() {
                Button("Add", AddItem)
                Button("Remove", RemoveItem)
                Button("Select Random Item", SelectRandomItem)
            })
                .margin(4.)
                .dock(Dock.Bottom)

            ListBox(model.Items, (fun x -> TextBlock($"{x}")))
                .selectionModel(model.Selection)
                .selectionMode(model.SelectionMode)
                .wrapSelection(model.WrappedSelection)
                .selectedIndex(model.SelectedIndex)

        })
            .margin(16.0)
