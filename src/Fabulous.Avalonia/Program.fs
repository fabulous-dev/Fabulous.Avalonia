namespace Fabulous.Avalonia

open System
open System.Diagnostics
open Avalonia.Threading

open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions

module ViewHelpers =
    let private tryGetScalarValue (widget: Widget) (def: SimpleScalarAttributeDefinition<'data>) =
        match widget.ScalarAttributes with
        | ValueNone -> ValueNone
        | ValueSome scalarAttrs ->
            match Array.tryFind(fun (attr: ScalarAttribute) -> attr.Key = def.Key) scalarAttrs with
            | None -> ValueNone
            | Some attr -> ValueSome(unbox<'data> attr.Value)

    let private tryGetWidgetCollectionValue (widget: Widget) (def: WidgetCollectionAttributeDefinition) =
        match widget.WidgetCollectionAttributes with
        | ValueNone -> ValueNone
        | ValueSome collectionAttrs ->
            match Array.tryFind(fun (attr: WidgetCollectionAttribute) -> attr.Key = def.Key) collectionAttrs with
            | None -> ValueNone
            | Some attr -> ValueSome attr.Value

    /// Extend the canReuseView function to check Xamarin.Forms specific constraints
    let rec canReuseView (prev: Widget) (curr: Widget) =
        if ViewHelpers.canReuseView prev curr then
            true
        else
            false

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
    let inline private define
        (init: 'arg -> 'model * Cmd<'msg>)
        (update: 'msg -> 'model -> 'model * Cmd<'msg>)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        =
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
        define(fun () -> (), Cmd.none) (fun () () -> (), Cmd.none) view
        
    /// Start the program
    let startApplicationWithArgs
        (arg: 'arg)
        (program: Program<'arg, 'model, 'msg, #IFabApplication>)
        : Avalonia.Application =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create ViewNode.get runner
        adapter.CreateView() |> unbox

    /// Start the program
    let startApplication
        (program: Program<unit, 'model, 'msg, #IFabApplication>)
        : Avalonia.Application =
        startApplicationWithArgs() program

