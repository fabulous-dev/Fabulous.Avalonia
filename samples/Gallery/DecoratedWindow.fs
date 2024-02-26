namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

open Avalonia.Layout
open Avalonia.Media
open Avalonia.Styling
open Fabulous
open type Fabulous.Avalonia.View

module DecoratedWindow =
    type Model =
        { CanResize: bool
          SystemDecorations: SystemDecorations }

    type Msg =
        | Minimize
        | Maximize
        | Close
        | CanResize of bool

    let init () =
        { CanResize = false
          SystemDecorations = SystemDecorations.None },
        Cmd.none

    let update msg model =
        match msg with
        | Minimize -> model, Cmd.none
        | Maximize -> model, Cmd.none
        | Close -> model, Cmd.none
        | CanResize b -> { model with CanResize = b }, Cmd.none

    let buttonStyle (this: WidgetBuilder<'msg, IFabButton>) = this.margin(Thickness(2))

    let nativeMenu () =
        NativeMenu() {
            NativeMenuItem("Decorated")
                .menu(
                    NativeMenu() {
                        NativeMenuItem("Open")

                        NativeMenuItem("Recent")
                            .menu(
                                NativeMenu() {
                                    NativeMenuItem("Item 1")
                                    NativeMenuItem("Item 2")
                                    NativeMenuItem("Item 3")
                                }
                            )

                        NativeMenuItem("Quit Avalonia")
                            .gesture(KeyGesture.Parse("CMD+Q"))
                    }
                )

            NativeMenuItem("Edit")
                .menu(
                    NativeMenu() {
                        NativeMenuItem("Copy")
                        NativeMenuItem("Paste")
                    }
                )
        }

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
        Component(program) {
            let! model = Mvu.State

            Window() {
                Grid(rowdefs = [ Pixel(5); Star; Pixel(5) ], coldefs = [ Pixel(5); Star; Pixel(5) ]) {
                    (Dock() {
                        Grid(coldefs = [ Auto; Star; Auto ], rowdefs = [ Star ]) {
                            TextBlock("Title")
                                .verticalAlignment(VerticalAlignment.Center)
                                .margin(Thickness(5, 0, 0, 0))

                            HStack() {
                                Button("_", Minimize).style(buttonStyle)
                                Button("[ ]", Maximize).style(buttonStyle)
                                Button("X", Close).style(buttonStyle)
                            }
                        }

                        Border(
                            VStack() {
                                TextBlock("Hello world!")

                                ComboBox() {
                                    ComboBoxItem("None")
                                    ComboBoxItem("BorderOnly")
                                    ComboBoxItem("Full")
                                }

                                CheckBox("CanResize", model.CanResize, CanResize)

                            }
                        )
                            .background(Brushes.White)
                            .margin(Thickness(5))
                    })
                        .gridColumn(1)
                        .gridRow(1)

                    EmptyBorder().background(Brushes.Red).name("TopLeft")

                    EmptyBorder()
                        .background(Brushes.Red)
                        .name("TopRight")
                        .gridColumn(2)

                    EmptyBorder()
                        .background(Brushes.Red)
                        .name("BottomLeft")
                        .gridRow(2)

                    EmptyBorder()
                        .background(Brushes.Red)
                        .name("BottomRight")
                        .gridRow(2)
                        .gridColumn(2)

                    EmptyBorder()
                        .background(Brushes.Blue)
                        .name("Top")
                        .gridColumn(1)

                    EmptyBorder()
                        .background(Brushes.Blue)
                        .name("Right")
                        .gridRow(1)
                        .gridColumn(2)

                    EmptyBorder()
                        .background(Brushes.Blue)
                        .name("Bottom")
                        .gridRow(2)
                        .gridColumn(1)

                    EmptyBorder()
                        .background(Brushes.Blue)
                        .name("Left")
                        .gridRow(1)

                }
                |> _.background(Brushes.LightBlue)
                |> _.dock(Dock.Top)
            }
            |> _.systemDecorations(model.SystemDecorations)
            |> _.canResize(model.CanResize)
            |> _.menu(nativeMenu())
        }
