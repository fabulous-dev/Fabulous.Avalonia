namespace Gallery

open System
open Avalonia.Animation
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Carousel2 =

    type Model = Id

    type Msg =
        | Next
        | Previous

    let init () = Id

    let carouselController = new CarouselController()

    let update msg model =
        match msg with
        | Next ->
            carouselController.DoNext()
            model
        | Previous ->
            carouselController.DoPrevious()
            model

    let view _ =
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

            (Carousel() {
                VStack() {
                    TextBlock("Fabulous")
                        .fontSize(20.)
                        .textWrapping(TextWrapping.Wrap)
                        .textAlignment(TextAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center)

                    TextBlock("Fabulous is a library to write cross-platform mobile and desktop applications with F# and Avalonia.")
                        .fontSize(14.)
                        .textWrapping(TextWrapping.Wrap)
                        .textAlignment(TextAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center)

                    Image(ImageSource.fromString("avares://Gallery/Assets/Icons/fabulous-icon.png"))
                }

                VStack() {
                    TextBlock("F#")
                        .fontSize(20.)
                        .textWrapping(TextWrapping.Wrap)
                        .textAlignment(TextAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center)

                    TextBlock("F# is a cross-platform, open source, functional-first programming language.")
                        .fontSize(14.)
                        .textWrapping(TextWrapping.Wrap)
                        .textAlignment(TextAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center)

                    Image(ImageSource.fromString("avares://Gallery/Assets/Icons/fsharp-icon.png"))
                }

                VStack() {
                    TextBlock("GitHub")
                        .fontSize(20.)
                        .textWrapping(TextWrapping.Wrap)
                        .textAlignment(TextAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center)

                    TextBlock("GitHub is a web-based hosting service for version control using Git.")
                        .fontSize(14.)
                        .textWrapping(TextWrapping.Wrap)
                        .textAlignment(TextAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center)

                    Image(ImageSource.fromString("avares://Gallery/Assets/Icons/github-icon.png"))
                }
            })
                .transition(PageSlide(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal))
                .margin(16)
                .gridColumn(1)
                .controller(carouselController)
                .centerHorizontal()
                .centerVertical()

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

    let sample =
        { Name = "Carousel"
          Description = "The Carousel control using explicit controls"
          Program = Helper.createProgram init update view }
