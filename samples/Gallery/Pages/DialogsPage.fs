namespace Gallery.Pages

open System
open System.Collections.Generic
open Avalonia.Platform.Storage
open Fabulous.Avalonia
open Avalonia.Controls
open Fabulous

open type Fabulous.Avalonia.View

module DialogsPage =
    type Model =
        { UseFilters: bool
          OpenMultiple: bool
          CurrentFolderBox: string
          BookmarkContainer: string
          OpenedFileContent: string
          IgnoreTextChanged: bool
          LastSelectedDirectory: IStorageFolder
          FileResults: string array
          PickerLastResultsVisible: bool }

    type Msg =
        | DecoratedWindow
        | DecoratedWindowDialog
        | Dialog
        | DialogNoTaskbar
        | OwnedWindow
        | OwnedWindowNoTaskbar

        | UseFiltersChanged of bool
        | OpenMultipleChanged of bool

        | OpenMultiple
        | SelectFolder

        | OpenFile
        | FileOpened of IReadOnlyList<IStorageFolder>
        | SaveFile
        | OpenFileBookmark
        | OpenFolderBookmark
        | SelectBoth

        | CurrentFolderBoxTextChanged of string
        | BookmarkContainerTextChanged of string
        | OpenedFileContentTextChanged of string
        | CurrentFolderBoxLoaded of bool

        | GetIStorageFolder of IStorageFolder

    type CmdMsg =
        | GettingIStorageFolder of string
        | OpeningFile

    let getWindow () =
        (FabApplication.Current :?> FabApplication).MainWindow


    let getTopLevel () = TopLevel.GetTopLevel(getWindow())

    let getStorageProvider () : IStorageProvider = getTopLevel().StorageProvider

    let getStringFromStorageFile (text: string) =
        task {
            let mutable folderEnum: WellKnownFolder = Unchecked.defaultof<WellKnownFolder>

            if Enum.TryParse<WellKnownFolder>(text, true, &folderEnum) then
                let! lastSelectedDirectory = getStorageProvider().TryGetWellKnownFolderAsync(folderEnum)
                return GetIStorageFolder lastSelectedDirectory
            else
                let mutable folderLink: Uri = null

                if not(Uri.TryCreate(text, UriKind.Absolute, &folderLink)) then
                    Uri.TryCreate("file://" + text, UriKind.Absolute, &folderLink) |> ignore

                if folderLink <> null then
                    let! lastSelectedDirectory = getStorageProvider().TryGetFolderFromPathAsync(folderLink)
                    return GetIStorageFolder lastSelectedDirectory
                else
                    return GetIStorageFolder null
        }

    let getFilters isChecked =
        let fileDialogFilter1 = new FileDialogFilter()
        fileDialogFilter1.Name <- "Text files (.txt)"

        let fileDialogFilter2 = new FileDialogFilter()
        fileDialogFilter2.Name <- "All files"
        fileDialogFilter2.Extensions <- List<string>([ ".*" ])

        if isChecked then
            List<FileDialogFilter>([])
        else
            List<FileDialogFilter>([ fileDialogFilter1; fileDialogFilter2 ])

    let getFileTypes isChecked =
        if not isChecked then
            List.empty
        else
            let item = FilePickerFileType("Binary Log")
            item.Patterns <- [ "*.binlog"; "*.buildlog" ]
            item.MimeTypes <- [ "application/binlog"; "application/buildlog" ]
            item.AppleUniformTypeIdentifiers <- [ "public.data" ]
            [ FilePickerFileTypes.All; FilePickerFileTypes.TextPlain; item ]

    let openFile () =
        task {
            let openOptions = FolderPickerOpenOptions()
            openOptions.Title <- "Open file"
            openOptions.AllowMultiple <- false

            let! path =
                getStorageProvider()
                    .TryGetFolderFromPathAsync(Uri("/Users/edgardev/Projects/Fabulous.Avalonia"))

            openOptions.SuggestedStartLocation <- path
            let! res = getStorageProvider().OpenFolderPickerAsync(openOptions)
            return FileOpened res
        }


    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | GettingIStorageFolder text -> Cmd.ofTaskMsg(getStringFromStorageFile text)
        | OpeningFile -> Cmd.ofTaskMsg(openFile())

    let init () =
        { UseFilters = false
          OpenMultiple = false
          CurrentFolderBox = ""
          BookmarkContainer = ""
          OpenedFileContent = ""
          IgnoreTextChanged = false
          LastSelectedDirectory = null
          FileResults = Array.empty
          PickerLastResultsVisible = false },
        []

    let update msg model =
        match msg with
        | DecoratedWindow -> model, []
        | DecoratedWindowDialog -> model, []
        | Dialog -> model, []
        | DialogNoTaskbar -> model, []
        | OwnedWindow -> model, []
        | OwnedWindowNoTaskbar -> model, []
        | UseFiltersChanged b -> { model with UseFilters = b }, []
        | OpenMultipleChanged b -> { model with OpenMultiple = b }, []

        | SelectFolder -> model, []
        | OpenFile -> model, [ OpeningFile ]
        | SaveFile -> model, []
        | OpenFileBookmark -> model, []
        | OpenFolderBookmark -> model, []
        | OpenMultiple -> model, []
        | SelectBoth -> model, []
        | CurrentFolderBoxTextChanged text ->
            if model.IgnoreTextChanged then
                { model with CurrentFolderBox = text }, []
            else
                { model with CurrentFolderBox = text }, [ GettingIStorageFolder text ]
        | CurrentFolderBoxLoaded b -> model, []
        | BookmarkContainerTextChanged s -> { model with BookmarkContainer = s }, []
        | OpenedFileContentTextChanged s -> { model with OpenedFileContent = s }, []
        | GetIStorageFolder storageFolder ->
            { model with
                LastSelectedDirectory = storageFolder },
            []
        | FileOpened results ->
            let results = results |> Seq.map(fun f -> f.Name) |> Seq.toArray

            { model with
                FileResults = results
                PickerLastResultsVisible = not(results |> Array.isEmpty) },
            []

    let view model =
        (VStack(4.) {
            TextBlock("Windows:")

            Expander(
                "Window dialogs",
                VStack(4.) {
                    Button("Decorated window", DecoratedWindow)
                    Button("Decorated window (dialog)", DecoratedWindowDialog)
                    Button("Shows a dialog", Dialog)
                    Button("Dialog (No taskbar icon)", DialogNoTaskbar)
                    Button("Owned window", OwnedWindow)
                    Button("Owned window (No taskbar icon)", OwnedWindowNoTaskbar)
                }
            )

            TextBlock("Pickers:").margin(0., 20., 0., 0.)

            CheckBox("Use filters", model.UseFilters, UseFiltersChanged)

            Expander(
                "FilePicker API",
                VStack(4.) {
                    CheckBox("Open multiple", model.OpenMultiple, OpenMultipleChanged)
                    Button("Select Folder", SelectFolder)
                    Button("Open File", OpenFile)
                    Button("Save File", SaveFile)
                    Button("Open File Bookmark", OpenFileBookmark)
                    Button("Open Folder Bookmark", OpenFolderBookmark)
                }
            )

            Expander(
                "Legacy OpenFileDialog",
                VStack(4.) {
                    Button("OpenFile", OpenFile)
                    Button("OpenMultipleFiles", OpenMultiple)
                    Button("SaveFile", SaveFile)
                    Button("SelectFolder", SelectFolder)
                    Button("OpenBoth", SelectBoth)
                }
            )

            AutoCompleteBox(model.CurrentFolderBox, CurrentFolderBoxTextChanged, [])
                .watermark("Write full path/uri or well known folder name")
                .onLoaded(CurrentFolderBoxLoaded)

            TextBlock("Last picker results:").isVisible(false)

            ItemsControl([], (fun item -> TextBlock(item)))
                .isVisible(false)

            TextBox(model.BookmarkContainer, BookmarkContainerTextChanged)
                .watermark("Bookmark")

            TextBox(model.OpenedFileContent, BookmarkContainerTextChanged)
                .watermark("Picked file content")
                .maxLines(10)

        })
            .margin(4.)
