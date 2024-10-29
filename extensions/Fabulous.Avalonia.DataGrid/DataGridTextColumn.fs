namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabDataGridTextColumn =
    inherit IFabDataGridColumn

module DataGridTextColumn =
    let WidgetKey = Widgets.register<DataGridTextColumn>()

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontStretchProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.ForegroundProperty

    let ForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget DataGridTextColumn.ForegroundProperty

type DataGridTextColumnModifiers =
    /// <summary>Link a ViewRef to access the direct DataGridTextColumn control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: ViewRef<DataGridTextColumn>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the FontFamily property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontFamily property value.</param>
    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontFamily) =
        this.AddScalar(DataGridTextColumn.FontFamily.WithValue(value))

    /// <summary>Set the FontSize property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontSize property value.</param>
    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: float) =
        this.AddScalar(DataGridTextColumn.FontSize.WithValue(value))

    /// <summary>Set the FontStyle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStyle property value.</param>
    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontStyle) =
        this.AddScalar(DataGridTextColumn.FontStyle.WithValue(value))

    /// <summary>Set the FontWeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontWeight property value.</param>
    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontWeight) =
        this.AddScalar(DataGridTextColumn.FontWeight.WithValue(value))

    /// <summary>Set the FontStretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStretch property value.</param>
    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabDataGridTextColumn>, value: FontStretch) =
        this.AddScalar(DataGridTextColumn.FontStretch.WithValue(value))
