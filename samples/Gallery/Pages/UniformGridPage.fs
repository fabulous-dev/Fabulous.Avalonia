namespace Gallery

open System.Diagnostics
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module UniformGridPage =
    type Model = { Nothing: bool }

    type Msg = DoNothing

    let init () = { Nothing = true }, Cmd.none

    let update msg model =
        match msg with
        | DoNothing -> model, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("UniformGridPage") {
            let! model = Context.Mvu program

            VStack() {
                (UniformGrid(rows = 1) {
                    Button("No", DoNothing)
                        .gridColumn(0)
                        .fontSize(18)
                        .margin(5)
                        .padding(6, 3)

                        .horizontalAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Stretch)

                    Button("Yes, Absolutely", DoNothing)
                        .gridColumn(1)
                        .margin(5)
                        .padding(6, 3)
                        .horizontalAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Stretch)

                    Button("Maybe", DoNothing)
                        .gridColumn(2)
                        .margin(5)
                        .padding(6, 3)
                        .horizontalAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Stretch)
                })
                    .margin(10.)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Center)
                    .rowSpacing(10.)
                    .columnSpacing(10.)

                UniformGrid() {
                    Border(TextBlock("1"))
                        .background(SolidColorBrush(Colors.AliceBlue))
                        .gridColumnSpan(2)

                    Border(TextBlock("2"))
                        .background(SolidColorBrush(Colors.Cornsilk))

                    Border(TextBlock("3"))
                        .background(SolidColorBrush(Colors.DarkSalmon))

                    Border(TextBlock("4"))
                        .background(SolidColorBrush(Colors.Gainsboro))
                        .gridRowSpan(2)

                    Border(TextBlock("5"))
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("6"))
                        .background(SolidColorBrush(Colors.MediumAquamarine))

                    Border(TextBlock("7"))
                        .background(SolidColorBrush(Colors.MistyRose))
                }
            }
        }
