namespace Gallery

open System
open System.Buffers
open System.Collections.Generic
open System.Diagnostics
open System.IO
open System.Reflection
open Avalonia
open Avalonia.Interactivity
open Avalonia.Platform.Storage
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module DialogsPage =
    type PickerResult =
        { BookmarkText: string
          FileContentText: string
          Results: List<string> }

    type Model =
        { UseFilters: bool
          OpenMultiple: bool
          CurrentFolderBox: string
          BookmarkContainer: string
          OpenedFileContent: string
          IgnoreTextChanged: bool
          LastSelectedDirectory: IStorageFolder
          FileResults: string seq
          PickerLastResultsVisible: bool
          StorageProvider: IStorageProvider }

    type Msg =
        | UseFiltersChanged of bool
        | OpenMultipleChanged of bool

        | OpenFilePicker
        | OpenFolderPicker
        | OpenFileFromBookmark
        | OpenFolderFromBookmark
        | SaveFilePicker
        | FilePickerOpened of PickerResult
        | FolderPickerOpened of PickerResult
        | FilePickerSaved of PickerResult
        | FileFromBookmarkOpened of PickerResult
        | FolderFromBookmarkOpened of PickerResult

        | CurrentFolderBoxTextChanged of string
        | BookmarkContainerTextChanged of string
        | OpenedFileContentTextChanged of string
        | CurrentFolderBoxLoaded of RoutedEventArgs
        | GetIStorageFolder of IStorageFolder
        | GetStorageProviderStatus of string

        | OnAttachedToVisualTree of VisualTreeAttachmentEventArgs

    type CmdMsg =
        | GettingIStorageFolder of storageProvider: IStorageProvider * text: string
        | GettingIStorageAvailable of storageProvider: IStorageProvider
        | OpeningFilePicker of storageProvider: IStorageProvider * lastSelectedDirectory: IStorageFolder * useFilters: bool * openMultiple: bool
        | OpeningFolderPicker of storageProvider: IStorageProvider * lastSelectedDirectory: IStorageFolder * openMultiple: bool
        | SavingFilePicker of storageProvider: IStorageProvider * lastSelectedDirectory: IStorageFolder * useFilters: bool * openedFileContent: string
        | OpeningFileFromBookmark of storageProvider: IStorageProvider * bookmarkText: string
        | OpeningFolderFromBookmark of storageProvider: IStorageProvider * bookmarkText: string

    let getStringFromStorageFile (storageProvider: IStorageProvider) (text: string) =
        task {
            let mutable folderEnum: WellKnownFolder = Unchecked.defaultof<WellKnownFolder>

            if Enum.TryParse<WellKnownFolder>(text, true, &folderEnum) then
                let! lastSelectedDirectory = storageProvider.TryGetWellKnownFolderAsync(folderEnum)
                return GetIStorageFolder lastSelectedDirectory
            else
                let mutable folderLink: Uri = null

                if not(Uri.TryCreate(text, UriKind.Absolute, &folderLink)) then
                    Uri.TryCreate("file://" + text, UriKind.Absolute, &folderLink) |> ignore

                if folderLink <> null then
                    let! lastSelectedDirectory = storageProvider.TryGetFolderFromPathAsync(folderLink)
                    return GetIStorageFolder lastSelectedDirectory
                else
                    let uri =
                        Assembly.GetEntryAssembly().GetModules()
                        |> Seq.head
                        |> fun m -> m.FullyQualifiedName

                    let! path = storageProvider.TryGetFolderFromPathAsync(Uri(uri))
                    return GetIStorageFolder path
        }

    let getStorageProviderAvailability (storageProvider: IStorageProvider) =
        try
            GetStorageProviderStatus
                $@"CanOpen: {storageProvider.CanOpen}
                                         CanSave: {storageProvider.CanSave}
                                         CanPickFolder: {storageProvider.CanPickFolder}"
        with ex ->
            GetStorageProviderStatus("Storage provider is not available: " + ex.Message)


    let getFileTypes (useFilters: bool) =
        if not useFilters then
            List.empty
        else
            let item = FilePickerFileType("Binary Log")
            item.Patterns <- [ "*.binlog"; "*.buildlog" ]
            item.MimeTypes <- [ "application/binlog"; "application/buildlog" ]
            item.AppleUniformTypeIdentifiers <- [ "public.data" ]
            [ FilePickerFileTypes.All; FilePickerFileTypes.TextPlain; item ]

    let readTextFromFile (file: IStorageFile) (length: int) =
        task {
            use! stream = file.OpenReadAsync()
            use reader = new StreamReader(stream)
            let buffer = ArrayPool<char>.Shared.Rent(length)

            try
                let! charsRead = reader.ReadAsync(buffer, 0, length)
                return new string(buffer, 0, charsRead)
            finally
                ArrayPool<char>.Shared.Return(buffer)
        }

    let fullPathOrName (item: IStorageItem) =
        if (item = null) then "(null)"
        else if item.Path.IsAbsoluteUri then item.Path.ToString()
        else item.Name

    let setPickerResult (items: IStorageItem seq) =
        task {
            let items = if items = null then Seq.empty else items

            let mutable bookmarkContainerText = "Can't bookmark"
            let mutable openedFileContentText = ""
            let mappedResults = List<string>()

            let item = items |> Seq.tryHead

            if item.IsSome then
                let! bookmark = item.Value.SaveBookmarkAsync()
                bookmarkContainerText <- bookmark

                let mutable resultText = if item.Value <> null then "File:" else "Folder:"
                resultText <- $"{resultText}{Environment.NewLine}"

                let! props = item.Value.GetBasicPropertiesAsync()

                resultText <-
                    @$"Size: {props.Size}
DateCreated: {props.DateCreated}
DateModified: {props.DateModified}
CanBookmark: {item.Value.CanBookmark}"

                resultText <- @"Content:"

                match item.Value with
                | :? IStorageFile as item ->
                    let! res = readTextFromFile item 500
                    resultText <- resultText + res
                | _ -> ()

                openedFileContentText <- resultText

                let! parent = item.Value.GetParentAsync()

                if (parent <> null) then
                    mappedResults.Add(fullPathOrName(parent))

                    for selectedItem in items do
                        mappedResults.Add("+> " + fullPathOrName(selectedItem))

                        if selectedItem <> null then
                            match selectedItem with
                            | :? IStorageFolder as folder ->
                                let! innerItems = folder.GetItemsAsync().AsTask()

                                for innerItem in innerItems do
                                    mappedResults.Add("++> " + fullPathOrName(innerItem))
                            | _ -> ()

            return
                { BookmarkText = bookmarkContainerText
                  FileContentText = openedFileContentText
                  Results = mappedResults }
        }

    let openFilePicker (storageProvider: IStorageProvider) (lastSelectedDirectory: IStorageFolder) (useFilters: bool) (openMultiple: bool) =
        task {
            let options = FilePickerOpenOptions()
            options.Title <- "Open file"
            options.AllowMultiple <- openMultiple
            options.FileTypeFilter <- getFileTypes useFilters

            options.SuggestedStartLocation <- lastSelectedDirectory
            let! res = storageProvider.OpenFilePickerAsync(options)
            let res = res |> Seq.cast<IStorageItem>
            let! res = setPickerResult res
            return FilePickerOpened res
        }

    let saveFilePicker (storageProvider: IStorageProvider) (lastSelectedDirectory: IStorageFolder) (useFilters: bool) (openedFileContent: string) =
        task {
            let fileTypes = getFileTypes useFilters
            let options = FilePickerSaveOptions()
            options.Title <- "Save file"
            options.FileTypeChoices <- fileTypes
            options.SuggestedFileName <- "FileName"
            options.SuggestedStartLocation <- lastSelectedDirectory
            options.DefaultExtension <- if not fileTypes.IsEmpty then "txt" else null
            options.ShowOverwritePrompt <- false

            let! file = storageProvider.SaveFilePickerAsync(options)

            if file <> null then
                use! stream = file.OpenWriteAsync()
                use reader = new StreamWriter(stream)
                do! reader.WriteLineAsync(openedFileContent)

            let files = if file = null then Seq.empty else [| file |]
            let files = files |> Seq.cast<IStorageItem>
            let! res = setPickerResult files
            return FilePickerSaved res
        }

    let openFolderPicker (storageProvider: IStorageProvider) (lastSelectedDirectory: IStorageFolder) (openMultiple: bool) =
        task {
            let options = FolderPickerOpenOptions()
            options.Title <- "Select folder"
            options.AllowMultiple <- openMultiple
            options.SuggestedStartLocation <- lastSelectedDirectory

            let! folders = storageProvider.OpenFolderPickerAsync(options)
            let folders = folders |> Seq.cast<IStorageItem>
            let! res = setPickerResult folders
            return FolderPickerOpened res
        }

    let openFileFromBookmark (storageProvider: IStorageProvider) (bookmarkText: string) =
        task {
            let mutable file: IStorageBookmarkFile = null

            if String.NotNullOrEmpty bookmarkText then
                let! bookmarkFile = storageProvider.OpenFileBookmarkAsync(bookmarkText)
                file <- bookmarkFile

            let bookmarkFiles = if file = null then Seq.empty else [| file |]
            let storageItems = bookmarkFiles |> Seq.cast<IStorageItem>
            let! pickerResult = setPickerResult storageItems
            return FileFromBookmarkOpened pickerResult
        }

    let openFolderFromBookmark (storageProvider: IStorageProvider) (bookmarkText: string) =
        task {
            let mutable folder: IStorageBookmarkFolder = null

            if String.NotNullOrEmpty bookmarkText then
                let! bookmarkFolder = storageProvider.OpenFolderBookmarkAsync(bookmarkText)
                folder <- bookmarkFolder

            let bookmarkFolders = if folder = null then Seq.empty else [| folder |]

            let storageItems = bookmarkFolders |> Seq.cast<IStorageItem>
            let! pickerResult = setPickerResult storageItems
            return FolderFromBookmarkOpened pickerResult
        }

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | GettingIStorageFolder(storageProvider, text) -> Cmd.ofTaskMsg(getStringFromStorageFile storageProvider text)
        | OpeningFilePicker(storageProvider, lastSelectedDirectory, useFilters, openMultiple) ->
            Cmd.ofTaskMsg(openFilePicker storageProvider lastSelectedDirectory useFilters openMultiple)
        | SavingFilePicker(storageProvider, lastSelectedDirectory, useFilters, openedFileContent) ->
            Cmd.ofTaskMsg(saveFilePicker storageProvider lastSelectedDirectory useFilters openedFileContent)
        | GettingIStorageAvailable storageProvider -> Cmd.ofMsg(getStorageProviderAvailability storageProvider)
        | OpeningFolderPicker(storageProvider, lastSelectedDirectory, openMultiple) ->
            Cmd.ofTaskMsg(openFolderPicker storageProvider lastSelectedDirectory openMultiple)
        | OpeningFileFromBookmark(storageProvider, bookmarkText) -> Cmd.ofTaskMsg(openFileFromBookmark storageProvider bookmarkText)
        | OpeningFolderFromBookmark(storageProvider, bookmarkText) -> Cmd.ofTaskMsg(openFolderFromBookmark storageProvider bookmarkText)

    let init () =
        { UseFilters = false
          OpenMultiple = false
          CurrentFolderBox = ""
          BookmarkContainer = ""
          OpenedFileContent = ""
          IgnoreTextChanged = false
          LastSelectedDirectory = null
          FileResults = Seq.empty
          PickerLastResultsVisible = false
          StorageProvider = null },
        []

    let update msg model =
        match msg with
        | UseFiltersChanged b -> { model with UseFilters = b }, []
        | OpenMultipleChanged b -> { model with OpenMultiple = b }, []
        | OpenFilePicker -> model, [ OpeningFilePicker(model.StorageProvider, model.LastSelectedDirectory, model.UseFilters, model.OpenMultiple) ]
        | SaveFilePicker -> model, [ SavingFilePicker(model.StorageProvider, model.LastSelectedDirectory, model.UseFilters, model.OpenedFileContent) ]
        | OpenFileFromBookmark -> model, [ OpeningFileFromBookmark(model.StorageProvider, model.BookmarkContainer) ]
        | OpenFolderFromBookmark -> model, []
        | CurrentFolderBoxTextChanged text ->
            if model.IgnoreTextChanged then
                { model with CurrentFolderBox = text }, []
            else
                { model with CurrentFolderBox = text }, [ GettingIStorageFolder(model.StorageProvider, text) ]
        | CurrentFolderBoxLoaded _ -> model, []
        | BookmarkContainerTextChanged s -> { model with BookmarkContainer = s }, []
        | OpenedFileContentTextChanged s -> { model with OpenedFileContent = s }, []
        | GetIStorageFolder storageFolder ->
            { model with
                LastSelectedDirectory = storageFolder },
            []
        | FilePickerOpened res ->
            let results = res.Results

            { model with
                FileResults = results
                OpenedFileContent = res.FileContentText
                BookmarkContainer = res.BookmarkText
                PickerLastResultsVisible = not(results |> Seq.isEmpty) },
            []
        | FilePickerSaved result ->
            { model with
                FileResults = result.Results
                OpenedFileContent = result.FileContentText
                BookmarkContainer = result.BookmarkText
                PickerLastResultsVisible = true },
            []

        | GetStorageProviderStatus s -> { model with OpenedFileContent = s }, []

        | OpenFolderPicker -> model, [ OpeningFolderPicker(model.StorageProvider, model.LastSelectedDirectory, model.OpenMultiple) ]
        | FolderPickerOpened res ->
            let results = res.Results

            { model with
                FileResults = results
                PickerLastResultsVisible = not(results |> Seq.isEmpty) },
            []
        | FileFromBookmarkOpened pickerResult ->
            { model with
                FileResults = pickerResult.Results
                PickerLastResultsVisible = not(pickerResult.Results |> Seq.isEmpty)
                BookmarkContainer = pickerResult.BookmarkText
                OpenedFileContent = pickerResult.FileContentText },
            []
        | FolderFromBookmarkOpened pickerResult ->
            { model with
                FileResults = pickerResult.Results
                PickerLastResultsVisible = not(pickerResult.Results |> Seq.isEmpty)
                BookmarkContainer = pickerResult.BookmarkText
                OpenedFileContent = pickerResult.FileContentText },
            []

        | OnAttachedToVisualTree _ ->
            { model with
                StorageProvider = FabApplication.Current.StorageProvider },
            [ GettingIStorageAvailable FabApplication.Current.StorageProvider ]

    let program =
        Program.statefulWithCmdMsg init update mapCmdMsgToCmd
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

            (VStack(4.) {
                TextBlock("Pickers:").margin(0., 20., 0., 0.)
                CheckBox("Use filters", model.UseFilters, UseFiltersChanged)
                CheckBox("Open multiple", model.OpenMultiple, OpenMultipleChanged)

                VStack(4.) {
                    Button("Open File Picker", OpenFilePicker)
                    Button("Open File From Bookmark", OpenFileFromBookmark)
                    Button("Open Folder From Bookmark", OpenFolderFromBookmark)
                    Button("Open Folder Picker", OpenFolderPicker)
                    Button("SaveFilePicker", SaveFilePicker)
                }

                AutoCompleteBox(model.CurrentFolderBox, CurrentFolderBoxTextChanged, [])
                    .watermark("Write full path/uri or well known folder name")
                    .onLoaded(CurrentFolderBoxLoaded)

                TextBlock("Last picker results:")
                    .isVisible(model.PickerLastResultsVisible)

                ItemsControl(model.FileResults, (fun item -> TextBlock(item)))
                    .isVisible(model.PickerLastResultsVisible)

                TextBox(model.BookmarkContainer, BookmarkContainerTextChanged)
                    .watermark("Bookmark")

                TextBox(model.OpenedFileContent, BookmarkContainerTextChanged)
                    .watermark("Picked file content")
                    .maxLines(10)

            })
                .margin(4.)
                .onAttachedToVisualTree(OnAttachedToVisualTree)
        }
