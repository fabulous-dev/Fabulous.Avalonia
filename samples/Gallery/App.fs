namespace Gallery

open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module App =

    type Model =
        { SelectedWidgetModel: WidgetPage.Model option
          IsPanOpen: bool }

    type Msg =
        | WidgetPageMsg of WidgetPage.Msg
        | ItemSelected of int
        | OpenPanChanged of bool
        | OpenPan

    let init () =
        { SelectedWidgetModel = None
          IsPanOpen = false },
        Cmd.none

    let update msg model =
        match msg with
        | WidgetPageMsg msg ->
            let m, c = WidgetPage.update msg model.SelectedWidgetModel.Value
            { model with SelectedWidgetModel = Some m }, (Cmd.map WidgetPageMsg c)

        | ItemSelected index ->
            { model with
                SelectedWidgetModel = Some(WidgetPage.init index)
                IsPanOpen = true },
            Cmd.ofMsg (WidgetPageMsg(WidgetPage.Msg.SampleViewChanged(WidgetType.Run)))

        | OpenPanChanged x -> { model with IsPanOpen = x }, Cmd.none

        | OpenPan -> { model with IsPanOpen = not model.IsPanOpen }, Cmd.none

    let hamburgerMenuIcon () =
        Path("M1,4 H18 V6 H1 V4 M1,9 H18 V11 H1 V7 M3,14 H18 V16 H1 V14")
            .fill (SolidColorBrush(Colors.Black))

    let buttonSpinnerHeader _ =
        (VStack(0.) {
            Image(Bitmap.create "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                .size (100., 100.)

            TextBlock("Fabulous Gallery").centerHorizontal ()
            Button("Button", ItemSelected 0).centerHorizontal ()
            Button("TextBlock", ItemSelected 1).centerHorizontal ()
        })
            .margin (Thickness(0., 20., 0., 0.))

    let overviewPage () =
        VStack() { TextBlock("Overview").centerHorizontal () }

    let view model =
        Grid() {
            match model.SelectedWidgetModel with
            | Some widgetModel ->
                let content = View.map WidgetPageMsg (WidgetPage.view widgetModel)

                SplitView(buttonSpinnerHeader model, content.margin (16.))
                    .isPresented(model.IsPanOpen, OpenPanChanged)
                    .panePlacement (SplitViewPanePlacement.Left)
            | None ->
                SplitView(buttonSpinnerHeader model, overviewPage ())
                    .isPresented(model.IsPanOpen, OpenPanChanged)
                    .panePlacement (SplitViewPanePlacement.Left)

            Button(hamburgerMenuIcon (), OpenPan)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment (HorizontalAlignment.Left)
        }



#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
