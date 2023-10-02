namespace Gallery

open Fabulous.Avalonia
open Controls

open Fabulous

open type Fabulous.Avalonia.View
open Fabulous.StackAllocatedCollections.StackList
open Gallery

type IFabCompositionPage =
    inherit IFabControl

module CompositionPageControl =
    let WidgetKey = Widgets.register<CompositionPage>()

[<AutoOpen>]
module CompositionPageControlBuilders =

    type Fabulous.Avalonia.View with

        static member inline CompositionPageControl<'msg>() =
            WidgetBuilder<'msg, IFabCompositionPage>(CompositionPageControl.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

module CompositionPage =

    type Model = { Nothing: string }

    type Msg = | NothingMsg

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = "" }, []

    let update msg model =
        match msg with
        | NothingMsg -> model, []

    let view _ = View.CompositionPageControl()
