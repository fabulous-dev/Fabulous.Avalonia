namespace Gallery.Root

open Fabulous.Avalonia
open Types

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        SingleViewApplication(
            (Grid() { ScrollViewer(NavigationState.view SubpageMsg model.Navigation.CurrentPage) })
                .onLoaded(OnLoaded)
        )
            .onColorValuesChanged(OnColorValuesChanged)
