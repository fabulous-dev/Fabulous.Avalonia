namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module GridPage =
    let view () =
        VStack(16.) {
            (Grid() { TextBlock("By default, a Grid contains one row and one column.") })
                .margin(16.)

            Separator()

            (Grid(coldefs = [ Pixel(100); Pixel(100) ], rowdefs = [ Pixel(100); Pixel(100) ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.LightBlue))
            })
                .showGridLines(true)
                .margin(16.)

            Separator()

            (Grid(coldefs = [ Auto; Pixel(100) ], rowdefs = [ Auto; Pixel(100) ]) {

                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .size(100., 100.)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.LightBlue))

            })
                .margin(16.)

            Separator()

            Grid(coldefs = [ Auto; Star ], rowdefs = [ Auto; Star ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.LightBlue))

            }

            Grid(coldefs = [ Auto; Stars(10); Stars(20) ], rowdefs = [ Auto; Star ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[0,2]")
                    .gridRow(0)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Cyan))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.White))

                TextBlock("Cell[1,2]")
                    .gridRow(1)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Yellow))

            }

            Grid(coldefs = [ Auto; Star; Stars(4); Stars(2); Stars(3) ], rowdefs = [ Auto; Star ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[0,2]")
                    .gridRow(0)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Cyan))

                TextBlock("Cell[0,3]")
                    .gridRow(0)
                    .gridColumn(3)
                    .background(SolidColorBrush(Colors.Magenta))

                TextBlock("Cell[0,4]")
                    .gridRow(0)
                    .gridColumn(4)
                    .background(SolidColorBrush(Colors.LightBlue))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.White))

                TextBlock("Cell[1,2]")
                    .gridRow(1)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Yellow))

                TextBlock("Cell[1,3]")
                    .gridRow(1)
                    .gridColumn(3)
                    .background(SolidColorBrush(Colors.LightGray))

                TextBlock("Cell[1,4]")
                    .gridRow(1)
                    .gridColumn(4)
                    .background(SolidColorBrush(Colors.Coral))

            }
        }
