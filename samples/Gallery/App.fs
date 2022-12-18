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
        { WidgetModel: WidgetPage.Model option
          IsPanOpen: bool
          SelectedIndex: int }

    type Msg =
        | WidgetPageMsg of WidgetPage.Msg
        | ItemSelected of int
        | OpenPanChanged of bool
        | OpenPan

    let init() =
        { WidgetModel = None
          IsPanOpen = false
          SelectedIndex = -1 },
        Cmd.none

    let update msg model =
        match msg with
        | WidgetPageMsg msg ->
            match model.WidgetModel with
            | None -> model, Cmd.none
            | Some widgetModel ->
                let m, c = WidgetPage.update msg widgetModel
                { model with WidgetModel = Some m }, (Cmd.map WidgetPageMsg c)
        | ItemSelected index ->
            if index = - 1 then
                model, Cmd.none
            else
                let model =
                    { model with
                        WidgetModel = Some(WidgetPage.init index)
                        SelectedIndex = index
                        IsPanOpen = true }

                model, Cmd.none

        | OpenPanChanged x -> { model with IsPanOpen = x }, Cmd.none

        | OpenPan -> { model with IsPanOpen = not model.IsPanOpen }, Cmd.none

    let hamburgerMenuIcon() =
        Path("M1,4 H18 V6 H1 V4 M1,9 H18 V11 H1 V7 M3,14 H18 V16 H1 V14")
            .fill(SolidColorBrush(Colors.Black))

    let buttonSpinnerHeader(model: Model) =
        (VStack(0.) {
            Image(Bitmap.create "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                .size(100., 100.)

            TextBlock("Fabulous Gallery").centerHorizontal()

            (ListBox ([ "Button"; "TextBlock" ]) (fun x -> ListBoxItem(TextBlock(x))))
                .selectionMode(SelectionMode.Multiple)
                .onSelectedIndexChanged(model.SelectedIndex, ItemSelected)
        })
            .margin(Thickness(0., 20., 0., 0.))

    let overviewPage() =
        VStack() { TextBlock("Overview").centerHorizontal() }

    let view model =
        Grid() {
            match model.WidgetModel with
            | None ->
                SplitView(buttonSpinnerHeader model, overviewPage())
                    .isPresented(model.IsPanOpen, OpenPanChanged)
                    .displayMode(SplitViewDisplayMode.Inline)
                    .panePlacement(SplitViewPanePlacement.Left)

            | Some widgetModel ->
                let content = View.map WidgetPageMsg (WidgetPage.view widgetModel)

                SplitView(buttonSpinnerHeader model, content.margin(16.))
                    .isPresented(model.IsPanOpen, OpenPanChanged)
                    .displayMode(SplitViewDisplayMode.Inline)
                    .panePlacement(SplitViewPanePlacement.Left)

            Button(hamburgerMenuIcon(), OpenPan)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment(HorizontalAlignment.Left)
        }

#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
