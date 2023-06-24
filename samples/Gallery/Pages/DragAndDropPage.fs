namespace Gallery.Pages

open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Controls
open Fabulous
open Avalonia.Threading

open type Fabulous.Avalonia.View

module DragAndDropPage =
    let customFormat = "application/xxx-avalonia-controlcatalog-custom"

    type Model =
        { DropText: string
          DragText: string
          DragCount: int }

    type Msg =
        | OnPointPressed of PointerPressedEventArgs
        | Dragged of string
        | DraggedOver of DragEventArgs
        | Dropped of DragEventArgs

    let doDrag (e, dragCount) =
        async {
            let dragData = DataObject()
            dragData.Set(DataFormats.Text, $"Text was dragged %d{dragCount} times")

            let! result =
                Dispatcher.UIThread.InvokeAsync<DragDropEffects>(fun _ -> DragDrop.DoDragDrop(e, dragData, DragDropEffects.Copy))
                |> Async.AwaitTask

            let res =
                match result with
                | DragDropEffects.Copy -> "The text was copied"
                | DragDropEffects.Link -> "The text was linked"
                | DragDropEffects.None -> "The drag operation was canceled"
                | _ -> "That was unexpected"

            return Dragged res
        }

    type CmdMsg = DragBegin of e: PointerEventArgs * dragCount: int

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | DragBegin(pointerEventArgs, dragCount) -> Cmd.ofAsyncMsg(doDrag(pointerEventArgs, dragCount))

    let init () =
        { DropText = "Drop some text or files here"
          DragText = "Drag Me"
          DragCount = 0 },
        []

    let dragMeTextRef = ViewRef<Border>()
    let dragMeFilesRef = ViewRef<Border>()

    let dragMeCustomRef = ViewRef<Border>()

    let dragStateTextRef = ViewRef<TextBlock>()
    let dragStateFilesRef = ViewRef<TextBlock>()

    let dragStateCustomRef = ViewRef<TextBlock>()

    let update msg model =
        match msg with
        | OnPointPressed e ->
            e.Handled <- true
            let dragCount = model.DragCount + 1
            { model with DragCount = dragCount }, [ DragBegin(e, dragCount) ]
        | Dragged s -> { model with DragText = s }, []
        | Dropped s -> { model with DropText = "asdfasd" }, []
        | DraggedOver s -> { model with DropText = "asdfasd" }, []

    let view model =
        VStack(4.) {
            TextBlock("Example of Drag+Drop capabilities")

            (VWrap() {
                (VStack() {
                    Border(
                        TextBlock("Drag Me (text)")
                            .textWrapping(TextWrapping.Wrap)
                            .reference(dragStateTextRef)
                    )
                        .padding(16.)
                        .borderBrush(SolidColorBrush(Color.Parse("#aaa")))
                        .borderThickness(2.)
                        .onPointerPressed(OnPointPressed)
                        .reference(dragMeTextRef)

                    Border(
                        TextBlock("Drag Me (files)")
                            .textWrapping(TextWrapping.Wrap)
                            .reference(dragStateFilesRef)
                    )
                        .padding(16.)
                        .borderBrush(SolidColorBrush(Color.Parse("#aaa")))
                        .borderThickness(2.)
                        .reference(dragMeFilesRef)

                    Border(
                        TextBlock("Drag Me (custom)")
                            .textWrapping(TextWrapping.Wrap)
                            .reference(dragStateCustomRef)
                    )
                        .padding(16.)
                        .borderBrush(SolidColorBrush(Color.Parse("#aaa")))
                        .borderThickness(2.)
                        .reference(dragMeCustomRef)
                })
                    .horizontalAlignment(HorizontalAlignment.Center)

                (HStack(8.) {
                    Border(
                        TextBlock("Drop some text or files here (Copy)")
                            .textWrapping(TextWrapping.Wrap)
                            .allowDrop(true)
                    //.onDrop(Dropped)
                    )
                        .padding(16.)
                        .maxWidth(260.)
                        .background(SolidColorBrush(Color.Parse("#aaa")))

                    Border(
                        TextBlock("Drop some text or files here (Move)")
                            .textWrapping(TextWrapping.Wrap)
                    )
                        .padding(16.)
                        .maxWidth(260.)
                        .background(SolidColorBrush(Color.Parse("#aaa")))
                })
                    .horizontalAlignment(HorizontalAlignment.Center)
            })
                .margin(8.)
                .maxWidth(160.)

            TextBlock(model.DragText).textWrapping(TextWrapping.Wrap)

        }
