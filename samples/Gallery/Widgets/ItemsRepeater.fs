namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ItemsRepeater =

    type DataType =
        { Name: string
          Desc: string
          Image: string }

    type Model = { SampleData: DataType list }

    type Msg = Id

    let init () =
        { SampleData =
            [ { Name = "Fabulous"
                Desc = "Fabulous is a library to write cross-platform mobile and desktop applications with F# and Avalonia."
                Image = "fabulous-icon" }
              { Name = "F#"
                Desc = "F# is a cross-platform, open source, functional-first programming language."
                Image = "fsharp-icon" }
              { Name = "GitHib"
                Desc = "GitHub is a web-based hosting service for version control using Git."
                Image = "github-icon" } ] }

    let update msg model =
        match msg with
        | Id -> model

    let view model =
        ItemsRepeater(
            model.SampleData,
            (fun x ->
                VStack(8.) {
                    HStack(16.) {
                        Image(ImageSource.fromString($"avares://Gallery/Assets/Icons/{x.Image}.png"))
                            .size(32., 32.)

                        TextBlock(x.Name)
                    }

                    TextBlock(x.Desc)
                })

        )
            .margin(16.)
            .centerHorizontal()
            .centerVertical()

    let sample =
        { Name = "ItemsRepeater"
          Description = "The ItemsRepeater control using a collection with a WidgetDataTemplate"
          Program = Helper.createProgram init update view }
