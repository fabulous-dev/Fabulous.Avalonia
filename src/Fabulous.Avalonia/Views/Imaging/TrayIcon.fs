namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Fabulous
open Avalonia.Controls
open Fabulous.StackAllocatedCollections

type IFabTrayIcon =
    inherit IFabObject

module TrayIcon =
    let WidgetKey = Widgets.register<TrayIcon>()

    let Menu = Attributes.defineAvaloniaPropertyWidget TrayIcon.MenuProperty

    let Icon = Attributes.defineAvaloniaPropertyWithEquality TrayIcon.IconProperty

    let ToolTipText =
        Attributes.defineAvaloniaPropertyWithEquality TrayIcon.ToolTipTextProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality TrayIcon.IsVisibleProperty

    let Clicked =
        Attributes.defineEventNoArg "TrayIcon_Clicked" (fun target -> (target :?> TrayIcon).Clicked)

module TrayIconAttached =
    let TrayIcons =
        Attributes.defineAvaloniaListWidgetCollection "TrayIcon_TrayIcons" (fun target ->
            let target = target :?> Application
            let trayIcons = TrayIcon.GetIcons(target)

            if trayIcons = null then
                let trayIcons = TrayIcons()
                TrayIcon.SetIcons(target, trayIcons)
                trayIcons
            else
                trayIcons)

[<AutoOpen>]
module TrayIconBuilders =
    type Fabulous.Avalonia.View with

        static member inline TrayIcon(icon: WindowIcon) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.Icon.WithValue(icon))

        static member inline TrayIcon(icon: WindowIcon, tooltipText: string) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.Icon.WithValue(icon), TrayIcon.ToolTipText.WithValue(tooltipText))

[<Extension>]
type TrayIconModifiers =
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabTrayIcon>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(TrayIcon.Menu.WithValue(value.Compile()))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabTrayIcon>, value: bool) =
        this.AddScalar(TrayIcon.IsVisible.WithValue(value))

    [<Extension>]
    static member inline onClicked(this: WidgetBuilder<'msg, #IFabTrayIcon>, msg: 'msg) =
        this.AddScalar(TrayIcon.Clicked.WithValue(msg))
