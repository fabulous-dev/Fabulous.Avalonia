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
        { SelectedWidget: WidgetPage.Model
          IsPanOpen: bool }

    type Msg =
        | WidgetPageMsg of WidgetPage.Msg
        | ItemSelected of int
        | OpenPan
        | PanOpened
        | PanClosed

    let init () =
        { SelectedWidget = WidgetPage.init(0)
          IsPanOpen = false },
        Cmd.none

    let update msg model =
        match msg with
        | WidgetPageMsg msg ->
            let m, c = WidgetPage.update msg model.SelectedWidget
            { model with SelectedWidget = m }, (Cmd.map WidgetPageMsg c)

        | ItemSelected index ->
            { model with
                SelectedWidget = WidgetPage.init index
                IsPanOpen = false },
            Cmd.none
            
        | PanOpened ->
            { model with IsPanOpen = true }, Cmd.none
        
        | PanClosed ->
            { model with IsPanOpen = false }, Cmd.none
            
        | OpenPan -> { model with IsPanOpen = not model.IsPanOpen }, Cmd.none
    let hamburgerMenuIcon () =
        Path("M1,4 H18 V6 H1 V4 M1,9 H18 V11 H1 V7 M3,14 H18 V16 H1 V14")
            .fill (SolidColorBrush(Colors.Black))

    let buttonSpinnerHeader model =
        (VStack(0.) {
            Image(Bitmap.create "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                .size (100., 100.)

            TextBlock("Fabulous Gallery").centerHorizontal ()
        })
            .margin(Thickness(0., 20., 0., 0.))
        

    let view model =
        Grid() {    
            let content = View.map WidgetPageMsg (WidgetPage.view model.SelectedWidget)
            SplitView(buttonSpinnerHeader model, content.margin(16.))
                .isPaneOpen(model.IsPanOpen)
                .panePlacement(SplitViewPanePlacement.Left)
                .onPanOpened(PanOpened)
                .onPanClosed(PanClosed)
                
            Button(hamburgerMenuIcon (), OpenPan)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment(HorizontalAlignment.Left)
        }



#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
