namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Avalonia.Input.TextInput
open Avalonia.Interactivity
open Fabulous

type IFabInputElement =
    inherit IFabInteractive

module InputElement =

    let Focusable =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.FocusableProperty

    let IsEnabled =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsEnabledProperty

    let Cursor =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.CursorProperty

    let IsHitTestVisible =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsHitTestVisibleProperty

    let IsTabStop =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsTabStopProperty

    let TabIndex =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.TabIndexProperty

    let GotFocus =
        Attributes.defineEvent<GotFocusEventArgs> "InputElement_GotFocus" (fun target -> (target :?> InputElement).GotFocus)

    let LostFocus =
        Attributes.defineEvent<RoutedEventArgs> "InputElement_LostFocus" (fun target -> (target :?> InputElement).LostFocus)

    let KeyDown =
        Attributes.defineEvent<KeyEventArgs> "InputElement_KeyDown" (fun target -> (target :?> InputElement).KeyDown)

    let KeyUp =
        Attributes.defineEvent<KeyEventArgs> "InputElement_KeyUp" (fun target -> (target :?> InputElement).KeyUp)

    let TextInput =
        Attributes.defineEvent<TextInputEventArgs> "InputElement_TextInput" (fun target -> (target :?> InputElement).TextInput)

    let TextInputMethodClientRequested =
        Attributes.defineEvent<TextInputMethodClientRequestedEventArgs> "InputElement_TextInputMethodClientRequested" (fun target ->
            (target :?> InputElement).TextInputMethodClientRequested)

    let PointerEntered =
        Attributes.defineEvent<PointerEventArgs> "InputElement_PointerEntered" (fun target -> (target :?> InputElement).PointerEntered)

    let PointerExited =
        Attributes.defineEvent<PointerEventArgs> "InputElement_PointerExited" (fun target -> (target :?> InputElement).PointerExited)

    let PointerMoved =
        Attributes.defineEvent<PointerEventArgs> "InputElement_PointerMoved" (fun target -> (target :?> InputElement).PointerMoved)

    let PointerPressed =
        Attributes.defineEvent<PointerPressedEventArgs> "InputElement_PointerPressed" (fun target -> (target :?> InputElement).PointerPressed)

    let PointerReleased =
        Attributes.defineEvent<PointerReleasedEventArgs> "InputElement_PointerReleased" (fun target -> (target :?> InputElement).PointerReleased)

    let PointerCaptureLost =
        Attributes.defineEvent<PointerCaptureLostEventArgs> "InputElement_PointerCaptureLost" (fun target -> (target :?> InputElement).PointerCaptureLost)

    let PointerWheelChanged =
        Attributes.defineEvent<PointerWheelEventArgs> "InputElement_PointerWheelChanged" (fun target -> (target :?> InputElement).PointerWheelChanged)

    let Tapped =
        Attributes.defineEvent<TappedEventArgs> "InputElement_Tapped" (fun target -> (target :?> InputElement).Tapped)

    let Holding =
        Attributes.defineEvent<HoldingRoutedEventArgs> "InputElement_Holding" (fun target -> (target :?> InputElement).Holding)

    let DoubleTapped =
        Attributes.defineEvent<TappedEventArgs> "InputElement_DoubleTapped" (fun target -> (target :?> InputElement).DoubleTapped)

[<Extension>]
type InputElementModifiers =
    [<Extension>]
    static member inline focusable(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.Focusable.WithValue(value))

    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsEnabled.WithValue(value))

    [<Extension>]
    static member inline cursor(this: WidgetBuilder<'msg, #IFabInputElement>, value: Cursor) =
        this.AddScalar(InputElement.Cursor.WithValue(value))

    [<Extension>]
    static member inline isHitTestVisible(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsHitTestVisible.WithValue(value))

    [<Extension>]
    static member inline isTabStop(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsTabStop.WithValue(value))

    [<Extension>]
    static member inline tabIndex(this: WidgetBuilder<'msg, #IFabInputElement>, value: int) =
        this.AddScalar(InputElement.TabIndex.WithValue(value))

    [<Extension>]
    static member inline onGotFocus(this: WidgetBuilder<'msg, #IFabInputElement>, onGotFocus: GotFocusEventArgs -> 'msg) =
        this.AddScalar(InputElement.GotFocus.WithValue(fun args -> onGotFocus args |> box))

    [<Extension>]
    static member inline onLostFocus(this: WidgetBuilder<'msg, #IFabInputElement>, onLostFocus: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.LostFocus.WithValue(fun args -> onLostFocus args |> box))

    [<Extension>]
    static member inline onKeyDown(this: WidgetBuilder<'msg, #IFabInputElement>, onKeyDown: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyDown.WithValue(fun args -> onKeyDown args |> box))

    [<Extension>]
    static member inline onKeyUp(this: WidgetBuilder<'msg, #IFabInputElement>, onKeyUp: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyUp.WithValue(fun args -> onKeyUp args |> box))

    [<Extension>]
    static member inline onTextInput(this: WidgetBuilder<'msg, #IFabInputElement>, onTextInput: TextInputEventArgs -> 'msg) =
        this.AddScalar(InputElement.TextInput.WithValue(fun args -> onTextInput args |> box))

    [<Extension>]
    static member inline onTextInputMethodClientRequested
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onTextInputMethodClientRequested: TextInputMethodClientRequestedEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.TextInputMethodClientRequested.WithValue(fun args -> onTextInputMethodClientRequested args |> box))

    [<Extension>]
    static member inline onPointerEnter(this: WidgetBuilder<'msg, #IFabInputElement>, onPointerEnter: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerEntered.WithValue(fun args -> onPointerEnter args |> box))

    [<Extension>]
    static member inline onPointerExited(this: WidgetBuilder<'msg, #IFabInputElement>, onPointerExited: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerExited.WithValue(fun args -> onPointerExited args |> box))

    [<Extension>]
    static member inline onPointerMoved(this: WidgetBuilder<'msg, #IFabInputElement>, onPointerMoved: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerMoved.WithValue(fun args -> onPointerMoved args |> box))

    [<Extension>]
    static member inline onPointerPressed(this: WidgetBuilder<'msg, #IFabInputElement>, onPointerPressed: PointerPressedEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerPressed.WithValue(fun args -> onPointerPressed args |> box))

    [<Extension>]
    static member inline onPointerReleased(this: WidgetBuilder<'msg, #IFabInputElement>, onPointerReleased: PointerReleasedEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerReleased.WithValue(fun args -> onPointerReleased args |> box))

    [<Extension>]
    static member inline onPointerCaptureLost(this: WidgetBuilder<'msg, #IFabInputElement>, onPointerCaptureLost: PointerCaptureLostEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerCaptureLost.WithValue(fun args -> onPointerCaptureLost args |> box))

    [<Extension>]
    static member inline onPointerWheelChanged(this: WidgetBuilder<'msg, #IFabInputElement>, onPointerWheelChanged: PointerWheelEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerWheelChanged.WithValue(fun args -> onPointerWheelChanged args |> box))

    [<Extension>]
    static member inline onTapped(this: WidgetBuilder<'msg, #IFabInputElement>, onTapped: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.Tapped.WithValue(fun args -> onTapped args |> box))

    [<Extension>]
    static member inline onHolding(this: WidgetBuilder<'msg, #IFabInputElement>, onHolding: HoldingRoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.Holding.WithValue(fun args -> onHolding args |> box))

    [<Extension>]
    static member inline onDoubleTapped(this: WidgetBuilder<'msg, #IFabInputElement>, onDoubleTapped: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.DoubleTapped.WithValue(fun args -> onDoubleTapped args |> box))
