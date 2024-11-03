namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

#nowarn "0044" // Disable obsolete warnings in Fabulous.Avalonia. Please remove after deleting obsolete code.


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

type MvuTrayIconAttachedModifiers =
    /// <summary>Sets the tray icons for the application.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline trayIcons<'msg, 'marker when 'msg: equality and 'marker :> IFabApplication>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTrayIcon>(this, MvuApplication.TrayIcons)

    /// <summary>Sets the tray icon for the application.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="trayIcon">The TrayIcon value</param>
    [<Extension>]
    static member inline trayIcon(this: WidgetBuilder<'msg, #IFabApplication>, trayIcon: WidgetBuilder<'msg, #IFabTrayIcon>) =
        AttributeCollectionBuilder<'msg, #IFabApplication, IFabTrayIcon>(this, MvuApplication.TrayIcons) { trayIcon }
