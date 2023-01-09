namespace Gallery

open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module App =

    type Model =
        { WidgetModel: WidgetPage.Model option
          OverviewModel: OverViewPage.Model
          Controls: string list
          IsPanOpen: bool
          SelectedIndex: int }

    type Msg =
        | WidgetPageMsg of WidgetPage.Msg
        | OverViewPageMsg of OverViewPage.Msg
        | ShowOverview
        | ItemSelected of int
        | OpenPanChanged of bool
        | OpenPan

    let init () =
        { WidgetModel = None
          IsPanOpen = true
          OverviewModel = OverViewPage.init()
          Controls = WidgetPage.getSamplesNames()
          SelectedIndex = -1 },
        Cmd.none

    let update msg model =
        match msg with
        | ShowOverview -> { model with WidgetModel = None }, Cmd.none
        | OverViewPageMsg msg ->
            let m, c = OverViewPage.update msg model.OverviewModel
            { model with OverviewModel = m }, (Cmd.map OverViewPageMsg c)
        | WidgetPageMsg msg ->
            match model.WidgetModel with
            | None -> model, Cmd.none
            | Some widgetModel ->
                let m, c = WidgetPage.update msg widgetModel
                { model with WidgetModel = Some m }, (Cmd.map WidgetPageMsg c)
        | ItemSelected index ->
            let model =
                { model with
                    WidgetModel = Some(WidgetPage.init index)
                    SelectedIndex = index
                    IsPanOpen = true }

            model, Cmd.none

        | OpenPanChanged x -> { model with IsPanOpen = x }, Cmd.none

        | OpenPan ->
            { model with
                IsPanOpen = not model.IsPanOpen },
            Cmd.none

    let hamburgerMenuIcon () =
        Path("M1,4 H18 V6 H1 V4 M1,9 H18 V11 H1 V7 M3,14 H18 V16 H1 V14")
            .fill(SolidColorBrush(Colors.Black))

    let buttonSpinnerHeader (model: Model) =
        ScrollViewer(
            (VStack(0.) {
                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .size(100., 100.)

                TextBlock("Fabulous Gallery").centerHorizontal()

                Button("Overview", ShowOverview)

                ListBox(model.Controls, (fun x -> TextBlock(x)))
                    .onSelectedIndexChanged(model.SelectedIndex, ItemSelected)
            })
                .margin(Thickness(0., 20., 0., 0.))
        )

    let view model =
        Grid() {
            match model.WidgetModel with
            | None ->
                let content = View.map OverViewPageMsg (OverViewPage.view model.OverviewModel)

                SplitView(buttonSpinnerHeader model, content)
                    .isPresented(model.IsPanOpen, OpenPanChanged)
                    .displayMode(SplitViewDisplayMode.Inline)
                    .panePlacement(SplitViewPanePlacement.Left)

            | Some widgetModel ->
                let content = View.map WidgetPageMsg (WidgetPage.view widgetModel)

                SplitView(buttonSpinnerHeader model, content.margin(16.))
                    .isPresented(model.IsPanOpen, OpenPanChanged)
                    .displayMode(SplitViewDisplayMode.Inline)
                    .panePlacement(SplitViewPanePlacement.Left)

            Button(OpenPan, hamburgerMenuIcon ())
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment(HorizontalAlignment.Left)
        }

#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program =
        Program.statefulWithCmd init update app
#if DEBUG
        |> Program.withLogger
            { ViewHelpers.defaultLogger() with
                MinLogLevel = LogLevel.Debug }
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
#endif
