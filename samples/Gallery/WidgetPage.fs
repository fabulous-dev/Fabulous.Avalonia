namespace Gallery

open System
open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module WidgetPage =
    // let openBrowserCmd url =
    //     async {
    //         do!
    //             Browser.OpenAsync(Uri url, BrowserLaunchMode.SystemPreferred)
    //             |> Async.AwaitTask
    //     }
    //     |> Async.executeOnMainThread
    //     |> Cmd.performAsync

    type Model =
        { Sample: Sample
          SampleModel: obj
          SelectedSampleView: WidgetType }

    type Msg =
        | SampleMsg of obj
        | SampleViewChanged of WidgetType
        | OpenBrowser of string

    let init index =
        let sample = Registry.getForIndex index

        { Sample = sample
          SampleModel = sample.Program.init ()
          SelectedSampleView = WidgetType.Run }

    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with SampleModel = sampleModel }, Cmd.none

        | SampleViewChanged value -> { model with SelectedSampleView = value }, Cmd.none

        | OpenBrowser url -> model, Cmd.none

    let sampleViews =
        [ { Value = WidgetType.Run
            Text = "M8,5.14V19.14L19,12.14L8,5.14Z" }
          { Value = Code
            Text = "M8,5.14V19.14L19,12.14L8,5.14Z" } ]

    let view model =

        (VStack(spacing = 20.) {
            HStack() {
                TextBlock(model.Sample.Name)
                //.font(NamedSize.Title)
                //.padding(top = 20.)

                WidgetSelector(sampleViews, model.SelectedSampleView, SampleViewChanged)
            //.alignEndHorizontal(expand = true)
            //.alignEndVertical()
            }

            TextBlock(model.Sample.Description)

            VStack(spacing = 5.) {
                TextBlock("Source")
                //.font(NamedSize.Micro)
                //.textTransform(TextTransform.Uppercase)
                //.textColor(FabColor.fromHex "#A4A4A4")

                TextBlock(model.Sample.SourceFilename)
            //.font(NamedSize.Small)
            //.gestureRecognizers() {
            // TapGestureRecognizer(OpenBrowser model.Sample.SourceLink)
            // }
            }

            VStack(spacing = 5.) {
                TextBlock("Documentation")
                //.font(NamedSize.Micro)
                //.textTransform(TextTransform.Uppercase)
                //.textColor(FabColor.fromHex "#A4A4A4")

                TextBlock(model.Sample.DocumentationName)
            //.font(NamedSize.Small)
            //.gestureRecognizers() {
            // TapGestureRecognizer(OpenBrowser model.Sample.DocumentationLink)
            //}
            }

            Separator().background (SolidColorBrush(Colors.Gray))
            // Rectangle(1., SolidColorBrush(Colors.Gray))
            //     .height(if Device.RuntimePlatform = Device.iOS then 1. else 2.)


            Grid() {
                (View.map SampleMsg (model.Sample.Program.view model.SampleModel))
                    .isVisible (model.SelectedSampleView = WidgetType.Run)

                ScrollViewer(
                    (View.map SampleMsg (model.Sample.SampleCodeFormatted()))
                        .margin (Thickness(0., 0., 0., 10.))
                )
                    //.orientation(ScrollOrientation.Horizontal)
                    .isVisible (
                        model.SelectedSampleView = Code
                    )
            }
        })
