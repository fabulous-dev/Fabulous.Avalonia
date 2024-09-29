namespace Fabulous.Avalonia

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media.Imaging
open Fabulous
open Avalonia.Controls

type IFabTrayIcon =
    inherit IFabElement

module TrayIcon =
    let WidgetKey = Widgets.register<TrayIcon>()

    let Menu = Attributes.defineAvaloniaPropertyWidget TrayIcon.MenuProperty

    let IconSource = Attributes.defineBindableWindowIconSource TrayIcon.IconProperty

    let ToolTipText =
        Attributes.defineAvaloniaPropertyWithEquality TrayIcon.ToolTipTextProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality TrayIcon.IsVisibleProperty

type TrayIconModifiers =
    /// <summary>Sets the Menu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Menu value.</param>
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabTrayIcon>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(TrayIcon.Menu.WithValue(value.Compile()))

    /// <summary>Sets the IsVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsVisible value.</param>
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabTrayIcon>, value: bool) =
        this.AddScalar(TrayIcon.IsVisible.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TrayIcon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTrayIcon>, value: ViewRef<TrayIcon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
