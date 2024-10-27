namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabToggleSwitch =
    inherit IFabToggleButton

module ToggleSwitch =
    let WidgetKey = Widgets.register<ToggleSwitch>()

    let OffContent =
        Attributes.defineAvaloniaProperty<string, obj> ToggleSwitch.OffContentProperty box ScalarAttributeComparers.equalityCompare

    let OffContentWidget =
        Attributes.defineAvaloniaPropertyWidget ToggleSwitch.OffContentProperty

    let OnContent =
        Attributes.defineAvaloniaProperty<string, obj> ToggleSwitch.OnContentProperty box ScalarAttributeComparers.equalityCompare

    let OnContentWidget =
        Attributes.defineAvaloniaPropertyWidget ToggleSwitch.OnContentProperty


type ToggleSwitchModifiers =
    /// <summary>Sets the OffContent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OffContent value.</param>
    [<Extension>]
    static member inline offContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: string) =
        this.AddScalar(ToggleSwitch.OffContent.WithValue(value))

    /// <summary>Sets the OffContent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OffContent value.</param>
    [<Extension>]
    static member inline offContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(ToggleSwitch.OffContentWidget.WithValue(value.Compile()))

    /// <summary>Sets the OnContent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OnContent value.</param>
    [<Extension>]
    static member inline onContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: string) =
        this.AddScalar(ToggleSwitch.OnContent.WithValue(value))

    /// <summary>Sets the OnContent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OnContent value.</param>
    [<Extension>]
    static member inline onContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(ToggleSwitch.OnContentWidget.WithValue(value.Compile()))

    /// <summary>Sets the Content property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Content value.</param>
    [<Extension>]
    static member inline content(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: string) =
        this.AddScalar(ContentControl.ContentString.WithValue(value))

    /// <summary>Sets the Content property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Content value.</param>
    [<Extension>]
    static member inline content(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(ContentControl.ContentWidget.WithValue(value.Compile()))

    /// <summary>Link a ViewRef to access the direct ToggleSwitch control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToggleSwitch>, value: ViewRef<ToggleSwitch>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
