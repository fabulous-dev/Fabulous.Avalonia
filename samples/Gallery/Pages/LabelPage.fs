namespace Gallery.Pages

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Gallery

module LabelPage =
    type Model =
        { FirstName: string
          LastName: string
          IsBanned: bool }

    type Msg =
        | FirstNameChanged of string
        | LastNameChanged of string
        | BannedChanged of bool
        | DoSave
        | DoCancel

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { FirstName = ""
          LastName = ""
          IsBanned = false },
        []

    let update msg model =
        match msg with
        | FirstNameChanged s -> { model with FirstName = s }, []
        | LastNameChanged s -> { model with LastName = s }, []
        | BannedChanged b -> { model with IsBanned = b }, []
        | DoSave -> model, []
        | DoCancel ->
            { model with
                FirstName = "John"
                LastName = "Doe"
                IsBanned = true },
            []

    let labelStyle (this: WidgetBuilder<'msg, IFabLabel>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .margin(6., 3., 0., 3.)

    let textBoxStyle (this: WidgetBuilder<'msg, IFabTextBox>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .margin(0., 3., 6., 3.)

    let checkBoxStyle (this: WidgetBuilder<'msg, IFabCheckBox>) =
        this
            .verticalAlignment(VerticalAlignment.Center)
            .margin(0., 3., 6., 3.)

    let firstNameEdit = ViewRef<TextBox>()

    let lastNameEdit = ViewRef<TextBox>()

    let bannedCheck = ViewRef<CheckBox>()

    let view model =
        ScrollViewer(
            (Grid(rowdefs = [ Auto; Auto; Auto; Auto; Auto; Star ], coldefs = [ Auto; Pixel(6.); Star ]) {
                Label("_FirstName")
                    .target(firstNameEdit)
                    .gridRow(0)
                    .gridColumn(0)
                    .style(labelStyle)

                TextBox(model.FirstName, FirstNameChanged)
                    .gridRow(0)
                    .gridColumn(2)
                    .name("firstNameEdit")
                    .style(textBoxStyle)
                    .reference(firstNameEdit)

                Label("_LastName")
                    .target(lastNameEdit)
                    .gridRow(1)
                    .gridColumn(0)
                    .style(labelStyle)

                TextBox(model.LastName, LastNameChanged)
                    .gridRow(1)
                    .gridColumn(2)
                    .name("lastNameEdit")
                    .style(textBoxStyle)
                    .reference(lastNameEdit)

                Label("_Banned")
                    .target(bannedCheck)
                    .gridRow(2)
                    .gridColumn(0)
                    .style(labelStyle)

                CheckBox(model.IsBanned, BannedChanged)
                    .gridRow(2)
                    .gridColumn(2)
                    .name("bannedCheck")
                    .style(checkBoxStyle)
                    .reference(bannedCheck)

                GridSplitter()
                    .gridRowSpan(3)
                    .gridColumn(1)
                    .verticalAlignment(VerticalAlignment.Stretch)
                    .horizontalAlignment(HorizontalAlignment.Stretch)

                (HStack() {
                    Button("Cancel", DoCancel).isCancel(true)

                    Button("Save", DoSave).isDefault(true)
                })
                    .gridRow(4)
                    .gridColumn(0)
                    .gridColumnSpan(3)
                    .horizontalAlignment(HorizontalAlignment.Right)
            })
                .width(246.)
        )
            .verticalScrollBarVisibility(ScrollBarVisibility.Auto)
            .horizontalScrollBarVisibility(ScrollBarVisibility.Hidden)
