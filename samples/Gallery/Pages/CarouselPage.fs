namespace Gallery

open System
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module CarouselPage =

    type DataType =
        { Name: string
          Desc: string
          Image: string }

    type Model =
        { SampleData: DataType seq
          SelectedIndex: int }

    type Msg =
        | Next
        | Previous
        | SelectionChanged of SelectionChangedEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

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
                Image = "github-icon" } ]
          SelectedIndex = 1 },
        []

    let carouselController = new CarouselController()

    let update msg model =
        match msg with
        | Next ->
            carouselController.DoNext()
            model, []
        | Previous ->
            carouselController.DoPrevious()
            model, []

        | SelectionChanged args ->
            let control = args.Source :?> Carousel

            { model with
                SelectedIndex = control.SelectedIndex },
            []

    let view model =
        (Grid(coldefs = [ Auto; Star; Auto ], rowdefs = [ Auto ]) {
            Button(
                Previous,
                Path("M20,11V13H8L13.5,18.5L12.08,19.92L4.16,12L12.08,4.08L13.5,5.5L8,11H20Z")
                    .fill(SolidColorBrush(Colors.Black))
            )
                .gridColumn(0)
                .verticalAlignment(VerticalAlignment.Center)
                .padding(10., 20.)
                .margin(4.)

            Carousel(
                model.SampleData,
                (fun x ->
                    VStack() {
                        TextBlock(x.Name)
                            .fontSize(20.)
                            .textWrapping(TextWrapping.Wrap)
                            .textAlignment(TextAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)

                        TextBlock(x.Desc)
                            .fontSize(14.)
                            .textWrapping(TextWrapping.Wrap)
                            .textAlignment(TextAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)

                        Image(ImageSource.fromString($"avares://Gallery/Assets/Icons/{x.Image}.png"))

                    })
            )
                .transition(Rotate3DTransition(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal))
                .margin(16)
                .gridColumn(1)
                .controller(carouselController)
                .centerHorizontal()
                .centerVertical()
                .onSelectionChanged(SelectionChanged)

            Button(
                Next,
                Path("M4,11V13H16L10.5,18.5L11.92,19.92L19.84,12L11.92,4.08L10.5,5.5L16,11H4Z")
                    .fill(SolidColorBrush(Colors.Black))
            )
                .gridColumn(2)
                .verticalAlignment(VerticalAlignment.Center)
                .padding(10., 20.)
                .margin(4.)

        })
            .maxWidth(500.)
            .horizontalAlignment(HorizontalAlignment.Stretch)
