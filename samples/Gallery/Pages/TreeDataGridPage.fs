namespace Gallery

open Fabulous.Avalonia

open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View

module TreeDataGridPage =
    let view () =
        TabControl() {
            TabItem("Countries", CountriesPage.view())
            TabItem("Files", FilesPage.view())
        }
