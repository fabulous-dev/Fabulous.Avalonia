namespace CounterApp

open Avalonia.Layout
open Avalonia.Media
open Avalonia.Themes.Fluent
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module MyApp =
    let view () =
        SingleViewApplication(
            UserControl(
                TextBlock("Hello from Fabulous.Avalonia")
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Center)
            )
                .background(SolidColorBrush(Color.Parse("#171C2C")))
                .foreground(SolidColorBrush(Color.Parse("#FFFFFF")))
        )
            .styles() {
                FluentTheme(FluentThemeMode.Light)
            }

    let program = Program.stateless view
