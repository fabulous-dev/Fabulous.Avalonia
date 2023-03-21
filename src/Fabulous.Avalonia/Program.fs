namespace Fabulous.Avalonia

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Threading

open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions

module ViewHelpers =
    let private tryGetScalarValue (widget: Widget) (def: SimpleScalarAttributeDefinition<'data>) =
        match widget.ScalarAttributes with
        | ValueNone -> ValueNone
        | ValueSome scalarAttrs ->
            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = def.Key) scalarAttrs with
            | None -> ValueNone
            | Some attr -> ValueSome(unbox<'data> attr.Value)

    let private tryGetWidgetCollectionValue (widget: Widget) (def: WidgetCollectionAttributeDefinition) =
        match widget.WidgetCollectionAttributes with
        | ValueNone -> ValueNone
        | ValueSome collectionAttrs ->
            match Array.tryFind (fun (attr: WidgetCollectionAttribute) -> attr.Key = def.Key) collectionAttrs with
            | None -> ValueNone
            | Some attr -> ValueSome attr.Value

    /// Extend the canReuseView function to check Xamarin.Forms specific constraints
    let rec canReuseView (prev: Widget) (curr: Widget) =
        if ViewHelpers.canReuseView prev curr then
            let def = WidgetDefinitionStore.get curr.Key

            // TargetType can be null for MemoWidget
            // but it has already been checked by Fabulous.ViewHelpers.canReuseView
            if def.TargetType <> null then
                if def.TargetType.IsAssignableTo(typeof<TextBlock>) then
                    canReuseTextBlock prev curr
                elif def.TargetType.IsAssignableTo(typeof<Carousel>) then
                    canReuseCarousel prev curr
                elif def.TargetType.IsAssignableTo(typeof<ListBox>) then
                    canReuseListBox prev curr
                else
                    true
            else
                true
        else
            false

    /// TextBlock's text can be defined by both the Text and Inlines property
    /// Except when switching between the two, Avalonia will automatically clear out the other property
    /// Depending on the order of execution, this can lead to a desync between Avalonia and Fabulous
    /// So, it's better to not reuse a TextBlock when we are about to switch between Text and Inlines
    and canReuseTextBlock (prev: Widget) (curr: Widget) =
        let switchingFromTextToInlines =
            (tryGetScalarValue prev TextBlock.Text).IsSome
            && (tryGetWidgetCollectionValue curr TextBlock.Inlines).IsSome

        let switchingFromInlinesToText =
            (tryGetWidgetCollectionValue prev TextBlock.Inlines).IsSome
            && (tryGetScalarValue curr TextBlock.Text).IsSome

        not switchingFromTextToInlines && not switchingFromInlinesToText

    and canReuseCarousel (prev: Widget) (curr: Widget) =
        let switchingFromItemsSourceToItems =
            (tryGetScalarValue prev Carousel.ItemsSource).IsSome
            && (tryGetWidgetCollectionValue curr Carousel.Items).IsSome

        let switchingFromItemsToItemsSource =
            (tryGetWidgetCollectionValue prev Carousel.Items).IsSome
            && (tryGetScalarValue curr Carousel.ItemsSource).IsSome

        not switchingFromItemsSourceToItems && not switchingFromItemsToItemsSource

    and canReuseListBox (prev: Widget) (curr: Widget) =
        let switchingFromItemsSourceToItems =
            (tryGetScalarValue prev ListBox.ItemsSource).IsSome
            && (tryGetWidgetCollectionValue curr ListBox.Items).IsSome

        let switchingFromItemsToItemsSource =
            (tryGetWidgetCollectionValue prev ListBox.Items).IsSome
            && (tryGetScalarValue curr ListBox.ItemsSource).IsSome

        not switchingFromItemsSourceToItems && not switchingFromItemsToItemsSource

    let defaultLogger () =
        let log (level, message) =
            let traceLevel =
                match level with
                | LogLevel.Debug -> "Debug"
                | LogLevel.Info -> "Information"
                | LogLevel.Warn -> "Warning"
                | LogLevel.Error -> "Error"
                | _ -> "Error"

            Trace.WriteLine(message, traceLevel)

        { Log = log
          MinLogLevel = LogLevel.Error }

    let defaultExceptionHandler exn =
        Trace.WriteLine(String.Format("Unhandled exception: {0}", exn.ToString()), "Debug")
        false

module Program =
    let inline private define (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        { Init = init
          Update = (fun (msg, model) -> update msg model)
          Subscribe = fun _ -> Cmd.none
          View = view
          CanReuseView = ViewHelpers.canReuseView
          SyncAction = Dispatcher.UIThread.Post
          Logger = ViewHelpers.defaultLogger()
          ExceptionHandler = ViewHelpers.defaultExceptionHandler }

    /// Create a program for a static view
    let stateless (view: unit -> WidgetBuilder<unit, 'marker>) =
        define (fun () -> (), Cmd.none) (fun () () -> (), Cmd.none) view

    /// Create a program using an MVU loop
    let stateful (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        define (fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none) view

    /// Create a program using an MVU loop. Add support for Cmd
    let statefulWithCmd
        (init: 'arg -> 'model * Cmd<'msg>)
        (update: 'msg -> 'model -> 'model * Cmd<'msg>)
        (view: 'model -> WidgetBuilder<'msg, #IFabApplication>)
        =
        define init update view

    /// Create a program using an MVU loop. Add support for CmdMsg
    let statefulWithCmdMsg
        (init: 'arg -> 'model * 'cmdMsg list)
        (update: 'msg -> 'model -> 'model * 'cmdMsg list)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        (mapCmd: 'cmdMsg -> Cmd<'msg>)
        =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch

        define (fun arg -> let m, c = init arg in m, mapCmds c) (fun msg model -> let m, c = update msg model in m, mapCmds c) view

    /// Start the program
    let startApplicationWithArgs (arg: 'arg) (program: Program<'arg, 'model, 'msg, #IFabApplication>) : Application =
        FabApplication<'arg, 'model, 'msg, #IFabApplication>(program, arg)

    /// Start the program
    let startApplication (program: Program<unit, 'model, 'msg, #IFabApplication>) : Application =
        FabApplication<unit, 'model, 'msg, #IFabApplication>(program, ())

    /// Subscribe to external source of events.
    /// The subscription is called once - with the initial model, but can dispatch new messages at any time.
    let withSubscription (subscribe: 'model -> Cmd<'msg>) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let sub model =
            Cmd.batch [ program.Subscribe model; subscribe model ]

        { program with Subscribe = sub }

    /// Configure how the output messages from Fabulous will be handled
    let withLogger (logger: Logger) (program: Program<'arg, 'model, 'msg, 'marker>) = { program with Logger = logger }

    /// Trace all the updates to the debug output
    let withTrace (trace: string * string -> unit) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let traceInit arg =
            try
                let initModel, cmd = program.Init(arg)
                trace("Initial model: {0}", $"%0A{initModel}")
                initModel, cmd
            with e ->
                trace("Error in init function: {0}", $"%0A{e}")
                reraise()

        let traceUpdate (msg, model) =
            trace("Message: {0}", $"%0A{msg}")

            try
                let newModel, cmd = program.Update(msg, model)
                trace("Updated model: {0}", $"%0A{newModel}")
                newModel, cmd
            with e ->
                trace("Error in model function: {0}", $"%0A{e}")
                reraise()

        let traceView model =
            trace("View, model = {0}", $"%0A{model}")

            try
                let info = program.View(model)
                trace("View result: {0}", $"%0A{info}")
                info
            with e ->
                trace("Error in view function: {0}", $"%0A{e}")
                reraise()

        { program with
            Init = traceInit
            Update = traceUpdate
            View = traceView }

    /// Configure how the unhandled exceptions happening during the execution of a Fabulous app with be handled
    let withExceptionHandler (handler: exn -> bool) (program: Program<'arg, 'model, 'msg, 'marker>) =
        { program with
            ExceptionHandler = handler }

    /// Allow the app to react to theme changes
    let withThemeAwareness (program: Program<'arg, 'model, 'msg, #IFabApplication>) =
        { Init = ThemeAwareProgram.init program.Init
          Update = ThemeAwareProgram.update program.Update
          Subscribe = fun model -> program.Subscribe model.Model |> Cmd.map ThemeAwareProgram.Msg.ModelMsg
          View = ThemeAwareProgram.view program.View
          CanReuseView = program.CanReuseView
          SyncAction = program.SyncAction
          Logger = program.Logger
          ExceptionHandler = program.ExceptionHandler }

[<RequireQualifiedAccess>]
module CmdMsg =
    let batch mapCmdMsgFn mapCmdFn cmdMsgs =
        cmdMsgs |> List.map(mapCmdMsgFn >> Cmd.map mapCmdFn) |> Cmd.batch
