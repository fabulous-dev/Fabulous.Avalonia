namespace Gallery

open System
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open Avalonia
open Types

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        //FabApplication.Current.AppTheme <- FluentTheme()
        let theme = StyleInclude(baseUri = null)
        theme.Source <- Uri("avares://Gallery/App.xaml")
        FabApplication.Current.Styles.Add(theme)

        SingleViewApplication(
            Panel() {
                (HamburgerMenu.mainView model)
                    .margin(Thickness(16., 24., 16., 16.))
            }
        )
