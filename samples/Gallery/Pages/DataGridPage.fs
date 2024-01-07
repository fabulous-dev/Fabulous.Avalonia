namespace Gallery

open System.Collections.ObjectModel
open Avalonia.Controls
open Avalonia.Data
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module DataGridPage =
    type Person(name, age, male) =
        member val Name = name with get, set
        member val Age = age with get, set
        member val IsMale = male with get, set

    type Model =
        { People: ObservableCollection<Person> }

    type Msg = | DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { People = ObservableCollection [ Person("John", 20, true); Person("Jane", 21, false); Person("Bob", 22, true) ] }, []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view model =
        VStack() {
            DataGrid(model.People)
                .gridLinesVisibility(DataGridGridLinesVisibility.Horizontal ||| DataGridGridLinesVisibility.Vertical)
                .horizontalGridLinesBrush(Colors.Yellow)
                .rowBackground(Colors.LightBlue)
                .verticalGridLinesBrush(Colors.Red)

            (CustomDataGrid(model.People) {
                DataGridTextColumn("Name", Binding("Name"))
                    .foreground(Colors.Green)

                DataGridTextColumn(TextBlock("Age"), Binding("Age"))

                DataGridCheckBoxColumn("IsMale", Binding("IsMale"))
                    .isThreeState(true)
            })
                .gridLinesVisibility(DataGridGridLinesVisibility.Horizontal)
                .borderThickness(1.0)
                .borderBrush(SolidColorBrush(Colors.Gray))
        }
