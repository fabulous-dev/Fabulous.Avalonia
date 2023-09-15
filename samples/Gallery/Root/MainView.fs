namespace Gallery.Root

open System
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open Avalonia
open Types
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        //FabApplication.Current.AppTheme <- FluentTheme()
        let theme = StyleInclude(baseUri = null)
        theme.Source <- Uri("avares://Gallery/Styles/DefaultTheme.xaml")
        let textStyles = StyleInclude(baseUri = null)
        textStyles.Source <- Uri("avares://Gallery/Styles/TextStyles.xaml")
        FabApplication.Current.Styles.AddRange([ theme; textStyles ])

        SingleViewApplication(
            Panel() {
                (HamburgerMenu.mainView model)
                    .margin(Thickness(16., 24., 16., 16.))
            }
        )
