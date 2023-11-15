namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabButton =
    inherit IFabContentControl

module Button =
    let WidgetKey = Widgets.register<Button>()

    let ClickMode =
        Attributes.defineAvaloniaPropertyWithEquality Button.ClickModeProperty

    let Clicked =
        Attributes.defineEvent "Button_Clicked" (fun target -> (target :?> Button).Click)

    let HotKey = Attributes.defineAvaloniaPropertyWithEquality Button.HotKeyProperty

    let IsDefault =
        Attributes.defineAvaloniaPropertyWithEquality Button.IsDefaultProperty

    let IsCancel = Attributes.defineAvaloniaPropertyWithEquality Button.IsCancelProperty

    let Flyout = Attributes.defineAvaloniaPropertyWidget Button.FlyoutProperty

[<AutoOpen>]
module ButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Button widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the button is clicked.</param>
        static member inline Button<'msg>(text: string, fn: 'msg) =
            WidgetBuilder<'msg, IFabButton>(Button.WidgetKey, ContentControl.ContentString.WithValue(text), Button.Clicked.WithValue(fun _ -> box fn))

        /// <summary>Creates a Button widget.</summary>
        /// <param name="fn">Raised when the button is clicked.</param>
        /// <param name="content">The content to display.</param>
        static member inline Button(fn: 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabButton>(
                Button.WidgetKey,
                AttributesBundle(
                    StackList.one(Button.Clicked.WithValue(fun _ -> box fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )

            )

type ButtonModifiers =
    /// <summary>Sets the ClickMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClickMode value.</param>
    [<Extension>]
    static member inline clickMode(this: WidgetBuilder<'msg, #IFabButton>, value: ClickMode) =
        this.AddScalar(Button.ClickMode.WithValue(value))

    /// <summary>Sets the HotKey property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HotKey value.</param>
    [<Extension>]
    static member inline hotKey(this: WidgetBuilder<'msg, #IFabButton>, value: KeyGesture) =
        this.AddScalar(Button.HotKey.WithValue(value))

    /// <summary>Sets the IsDefault property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDefault value.</param>
    [<Extension>]
    static member inline isDefault(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(Button.IsDefault.WithValue(value))

    /// <summary>Sets the IsCancel property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsCancel value.</param>
    [<Extension>]
    static member inline isCancel(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(Button.IsCancel.WithValue(value))

    /// <summary>Sets the Flyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Flyout value.</param>
    [<Extension>]
    static member inline flyout(this: WidgetBuilder<'msg, #IFabButton>, value: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(Button.Flyout.WithValue(value.Compile()))

    /// <summary>Link a ViewRef to access the direct Button control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabButton>, value: ViewRef<Button>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
