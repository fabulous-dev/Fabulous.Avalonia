namespace Gallery


open System.Collections.Generic

open type Fabulous.Avalonia.View

type Category =
    { Name: string
      Description: string
      Samples: Sample list }

module Registry =
    let samples =
        [ { Name = "Controls"
            Description = "Controls"
            Samples = [
                Button.sample
                TextBlock.sample
            ] } ]

    let getForIndex (index: int) =
        let mutable i = index
        let mutable found = Unchecked.defaultof<Sample>

        for category in samples do
            i <- i - 1

            for sample in category.Samples do
                found <- sample

        found
