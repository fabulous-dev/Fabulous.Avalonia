namespace Gallery

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module App =

    type Model =
        { SelectedWidget: WidgetPage.Model
          IsFlyoutPresented: bool }

    type Msg =
        | WidgetPageMsg of WidgetPage.Msg
        | ItemSelected of int
        | FlyoutToggled

    let init () =
        { SelectedWidget = WidgetPage.init (0)
          IsFlyoutPresented = false },
        Cmd.none

    let update msg model =
        match msg with
        | WidgetPageMsg msg ->
            let m, c = WidgetPage.update msg model.SelectedWidget
            { model with SelectedWidget = m }, (Cmd.map WidgetPageMsg c)

        | ItemSelected index ->
            { model with
                SelectedWidget = WidgetPage.init index
                IsFlyoutPresented = false },
            Cmd.none

        | FlyoutToggled -> { model with IsFlyoutPresented = not model.IsFlyoutPresented }, Cmd.none


    let hamburgerMenuIcon () =
        Path("M1,4 H18 V6 H1 V4 M1,9 H18 V11 H1 V7 M3,14 H18 V16 H1 V14")
            .fill (SolidColorBrush(Colors.Black))

    let buttonSpinnerHeader () =
        VStack(0.) {
            Button(hamburgerMenuIcon (), FlyoutToggled)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment (HorizontalAlignment.Left)

            Image(Bitmap.create "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                .size (100., 100.)

            TextBlock("Fabulous Gallery").centerHorizontal ()

        }

    let view model =
        SplitView(buttonSpinnerHeader (), View.map WidgetPageMsg (WidgetPage.view model.SelectedWidget))
            .isPaneOpen(model.IsFlyoutPresented)
            .panePlacement(SplitViewPanePlacement.Left)
            .displayMode (SplitViewDisplayMode.CompactOverlay)
    // (match model.SelectedWidget with
    //  | None -> SplitView(buttonSpinnerHeader (), VStack() { TextBlock("Choose a sample") })
    //  | Some widgetModel ->
    //      let widgetBuilder = View.map WidgetPageMsg (WidgetPage.view widgetModel)




#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
