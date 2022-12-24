namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabRepeatButton =
    inherit IFabButton

module RepeatButton =
    let WidgetKey = Widgets.register<RepeatButton> ()

    let Delay = Attributes.defineAvaloniaPropertyWithEquality RepeatButton.DelayProperty

    let Interval =
        Attributes.defineAvaloniaPropertyWithEquality RepeatButton.IntervalProperty

[<AutoOpen>]
module RepeatButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline RepeatButton(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabRepeatButton>(
                RepeatButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Button.Clicked.WithValue(fun _ -> box onClicked)
            )

[<Extension>]
type RepeatButtonModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabRepeatButton>, value: int) =
        this.AddScalar(RepeatButton.Delay.WithValue(value))

    [<Extension>]
    static member inline interval(this: WidgetBuilder<'msg, #IFabRepeatButton>, value: int) =
        this.AddScalar(RepeatButton.Interval.WithValue(value))
