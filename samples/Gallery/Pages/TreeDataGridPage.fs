namespace Gallery

open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module TreeDataGridPage =

    type Model =
        { CountriesModel: CountriesPage.Model
          FilesModel: FilesPage.Model }

    type Msg =
        | CountriesPageMsg of CountriesPage.Msg
        | FilesPageMsg of FilesPage.Msg

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        let countriesModel, _ = CountriesPage.init()
        let filesModel, _ = FilesPage.init()

        { CountriesModel = countriesModel
          FilesModel = filesModel },
        []

    let update msg model =
        match msg with
        | CountriesPageMsg msg ->
            let countriesModel, _ = CountriesPage.update msg model.CountriesModel

            { model with
                CountriesModel = countriesModel },
            []

        | FilesPageMsg msg ->
            let filesModel, _ = FilesPage.update msg model.FilesModel

            { model with FilesModel = filesModel }, []

    let view model =
        TabControl() {
            TabItem("Countries", View.map CountriesPageMsg (CountriesPage.view model.CountriesModel))
            TabItem("Files", View.map FilesPageMsg (FilesPage.view model.FilesModel))
        }
