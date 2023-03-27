namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open System.Runtime.CompilerServices

open Fabulous

type IFabProgressBar =
    inherit IFabRangeBase

module ProgressBar =
    let WidgetKey = Widgets.register<ProgressBar>()

    let IndeterminateEndingOffset =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.IndeterminateEndingOffsetProperty

    let IndeterminateStartingOffset =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.IndeterminateStartingOffsetProperty

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
                RangeBase.MinimumMaximum.WithValue(min, max),
                RangeBase.Value.WithValue(value),
                RangeBase.ValueChanged.WithValue(ValueEventData.create value (fun args -> onValueChanged args |> box))
            )

[<Extension>]
type ProgressBarModifiers =

    [<Extension>]
    static member inline indeterminateEndingOffset(this: WidgetBuilder<'msg, #IFabProgressBar>, value: float) =
        this.AddScalar(ProgressBar.IndeterminateEndingOffset.WithValue(value))

    [<Extension>]
    static member inline indeterminateStartingOffset(this: WidgetBuilder<'msg, #IFabProgressBar>, value: float) =
        this.AddScalar(ProgressBar.IndeterminateStartingOffset.WithValue(value))

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
