namespace Gallery

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module WidgetPage =
    type Model =
        { Sample: Sample
          SampleModel: obj}

    type Msg =
        | SampleMsg of obj

    let samples = [ Button.sample; TextBlock.sample ]

    let getForIndex(index: int) = samples.[index]

    let init index =
        let sample = getForIndex index

        { Sample = sample
          SampleModel = sample.Program.init()
           }

    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with SampleModel = sampleModel }, Cmd.none

    let view model =
        VStack(spacing = 20.) {
            TextBlock(model.Sample.Name).centerHorizontal()
            TextBlock(model.Sample.Description)
            Separator().background(SolidColorBrush(Colors.Gray))
            View.map SampleMsg (model.Sample.Program.view model.SampleModel)
        }
