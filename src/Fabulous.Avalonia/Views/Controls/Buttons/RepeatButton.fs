namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabRepeatButton =
    inherit IFabButton

module RepeatButton =
    let WidgetKey = Widgets.register<RepeatButton>()

    let Delay = Attributes.defineAvaloniaPropertyWithEquality RepeatButton.DelayProperty

    let Interval =
        Attributes.defineAvaloniaPropertyWithEquality RepeatButton.IntervalProperty

[<AutoOpen>]
module RepeatButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline RepeatButton<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabRepeatButton>(
                RepeatButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Button.Clicked.WithValue(fun _ -> box onClicked)
            )

        static member inline RepeatButton(onClicked: 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRepeatButton>(
                RepeatButton.WidgetKey,
                AttributesBundle(
                    StackList.one(Button.Clicked.WithValue(fun _ -> box onClicked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type RepeatButtonModifiers =
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabRepeatButton>, value: int) =
        this.AddScalar(RepeatButton.Delay.WithValue(value))

    [<Extension>]
    static member inline interval(this: WidgetBuilder<'msg, #IFabRepeatButton>, value: int) =
        this.AddScalar(RepeatButton.Interval.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RepeatButton control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRepeatButton>, value: ViewRef<RepeatButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
