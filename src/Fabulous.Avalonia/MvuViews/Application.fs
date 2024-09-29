namespace Fabulous.Avalonia.Mvu

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

type IFabMvuApplication =
    inherit IFabMvuElement
    inherit IFabApplication

module MvuApplication =
    let TrayIcons =
        MvuAttributes.defineAvaloniaListWidgetCollection "TrayIcon_TrayIcons" (fun target ->
            let target = target :?> FabApplication
            let trayIcons = TrayIcon.GetIcons(target)

            if trayIcons = null then
                let trayIcons = TrayIcons()
                TrayIcon.SetIcons(target, trayIcons)
                trayIcons
            else
                trayIcons)
    let ActualThemeVariantChanged =
        MvuAttributes.defineEventNoArg "Application_ActualThemeVariantChanged" (fun target -> (target :?> FabApplication).ActualThemeVariantChanged)

    let ResourcesChanged =
        MvuAttributes.defineEvent "Application_ResourcesChangedEvent" (fun target -> (target :?> FabApplication).ResourcesChanged)

    let UrlsOpened =
        MvuAttributes.defineEvent "Application_UrlsOpenedEvent" (fun target -> (target :?> FabApplication).UrlsOpened)

    let ColorValuesChanged =
        MvuAttributes.defineEvent "PlatformSettings_ColorValuesChanged" (fun target ->
            (target :?> FabApplication)
                .PlatformSettings.ColorValuesChanged)

    let SafeAreaChanged =
        MvuAttributes.defineEvent "PlatformSettings_SafeAreaChanged" (fun target -> (target :?> FabApplication).InsetsManager.SafeAreaChanged)

[<AutoOpen>]
module MvuApplicationBuilders =
    type Fabulous.Avalonia.Mvu.View with

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

type MvuApplicationModifiers =
    /// <summary>Listens to the application ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: 'msg) =
        this.AddScalar(MvuApplication.ActualThemeVariantChanged.WithValue(MsgValue fn))

    /// <summary>Listens to the application resources changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the resources change.</param>
    [<Extension>]
    static member inline onResourcesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: ResourcesChangedEventArgs -> 'msg) =
        this.AddScalar(MvuApplication.ResourcesChanged.WithValue(fn))

    /// <summary>Listens to the application urls opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the application receives urls to open.</param>
    [<Extension>]
    static member inline onUrlsOpened(this: WidgetBuilder<'msg, #IFabApplication>, fn: UrlOpenedEventArgs -> 'msg) =
        this.AddScalar(MvuApplication.UrlsOpened.WithValue(fn))

    /// <summary>Listens to the PlatformSettings color values changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when current system color values are changed. Including changing of a dark mode and accent colors.</param>
    [<Extension>]
    static member inline onColorValuesChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.PlatformColorValues -> 'msg) =
        this.AddScalar(MvuApplication.ColorValuesChanged.WithValue(fn))

    /// <summary>Listens to the PlatformSettings safe area changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the safe area is changed.</param>
    [<Extension>]
    static member inline onSafeAreaChanged(this: WidgetBuilder<'msg, #IFabApplication>, fn: Platform.SafeAreaChangedArgs -> 'msg) =
        this.AddScalar(MvuApplication.SafeAreaChanged.WithValue(fn))

    /// <summary>Links a ViewRef to access the direct Application control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabApplication>, value: ViewRef<FabApplication>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type MvuApplicationYieldExtensions =
    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>, x: WidgetBuilder<'msg, #IFabTrayIcon>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabTrayIcon>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type MvuTrayIconAttachedModifiers =
    /// <summary>Sets the tray icons for the application.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline trayIcons<'msg, 'marker when 'marker :> IFabApplication>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTrayIcon>(this, MvuApplication.TrayIcons)

    /// <summary>Sets the tray icon for the application.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="trayIcon">The TrayIcon value</param>
    [<Extension>]
    static member inline trayIcon(this: WidgetBuilder<'msg, #IFabApplication>, trayIcon: WidgetBuilder<'msg, IFabTrayIcon>) =
        AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>(this, MvuApplication.TrayIcons) { trayIcon }
