namespace Gallery



open type Fabulous.Avalonia.View

type Category =
    { Name: string
      Description: string
      Samples: Sample list }

module Registry =
    let samples =
        [ Button.sample; TextBlock.sample ]

    let getForIndex (index: int) =
         samples.[index]
