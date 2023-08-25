namespace Gallery.Root

open Fabulous.Avalonia
open Avalonia
open Types

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        SingleViewApplication(
            Panel() {
                (HamburgerMenu.mainView model)
                    .margin(Thickness(16., 24., 16., 16.))
            }
        )
            .styles(
                [ "avares://Gallery/Styles/DefaultTheme.xaml"
                  "avares://Gallery/Styles/TextStyles.xaml" ]
            )
