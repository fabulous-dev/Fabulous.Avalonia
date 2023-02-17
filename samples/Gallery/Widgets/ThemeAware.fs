namespace Gallery

open Avalonia.Media
open Avalonia.Styling
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ThemeAware =
    type Model = { CurrentTheme: ThemeVariant }

    type Msg = SetTheme of ThemeVariant

    let init () =
        { CurrentTheme = Avalonia.Application.Current.RequestedThemeVariant }

    let update msg model =
        match msg with
        | SetTheme variant ->
            Avalonia.Application.Current.RequestedThemeVariant <- variant
            { model with CurrentTheme = variant }

    let view model =
        VStack(spacing = 15.) {
            TextBlock($"Current theme is: {model.CurrentTheme.ToString()}")
            TextBlock($"Actual theme is: {Avalonia.Application.Current.ActualThemeVariant.ToString()}")

            HStack() {
                Button("Set default theme", SetTheme ThemeVariant.Default)
                Button("Set light theme", SetTheme ThemeVariant.Light)
                Button("Set dark theme", SetTheme ThemeVariant.Dark)
            }

            TextBlock("I'm a text that is theme aware")
                .foreground(SolidColorBrush(ThemeAware.With(Colors.Red, Colors.Green)))
        }

    let sample =
        { Name = "ThemeAware"
          Description = "ThemeAware is a custom modifier that changes its appearance based on the current theme."
          Program = Helper.createProgram init update view }
