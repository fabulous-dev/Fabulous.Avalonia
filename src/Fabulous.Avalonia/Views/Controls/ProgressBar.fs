namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open System.Runtime.CompilerServices

open Fabulous

type IFabProgressBar =
    inherit IFabRangeBase

module ProgressBar =
    let WidgetKey = Widgets.register<ProgressBar>()

    let IsIndeterminate =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.IsIndeterminateProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.OrientationProperty

    let Percentage =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.PercentageProperty

    let ProgressTextFormat =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.ProgressTextFormatProperty

    let ShowProgressText =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.ShowProgressTextProperty

[<AutoOpen>]
module ProgressBarBuilders =
    type Fabulous.Avalonia.View with

        static member inline ProgressBar<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IFabProgressBar>(
                ProgressBar.WidgetKey,
                RangeBase.Value.WithValue(value),
                RangeBase.MinimumMaximum.WithValue(min, max),
                RangeBase.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box)
            )

[<Extension>]
type ProgressBarModifiers =
    [<Extension>]
    static member inline isIndeterminate(this: WidgetBuilder<'msg, #IFabProgressBar>, value: bool) =
        this.AddScalar(ProgressBar.IsIndeterminate.WithValue(value))

    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabProgressBar>, value: Orientation) =
        this.AddScalar(ProgressBar.Orientation.WithValue(value))

    [<Extension>]
    static member inline percentage(this: WidgetBuilder<'msg, #IFabProgressBar>, value: float) =
        this.AddScalar(ProgressBar.Percentage.WithValue(value))

    [<Extension>]
    static member inline progressTextFormat(this: WidgetBuilder<'msg, #IFabProgressBar>, value: string) =
        this.AddScalar(ProgressBar.ProgressTextFormat.WithValue(value))

    [<Extension>]
    static member inline showProgressText(this: WidgetBuilder<'msg, #IFabProgressBar>, value: bool) =
        this.AddScalar(ProgressBar.ShowProgressText.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ProgressBar control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabProgressBar>, value: ViewRef<ProgressBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
