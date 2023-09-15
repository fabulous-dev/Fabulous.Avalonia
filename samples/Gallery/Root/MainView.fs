namespace Gallery.Root

open Fabulous.Avalonia
open Avalonia
open Types
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        FabApplication.Current.AppTheme <- FluentTheme()

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
