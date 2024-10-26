namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Controls.Notifications
open Avalonia.Media
open Avalonia.Rendering
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

#nowarn "0044" // Disable obsolete warnings in Fabulous.Avalonia. Please remove after deleting obsolete code.

type IFabApplication =
    inherit IFabAvaloniaObject

type FabApplication() =
    inherit Application()

    let mutable _mainWindow: Window = null
    let mutable _mainView: Control = null

    let mutable _onFrameworkInitialized: Application -> unit = fun _ -> ()

    member this.OnFrameworkInitialized
        with get () = _onFrameworkInitialized
        and set value = _onFrameworkInitialized <- value

    override this.OnFrameworkInitializationCompleted() =
        this.OnFrameworkInitialized(this)
        base.OnFrameworkInitializationCompleted()

    member private this.UpdateLifetime() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime -> desktopLifetime.MainWindow <- _mainWindow
        | :? ISingleViewApplicationLifetime as singleViewLifetime -> singleViewLifetime.MainView <- _mainView
        | _ -> ()

    /// <summary>Gets the top-level window or view for the application.</summary>
    member this.TopLevel =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when not (isNull _mainWindow) -> TopLevel.GetTopLevel(_mainWindow)
        | :? ISingleViewApplicationLifetime when not (isNull _mainView) -> TopLevel.GetTopLevel(_mainView)
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary> Initializes a new instance of the WindowNotificationManager class.</summary>
    member this.WindowNotificationManager =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when not (isNull _mainWindow) -> WindowNotificationManager(TopLevel.GetTopLevel(_mainWindow))
        | :? ISingleViewApplicationLifetime when not (isNull _mainView) -> WindowNotificationManager(TopLevel.GetTopLevel(_mainView))
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Gets the platform's clipboard implementation</summary>
    member this.Clipboard =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when not (isNull _mainWindow) -> TopLevel.GetTopLevel(_mainWindow).Clipboard
        | :? ISingleViewApplicationLifetime when not (isNull _mainView) -> TopLevel.GetTopLevel(_mainView).Clipboard
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>File System storage service used for file pickers and bookmarks.</summary>
    member this.StorageProvider =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when not (isNull _mainWindow) -> TopLevel.GetTopLevel(_mainWindow).StorageProvider
        | :? ISingleViewApplicationLifetime when not (isNull _mainView) -> TopLevel.GetTopLevel(_mainView).StorageProvider
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Manages focus for the application.</summary>
    member this.FocusManager =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when not (isNull _mainWindow) -> TopLevel.GetTopLevel(_mainWindow).FocusManager
        | :? ISingleViewApplicationLifetime when not (isNull _mainView) -> TopLevel.GetTopLevel(_mainView).FocusManager
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Gets the platform-specific settings for the application.</summary>
    member this.PlatformSettings =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when not (isNull _mainWindow) -> TopLevel.GetTopLevel(_mainWindow).PlatformSettings
        | :? ISingleViewApplicationLifetime when not (isNull _mainView) -> TopLevel.GetTopLevel(_mainView).PlatformSettings
        | _ -> failwith "ApplicationLifetime is not supported"

    /// <summary>Gets the platform-specific insets manager for the application.</summary>
    member this.InsetsManager =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime when not (isNull _mainWindow) -> TopLevel.GetTopLevel(_mainWindow).InsetsManager
        | :? ISingleViewApplicationLifetime when not (isNull _mainView) -> TopLevel.GetTopLevel(_mainView).InsetsManager
        | _ -> failwith "ApplicationLifetime is not supported"

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

    /// <summary>Gets the current application instance.</summary>
    static member Current = Application.Current :?> FabApplication

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

    let TrayIcons =
        Attributes.defineAvaloniaListWidgetCollection "TrayIcon_TrayIcons" (fun target ->
            let target = target :?> FabApplication
            let trayIcons = TrayIcon.GetIcons(target)

            if isNull trayIcons then
                let trayIcons = TrayIcons()
                TrayIcon.SetIcons(target, trayIcons)
                trayIcons
            else
                trayIcons)

    let MainWindow =
        Attributes.defineWidget "MainWindow" ApplicationUpdaters.mainWindowApplyDiff ApplicationUpdaters.mainWindowUpdateNode

    let MainView =
        Attributes.defineWidget "MainView" ApplicationUpdaters.mainViewApplyDiff ApplicationUpdaters.mainViewUpdateNode

    let Name = Attributes.defineAvaloniaPropertyWithEquality Application.NameProperty

    let DebugOverlays =
        Attributes.definePropertyWithGetSet
            "Application_DebugOverlays"
            (fun target ->
                (target :?> FabApplication)
                    .TopLevel.RendererDiagnostics.DebugOverlays)
            (fun target value ->
                (target :?> FabApplication)
                    .TopLevel.RendererDiagnostics.DebugOverlays <- value)

    let IsSystemBarVisible =
        Attributes.definePropertyWithGetSet
            "Application_IsSystemBarVisible"
            (fun target -> (target :?> FabApplication).InsetsManager.IsSystemBarVisible)
            (fun target value -> (target :?> FabApplication).InsetsManager.IsSystemBarVisible <- value)

    let DisplayEdgeToEdge =
        Attributes.definePropertyWithGetSet
            "Application_DisplayEdgeToEdge"
            (fun target -> (target :?> FabApplication).InsetsManager.DisplayEdgeToEdge)
            (fun target value -> (target :?> FabApplication).InsetsManager.DisplayEdgeToEdge <- value)

    let SystemBarColor =
        Attributes.definePropertyWithGetSet
            "Application_SystemBarColor"
            (fun target -> (target :?> FabApplication).InsetsManager.SystemBarColor)
            (fun target value -> (target :?> FabApplication).InsetsManager.SystemBarColor <- value)

    let RequestedThemeVariant =
        Attributes.definePropertyWithGetSet "Application_RequestedThemeVariant" (fun _ -> FabApplication.Current.ActualThemeVariant) (fun _ value ->
            FabApplication.Current.RequestedThemeVariant <- value)

    let ActualThemeVariantChanged =
        Attributes.defineEventNoArg "Application_ActualThemeVariantChanged" (fun target -> (target :?> FabApplication).ActualThemeVariantChanged)

    let ResourcesChanged =
        Attributes.defineEvent "Application_ResourcesChangedEvent" (fun target -> (target :?> FabApplication).ResourcesChanged)

    let UrlsOpened =
        Attributes.defineEvent "Application_UrlsOpenedEvent" (fun target -> (target :?> FabApplication).UrlsOpened)

    let ColorValuesChanged =
        Attributes.defineEvent "PlatformSettings_ColorValuesChanged" (fun target ->
            (target :?> FabApplication)
                .PlatformSettings.ColorValuesChanged)

    let SafeAreaChanged =
        Attributes.defineEvent "PlatformSettings_SafeAreaChanged" (fun target -> (target :?> FabApplication).InsetsManager.SafeAreaChanged)

