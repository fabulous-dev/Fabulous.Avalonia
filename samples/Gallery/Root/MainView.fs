namespace Gallery.Root

open Fabulous.Avalonia
open Types

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        SingleViewApplication(
            (Grid() { NavigationState.view SubpageMsg model.Navigation.CurrentPage })
                .margin(0., model.SafeAreaInsets, 0., 0.)
                .onLoaded(OnLoaded)
        )
