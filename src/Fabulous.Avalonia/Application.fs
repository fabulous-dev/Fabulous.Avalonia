namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Styling
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabApplication =
    inherit IFabObject

type FabApplication() =
    inherit Application()

    let mutable _mainWindow: Window = null
    let mutable _mainView: Control = null

    member private this.UpdateLifetime() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime -> desktopLifetime.MainWindow <- _mainWindow
        | :? ISingleViewApplicationLifetime as singleViewLifetime -> singleViewLifetime.MainView <- _mainView
        | _ -> ()

    member this.MainWindow
        with get () = _mainWindow
        and set value =
            _mainWindow <- value
            this.UpdateLifetime()

    member this.MainView
        with get () = _mainView
        and set value =
            _mainView <- value
            this.UpdateLifetime()

    override this.OnFrameworkInitializationCompleted() =
        this.UpdateLifetime()

        base.OnFrameworkInitializationCompleted()

type FabApplication<'arg, 'model, 'msg, 'marker when 'marker :> IFabApplication>(program: Program<'arg, 'model, 'msg, 'marker>, arg: 'arg) =
    inherit FabApplication()

    override this.Initialize() =
        this.Styles.Add(FluentTheme())
        base.Initialize()

    override this.OnFrameworkInitializationCompleted() =
        let runner = Runners.create program
        runner.Start(arg)

        let adapter = ViewAdapters.create ViewNode.get runner
        adapter.Attach(this)

        base.OnFrameworkInitializationCompleted()

module ApplicationUpdaters =
    let mainWindowApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        let childViewNode = node.TreeContext.GetViewNode(target.MainWindow)
        childViewNode.ApplyDiff(&diff)

    let mainWindowUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabApplication

        match currOpt with
        | ValueNone -> target.MainWindow <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.MainWindow <- view :?> Window

    let mainViewApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        let childViewNode = node.TreeContext.GetViewNode(target.MainView)
        childViewNode.ApplyDiff(&diff)

    let mainViewUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabApplication

        match currOpt with
        | ValueNone -> target.MainView <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.MainView <- view :?> Control

module Application =
    let WidgetKey = Widgets.register<FabApplication>()

    let MainWindow =
        Attributes.defineWidget "MainWindow" ApplicationUpdaters.mainWindowApplyDiff ApplicationUpdaters.mainWindowUpdateNode

    let MainView =
        Attributes.defineWidget "MainView" ApplicationUpdaters.mainViewApplyDiff ApplicationUpdaters.mainViewUpdateNode

    let Name = Attributes.defineAvaloniaPropertyWithEquality Application.NameProperty

    let ThemeVariant =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Application_ThemeVariant" Application.RequestedThemeVariantProperty

    let ThemeVariantChanged =
        Attributes.defineEventNoArg "Application_ThemeVariantChanged" (fun target -> (target :?> Application).ActualThemeVariantChanged)

    let ResourcesChanged =
        Attributes.defineEvent "Application_ResourcesChangedEvent" (fun target -> (target :?> Application).ResourcesChanged)

    let UrlsOpened =
        Attributes.defineEvent "Application_UrlsOpenedEvent" (fun target -> (target :?> Application).UrlsOpened)

[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>
        /// Create a DesktopApplication widget with a content widget
        /// <example>
        /// <code>
        /// DesktopApplication(
        ///     Window(...)
        /// )
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="window">The main Window of the Application</param>
        static member DesktopApplication(window: WidgetBuilder<'msg, #IFabWindow>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Application.MainWindow.WithValue(window.Compile()) |], ValueNone)
            )

        /// <summary>
        /// Create a SingleViewApplication widget with a content widget
        /// <example>
        /// <code>
        /// SingleViewApplication(
        ///     VStack(){
        ///         ...
        ///     }
        /// )
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="view">The main View of the Application</param>
        static member SingleViewApplication(view: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Application.MainView.WithValue(view.Compile()) |], ValueNone)
            )

[<Extension>]
type ApplicationModifiers =
    /// <summary>Sets the application name</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">Application name to be used for various platform-specific purposes</param>
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabApplication>, value: string) =
        this.AddScalar(Application.Name.WithValue(value))

    /// <summary>Sets the application theme variant</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">Theme variant to be used for the application</param>
    /// <param name="fn">Function to be called when the theme variant changes</param>
    [<Extension>]
    static member inline themeVariant(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant, fn: ThemeVariant -> 'msg) =
        this.AddScalar(Application.ThemeVariant.WithValue(ValueEventData.create value (fun args -> fn args |> box)))

    /// <summary>Listens to the application theme variant changed event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the theme variant changes</param>
    [<Extension>]
    static member inline onThemeVariantChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: ThemeVariant -> 'msg) =
        this.AddScalar(Application.ThemeVariantChanged.WithValue(fn Application.Current.ActualThemeVariant))

    /// <summary>Listens to the application resources changed event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the resources change</param>
    [<Extension>]
    static member inline onResourcesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: ResourcesChangedEventArgs -> 'msg) =
        this.AddScalar(Application.ResourcesChanged.WithValue(fun target -> fn target |> box))

    /// <summary>Listens to the application urls opened event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the application receives urls to open</param>
    [<Extension>]
    static member inline onUrlsOpened(this: WidgetBuilder<'msg, #IFabApplication>, fn: UrlOpenedEventArgs -> 'msg) =
        this.AddScalar(Application.UrlsOpened.WithValue(fun target -> fn target |> box))

    /// <summary>Link a ViewRef to access the direct CheckBox control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabApplication>, value: ViewRef<FabApplication>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type TrayIconAttachedModifiers =
    /// <summary>Sets the tray icon for the application
    /// <param name="this">Current widget</param>
    /// <example>
    /// <code>
    /// DesktopApplication(...)
    ///    .trayIcons() {
    ///        TrayIcon(WindowIcon(ImageSource.fromString ".."), "Avalonia TrayIcon")
    ///     }
    /// </code>
    /// </example>
    /// </summary>
    [<Extension>]
    static member inline trayIcons<'msg, 'marker when 'marker :> IFabApplication>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabTrayIcon> TrayIconAttached.TrayIcons this

[<Extension>]
type TrayIconYieldExtensions =
    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>, x: WidgetBuilder<'msg, #IFabTrayIcon>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabTrayIcon>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
