namespace Gallery.Root

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls
open Types

open type Fabulous.Avalonia.View

module MainWindow =
    let view (model: Model) =
        DesktopApplication(
            Window(
                Grid() {
                    TabControl(Dock.Left) {
                        for page in Seq.rev model.Navigation.BackStack do
                            let control = NavigationState.view SubpageMsg page
                            TabItem("Tab 1", control)

                        let control = NavigationState.view SubpageMsg model.Navigation.CurrentPage
                        TabItem("Tab 1", control)
                    }
                }
            )
                .background(SolidColorBrush(Colors.Transparent))
                .title("Fabulous Gallery")
        )
