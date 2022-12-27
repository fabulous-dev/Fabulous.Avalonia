namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module GridSplitter =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack(16.) {
            (Grid(coldefs = [ Star; Pixel(4); Star ], rowdefs = [ Star ]) {
                Rectangle(0., 0.)
                    .height(200.)
                    .fill(SolidColorBrush(Colors.Blue))
                    .gridRow(0)
                    .gridColumn (0)

                GridSplitter(GridResizeDirection.Columns)
                    .background(SolidColorBrush(Colors.White))
                    .gridRow(0)
                    .gridColumn (1)

                Rectangle(0., 0.)
                    .height(200.)
                    .fill(SolidColorBrush(Colors.Red))
                    .gridRow(0)
                    .gridColumn (2)
            })
                .height (200.)

            (Grid(coldefs = [ Star ], rowdefs = [ Star; Pixel(4); Star ]) {
                Rectangle(0., 0.).fill(SolidColorBrush(Colors.Blue)).gridRow(0).gridColumn (0)

                GridSplitter(GridResizeDirection.Rows)
                    .background(SolidColorBrush(Colors.White))
                    .gridRow(1)
                    .gridColumn (0)

                Rectangle(0., 0.).fill(SolidColorBrush(Colors.Red)).gridRow(2).gridColumn (0)
            })
                .height (200.)
        }



    let sample =
        { Name = "GridSplitter"
          Description =
            "The GridSplitter control is a control that allows a user to resize the space between Grid rows or columns."
          Program = Helper.createProgram init update view }
