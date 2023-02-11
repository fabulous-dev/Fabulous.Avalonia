namespace Gallery

open Avalonia.Media
open Avalonia.Styling
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ThemeAware =
    type Model = { CurrentTheme : ThemeVariant }

    type Msg =
        | RequestedThemeVariantChanged of ThemeVariant
        | ChangeTheme

    let init () =
        { CurrentTheme = Avalonia.Application.Current.RequestedThemeVariant }

    let update msg model =
        match msg with
        | RequestedThemeVariantChanged theme ->
            { model with CurrentTheme = theme }
            
        | ChangeTheme ->
            { model with CurrentTheme = if model.CurrentTheme = ThemeVariant.Light then ThemeVariant.Dark else ThemeVariant.Light }

    let view model =
        (VStack(spacing = 15.) {
            Button("Change theme", ChangeTheme)
                .padding(10.)
            
            TextBlock("Im a text that is theme aware")
                .foreground(ThemeAware.With(SolidColorBrush(Colors.Red), SolidColorBrush(Colors.Blue)))
        }).actualThemeVariant(model.CurrentTheme)
          .onActualThemeVariantChanged(model.CurrentTheme,  RequestedThemeVariantChanged)

    let sample =
        { Name = "ThemeAware"
          Description = "ThemeAware is a custom modifier that changes its appearance based on the current theme."
          Program = Helper.createProgram init update view }