[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DesktopApplication widget with a content widget.</summary>
        /// <param name="window">The main Window of the Application.</param>
        static member DesktopApplication(window: WidgetBuilder<'msg, #IFabWindow>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Application.MainWindow.WithValue(window.Compile()) |], ValueNone)
            )

        /// <summary>Creates a DesktopApplication widget with a content widget.</summary>
        static member inline DesktopApplication<'msg, 'childMarker>() =
            SingleChildBuilder<'msg, IFabApplication, 'childMarker>(Application.WidgetKey, Application.MainWindow)

        /// <summary>Creates a SingleViewApplication widget with a content widget.</summary>
        /// <param name="view">The main View of the Application.</param>
        static member SingleViewApplication(view: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Application.MainView.WithValue(view.Compile()) |], ValueNone)
            )

        /// <summary>Creates a DesktopApplication widget with a content widget.</summary>
        static member inline SingleViewApplication<'msg, 'childMarker>() =
            SingleChildBuilder<'msg, IFabApplication, 'childMarker>(Application.WidgetKey, Application.MainView)

type ApplicationModifiers =
    /// <summary>Sets the application name.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Application name to be used for various platform-specific purposes.</param>
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabApplication>, value: string) =
        this.AddScalar(Application.Name.WithValue(value))

    /// <summary>Sets the application debug overlays.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Debug overlays to be used for the application.</param>
    [<Extension>]
    static member inline debugOverlays(this: WidgetBuilder<'msg, #IFabApplication>, value: RendererDebugOverlays) =
        this.AddScalar(Application.DebugOverlays.WithValue(value))

    /// <summary>Sets the application system bar visibility.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">System bar visibility to be used for the application.</param>
    [<Extension>]
    static member inline isSystemBarVisible(this: WidgetBuilder<'msg, #IFabApplication>, value: bool) =
        this.AddScalar(Application.IsSystemBarVisible.WithValue(value))

    /// <summary>Sets the application display edge to edge.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Display edge to edge to be used for the application.</param>
    [<Extension>]
    static member inline displayEdgeToEdge(this: WidgetBuilder<'msg, #IFabApplication>, value: bool) =
        this.AddScalar(Application.DisplayEdgeToEdge.WithValue(value))

    /// <summary>Sets the application system bar color.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">System bar color to be used for the application.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabApplication>, value: Color) =
        this.AddScalar(Application.SystemBarColor.WithValue(value))

    /// <summary>Sets the application RequestedThemeVariant.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">System bar color to be used for the application.</param>
    [<Extension>]
    static member inline requestedThemeVariant(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant) =
        this.AddScalar(Application.RequestedThemeVariant.WithValue(value))

    /// <summary>Listens to the application ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: 'msg) =
        this.AddScalar(Application.ActualThemeVariantChanged.WithValue(MsgValue fn))

    /// <summary>Listens to the application resources changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the resources change.</param>
    [<Extension>]
    static member inline onResourcesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: ResourcesChangedEventArgs -> 'msg) =
        this.AddScalar(Application.ResourcesChanged.WithValue(fn))

    /// <summary>Listens to the application urls opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the application receives urls to open.</param>
    [<Extension>]
    static member inline onUrlsOpened(this: WidgetBuilder<'msg, #IFabApplication>, fn: UrlOpenedEventArgs -> 'msg) =
        this.AddScalar(Application.UrlsOpened.WithValue(fn))

    /// <summary>Listens to the PlatformSettings color values changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when current system color values are changed. Including changing of a dark mode and accent colors.</param>
    [<Extension>]
    static member inline onColorValuesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.PlatformColorValues -> 'msg) =
        this.AddScalar(Application.ColorValuesChanged.WithValue(fn))

    /// <summary>Listens to the PlatformSettings safe area changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the safe area is changed.</param>
    [<Extension>]
    static member inline onSafeAreaChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.SafeAreaChangedArgs -> 'msg) =
        this.AddScalar(Application.SafeAreaChanged.WithValue(fn))

    /// <summary>Links a ViewRef to access the direct Application control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabApplication>, value: ViewRef<FabApplication>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ApplicationYieldExtensions =
    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>, x: WidgetBuilder<'msg, #IFabTrayIcon>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabTrayIcon>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type TrayIconAttachedModifiers =
    /// <summary>Sets the tray icons for the application.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline trayIcons<'msg, 'marker when 'marker :> IFabApplication>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTrayIcon>(this, Application.TrayIcons)

    /// <summary>Sets the tray icon for the application.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="trayIcon">The TrayIcon value</param>
    [<Extension>]
    static member inline trayIcon(this: WidgetBuilder<'msg, #IFabApplication>, trayIcon: WidgetBuilder<'msg, IFabTrayIcon>) =
        AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>(this, Application.TrayIcons) { trayIcon }
