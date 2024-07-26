namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Styling
open Fabulous

[<AbstractClass; Sealed>]
type FabulousAppBuilder private () =
    static member inline private Configure
        (canReuseView, logger, syncAction: (unit -> unit) -> unit, [<InlineIfLambda>] themeFn: unit -> #IStyle, [<InlineIfLambda>] viewFn: unit -> Widget) =
        AppBuilder.Configure(fun () ->
            let app =
                FabApplication(
                    OnFrameworkInitialized =
                        fun app ->
                            let widget = viewFn()

                            let treeContext: ViewTreeContext =
                                { CanReuseView = canReuseView
                                  GetViewNode = ViewNode.get
                                  GetComponent = Component.get
                                  SetComponent = Component.set
                                  SyncAction = syncAction
                                  Logger = logger
                                  Dispatch = ignore }

                            let def = WidgetDefinitionStore.get widget.Key
                            def.AttachView(widget, treeContext, ValueNone, app) |> ignore
                )

            app.Styles.Add(themeFn())
            app)

    static member Configure(themeFn, program: Program<'arg, 'model, 'msg, #IFabApplication>, arg: 'arg) =
        FabulousAppBuilder.Configure(
            program.CanReuseView,
            program.State.Logger,
            program.SyncAction,
            themeFn,
            (fun () ->
                (View.Component(program.State, arg) {
                    let! model = Mvu.State
                    program.View model
                })
                    .Compile())
        )

    static member Configure(themeFn: unit -> #IStyle, program: Program<unit, 'model, 'msg, #IFabApplication>) =
        FabulousAppBuilder.Configure(themeFn, program, ())

    static member Configure(themeFn: unit -> #IStyle, view: unit -> WidgetBuilder<unit, #IFabApplication>, ?canReuseView, ?logger, ?syncAction) =
        let canReuseView =
            match canReuseView with
            | Some fn -> fn
            | None -> ViewHelpers.canReuseView

        let logger =
            match logger with
            | Some logger -> logger
            | None -> ProgramDefaults.defaultLogger()

        let syncAction =
            match syncAction with
            | Some syncAction -> syncAction
            | None -> ViewHelpers.defaultSyncAction

        FabulousAppBuilder.Configure(canReuseView, logger, syncAction, themeFn, (fun () -> (View.Component() { view() }).Compile()))

#if IOS
open UIKit
open Avalonia.iOS

type SingleViewLifetime() =
    member val View: AvaloniaView = null with get, set

    interface Avalonia.Controls.ApplicationLifetimes.ISingleViewApplicationLifetime with
        member this.MainView
            with get () = this.View.Content
            and set value =
                if this.View <> null then
                    this.View.Content <- value

[<AutoOpen>]
module FabulousiOSAppBuilderExtensions =
    type AppBuilder with

        member this.UseiOS(sceneDelegate: UIWindowSceneDelegate, scene: UIWindowScene) =
            let lifetime = SingleViewLifetime()

            this
                .UseiOS()
                .AfterSetup(fun _ ->
                    let view = new AvaloniaView()
                    lifetime.View <- view

                    let win = new UIWindow(WindowScene = scene)

                    let controller = new DefaultAvaloniaViewController(View = view)
                    win.RootViewController <- controller
                    view.InitWithController(controller)

                    sceneDelegate.Window <- win
                    win.MakeKeyAndVisible())
                .SetupWithLifetime(lifetime)
#endif
