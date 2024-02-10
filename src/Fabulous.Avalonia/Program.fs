namespace Fabulous.Avalonia

open System
open System.Diagnostics
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

    let defaultSyncAction (action: unit -> unit) = Dispatcher.UIThread.Post action

    let defaultExceptionHandler exn =
        Trace.WriteLine(String.Format("Unhandled exception: {0}", exn.ToString()), "Debug")
        false

//TODO how does this differ from Fabulous.Program? When to use which?
module Program =
    // TODO when would I want to use this?
    let withView (view: 'model -> WidgetBuilder<'msg, 'marker>) (state: Program<'arg, 'model, 'msg>) : Program<'arg, 'model, 'msg, 'marker> =
        { State = state
          View = view
          CanReuseView = ViewHelpers.canReuseView
          SyncAction = ViewHelpers.defaultSyncAction }

    // TODO when would I want to use this?
    let stateless (view: unit -> WidgetBuilder<unit, 'marker>) : Program<unit, unit, unit, 'marker> =
        Program.stateful (fun _ -> ()) (fun _ _ -> ()) |> withView view

    /// Trace all the view updates to the debug output
    let withViewTrace (trace: string * string -> unit) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let traceView model =
            trace("View, model = {0}", $"%0A{model}")

            try
                let info = program.View(model)
                trace("View result: {0}", $"%0A{info}")
                info
            with e ->
                trace("Error in view function: {0}", $"%0A{e}")
                reraise()

        { program with View = traceView }

//TODO RequireQualityDoco as well ;) - What is CmdMsg about?
[<RequireQualifiedAccess>]
module CmdMsg =
    let batch mapCmdMsgFn mapCmdFn cmdMsgs =
        cmdMsgs |> List.map(mapCmdMsgFn >> Cmd.map mapCmdFn) |> Cmd.batch
