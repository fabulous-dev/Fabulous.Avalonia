namespace Gallery.Pages

open Avalonia.Controls
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Gallery

module TabControlPage =
    type Model =
        { TabPlacement: Dock
          Placements: string list
          SelectedIndex: int }

    type Msg = SelectedIndexChanged of int

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NoMsg -> Navigation.goBack nav

    let init () =
        { TabPlacement = Dock.Top
          Placements = [ "Top"; "Bottom"; "Left"; "Right" ]
          SelectedIndex = 0 }

    let update msg model =
        match msg with
        | SelectedIndexChanged index ->
            let dock = model.Placements.[index]

            let dock =
                match dock with
                | "Top" -> Dock.Top
                | "Bottom" -> Dock.Bottom
                | "Left" -> Dock.Left
                | "Right" -> Dock.Right
                | _ -> Dock.Top

            { model with
                SelectedIndex = index
                TabPlacement = dock }

    let view model =
        Dock() {
            TextBlock("A tab control that displays a tab strip along with the content of the selected tab")
                .dock(Dock.Top)
                .margin(4.)

            Grid(coldefs = [ Star ], rowdefs = [ Star; Pixel(100.) ]) {
                (Dock() {
                    TextBlock("From Inline TabItems").dock(Dock.Top)

                    (TabControl(model.TabPlacement) {
                        TabItem(
                            "Arch",
                            VStack() {
                                TextBlock("This is the first page in the TabControl.")

                                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/delicate-arch.jpg")
                                    .width(300.)
                            }
                        )

                        TabItem(
                            TextBlock("Leaf"),
                            VStack() {
                                TextBlock("This is the second page in the TabControl.")

                                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/maple-leaf.jpg")
                                    .width(300.)
                            }
                        )

                        TabItem(TextBlock("Disabled"), TextBlock(">You should not see this."))
                            .isEnabled(false)
                    })
                        .margin(0., 16.)
                })
                    .margin(4.)

                (HStack(8.) {
                    TextBlock("Tab Placement:").centerVertical()

                    ComboBox(model.Placements, (fun x -> TextBlock(x)))
                        .onSelectedIndexChanged(model.SelectedIndex, SelectedIndexChanged)

                })
                    .gridRow(1)
                    .centerVertical()
                    .centerHorizontal()

            }
        }
