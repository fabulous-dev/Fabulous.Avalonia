namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabButton =
    inherit IFabContentControl

module Button =
    let WidgetKey = Widgets.register<Button> ()

    let ClickMode =
        Attributes.defineAvaloniaPropertyWithEquality Button.ClickModeProperty

    let Clicked =
        Attributes.defineEvent "Button_Clicked" (fun target -> (target :?> Button).Click)

    let HotKey = Attributes.defineAvaloniaPropertyWithEquality Button.HotKeyProperty

    let IsDefault =
        Attributes.defineAvaloniaPropertyWithEquality Button.IsDefaultProperty

    let IsCancel = Attributes.defineAvaloniaPropertyWithEquality Button.IsCancelProperty

    let IsPressed =
        Attributes.defineAvaloniaPropertyWithEquality Button.IsPressedProperty

    let Flyout = Attributes.defineAvaloniaPropertyWidget Button.FlyoutProperty

[<AutoOpen>]
module ButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline Button(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabButton>(
                Button.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Button.Clicked.WithValue(fun _ -> box onClicked)
            )

        static member inline Button(content: WidgetBuilder<'msg, #IFabControl>, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabButton>(
                Button.WidgetKey,
                AttributesBundle(
                    StackList.one (Button.Clicked.WithValue(fun _ -> box onClicked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )

            )

[<Extension>]
type ButtonModifiers =
    [<Extension>]
    static member inline clickMode(this: WidgetBuilder<'msg, #IFabButton>, clickMode: ClickMode) =
        this.AddScalar(Button.ClickMode.WithValue(clickMode))

    [<Extension>]
    static member inline hotKey(this: WidgetBuilder<'msg, #IFabButton>, value: KeyGesture) =
        this.AddScalar(Button.HotKey.WithValue(value))

    [<Extension>]
    static member inline isDefault(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(Button.IsDefault.WithValue(value))

    [<Extension>]
    static member inline isCancel(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(Button.IsCancel.WithValue(value))

    [<Extension>]
    static member inline isPressed(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(Button.IsPressed.WithValue(value))

    [<Extension>]
    static member inline flyout(this: WidgetBuilder<'msg, #IFabButton>, content: WidgetBuilder<'msg, IFabFlyoutBase>) =
        this.AddWidget(Button.Flyout.WithValue(content.Compile()))
