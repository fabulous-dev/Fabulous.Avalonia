namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Styling
open Avalonia.Threading
open Fabulous

[<AbstractClass; Sealed>]
type FabulousAppBuilder private () =
    static member inline private Configure(canReuseView, logger, [<InlineIfLambda>] themeFn: unit -> #IStyle, [<InlineIfLambda>] viewFn: unit -> Widget) =
        AppBuilder.Configure(fun () ->
            FabApplication(
                OnFrameworkInitialized =
                    fun app ->
                        app.Styles.Add(themeFn())

                        let widget = viewFn()

                        let treeContext: ViewTreeContext =
                            { CanReuseView = canReuseView
                              GetViewNode = ViewNode.get
                              GetComponent = Component.get
                              Logger = logger
                              Dispatch = ignore }

                        let def = WidgetDefinitionStore.get widget.Key
                        def.AttachView(widget, treeContext, ValueNone, app) |> ignore
            ))

    static member Configure(themeFn, program: Program<'arg, 'model, 'msg, #IFabApplication>, arg: 'arg) =
        FabulousAppBuilder.Configure(
            program.CanReuseView,
            program.State.Logger,
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

    static member Configure(themeFn: unit -> #IStyle, view: unit -> WidgetBuilder<unit, #IFabApplication>, ?canReuseView, ?logger) =
        let canReuseView =
            match canReuseView with
            | Some fn -> fn
            | None -> ViewHelpers.canReuseView

        let logger =
            match logger with
            | Some logger -> logger
            | None -> ProgramDefaults.defaultLogger()

        // It is very important to keep the Dispatcher.UIThread in a lambda here, otherwise UIThread will be initialized before Avalonia and the app will crash
        FabulousAppBuilder.Configure(canReuseView, logger, themeFn, (fun () -> (View.Component() { view() }).Compile()))

#if IOS
type SingleViewLifetime() =
    member val View: Avalonia.iOS.AvaloniaView = null with get, set

    interface Avalonia.Controls.ApplicationLifetimes.ISingleViewApplicationLifetime with
        member this.MainView
            with get () = this.View.Content
            and set value =
                if this.View <> null then
                    this.View.Content <- value

[<AutoOpen>]
module FabulousiOSAppBuilderExtensions =
    type AppBuilder with

        member this.UseiOS(scene: UIKit.UIWindowScene) =
            let lifetime = SingleViewLifetime()

            this
                .UseiOS()
                .AfterSetup(fun _ ->
                    let view = new Avalonia.iOS.AvaloniaView()
                    lifetime.View <- view

                    let win = new UIKit.UIWindow(scene.CoordinateSpace.Bounds, WindowScene = scene)
                    let controller = new Avalonia.iOS.DefaultAvaloniaViewController(View = view)
                    win.RootViewController <- controller
                    view.InitWithController(controller)

                    win.MakeKeyAndVisible())
                .SetupWithLifetime(lifetime)
#endif
