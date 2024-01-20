namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Styling
open Fabulous

#if IOS
type SingleViewLifetime() =
    member val View: Avalonia.iOS.AvaloniaView = null with get, set

    interface Avalonia.Controls.ApplicationLifetimes.ISingleViewApplicationLifetime with
        member this.MainView
            with get () = this.View.Content
            and set value =
                if this.View <> null then
                    this.View.Content <- value
#endif

[<AutoOpen>]
module AppBuilderExtensions =
    type AppBuilder with

        static member inline private UseFabulousApp(canReuseView, logger, [<InlineIfLambda>] viewFn: unit -> Widget, theme: IStyle) =
            let builder =
                AppBuilder.Configure(fun () ->
                    let app =
                        FabApplication(
                            OnFrameworkInitialized =
                                fun app ->
                                    let widget = viewFn()

                                    let treeContext: ViewTreeContext =
                                        { CanReuseView = canReuseView
                                          Logger = logger
                                          Dispatch = ignore
                                          GetViewNode = ViewNode.get
                                          GetComponent = Component.get }

                                    let def = WidgetDefinitionStore.get widget.Key
                                    def.AttachView(widget, treeContext, ValueNone, app) |> ignore
                        )

                    app.Styles.Add(theme)
                    app)

#if !ANDROID && !IOS
            builder.UseAvaloniaNative().UseSkia()
#endif
#if ANDROID
            builder.UseAndroid()
#endif
#if IOS
            let lifetime = SingleViewLifetime()

            builder
                .UseiOS()
                .AfterSetup(fun _ ->
                    let scene = UIKit.UIApplication.SharedApplication.KeyWindow.WindowScene
                    let view = new Avalonia.iOS.AvaloniaView()
                    lifetime.View <- view

                    let win = new UIKit.UIWindow(scene.CoordinateSpace.Bounds, WindowScene = scene)
                    let controller = new Avalonia.iOS.DefaultAvaloniaViewController(View = view)
                    win.RootViewController <- controller
                    view.InitWithController(controller)

                    win.MakeKeyAndVisible())
                .SetupWithLifetime(lifetime)
#endif

        static member UseFabulousApp(program: Program<'arg, 'model, 'msg, #IFabApplication>, arg: 'arg, theme) =
            AppBuilder.UseFabulousApp(
                program.CanReuseView,
                program.State.Logger,
                (fun () ->
                    (View.Component(program.State, arg) {
                        let! model = Mvu.State
                        program.View model
                    })
                        .Compile()),
                theme
            )

        static member UseFabulousApp(program: Program<unit, 'model, 'msg, #IFabApplication>, theme) =
            AppBuilder.UseFabulousApp(program, (), theme)

        static member inline UseFabulousApp(view: unit -> WidgetBuilder<unit, #IFabApplication>, theme, ?canReuseView, ?logger) =
            AppBuilder.UseFabulousApp(
                (match canReuseView with
                 | Some fn -> fn
                 | None -> ViewHelpers.canReuseView),
                (match logger with
                 | Some logger -> logger
                 | None -> ProgramDefaults.defaultLogger()),
                (fun () -> (View.Component() { view() }).Compile()),
                theme
            )
