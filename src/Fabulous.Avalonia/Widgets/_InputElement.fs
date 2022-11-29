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

    let IsEffectivelyEnabled =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsEffectivelyEnabledProperty

    let Cursor =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.CursorProperty

    let IsKeyboardFocusWithin =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsKeyboardFocusWithinProperty

    let IsFocused =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsFocusedProperty

    let IsHitTestVisible =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsHitTestVisibleProperty

    let IsPointerOver =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsPointerOverProperty

    let IsTabStop =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsTabStopProperty

    let TabIndex =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.TabIndexProperty

    let GotFocusEvent =
        Attributes.defineAvaloniaEvent<GotFocusEventArgs> "InputElement_GotFocusEvent" (fun target ->
            (target :?> InputElement).GotFocus)

    let LostFocusEvent =
        Attributes.defineAvaloniaEvent<RoutedEventArgs> "InputElement_LostFocusEvent" (fun target ->
            (target :?> InputElement).LostFocus)

    let KeyDownEvent =
        Attributes.defineAvaloniaEvent<KeyEventArgs> "InputElement_KeyDownEvent" (fun target ->
            (target :?> InputElement).KeyDown)

    let KeyUpEvent =
        Attributes.defineAvaloniaEvent<KeyEventArgs> "InputElement_KeyUpEvent" (fun target ->
            (target :?> InputElement).KeyUp)

    let TextInputEvent =
        Attributes.defineAvaloniaEvent<TextInputEventArgs> "InputElement_TextInputEvent" (fun target ->
            (target :?> InputElement).TextInput)


    let TextInputMethodClientRequestedEvent =
        Attributes.defineAvaloniaEvent<TextInputMethodClientRequestedEventArgs>
            "InputElement_TextInputMethodClientRequestedEvent"
            (fun target -> (target :?> InputElement).TextInputMethodClientRequested)


    let PointerEnteredEvent =
        Attributes.defineAvaloniaEvent<PointerEventArgs> "InputElement_PointerEnteredEvent" (fun target ->
            (target :?> InputElement).PointerEntered)

    let PointerExitedEvent =
        Attributes.defineAvaloniaEvent<PointerEventArgs> "InputElement_PointerExitedEvent" (fun target ->
            (target :?> InputElement).PointerExited)

    let PointerMovedEvent =
        Attributes.defineAvaloniaEvent<PointerEventArgs> "InputElement_PointerMovedEvent" (fun target ->
            (target :?> InputElement).PointerMoved)

    let PointerPressedEvent =
        Attributes.defineAvaloniaEvent<PointerPressedEventArgs> "InputElement_PointerPressedEvent" (fun target ->
            (target :?> InputElement).PointerPressed)

    let PointerReleasedEvent =
        Attributes.defineAvaloniaEvent<PointerReleasedEventArgs> "InputElement_PointerReleasedEvent" (fun target ->
            (target :?> InputElement).PointerReleased)

    let PointerCaptureLostEvent =
        Attributes.defineAvaloniaEvent<PointerCaptureLostEventArgs>
            "InputElement_PointerCaptureLostEvent"
            (fun target -> (target :?> InputElement).PointerCaptureLost)

    let PointerWheelChangedEvent =
        Attributes.defineAvaloniaEvent<PointerWheelEventArgs> "InputElement_PointerWheelChangedEvent" (fun target ->
            (target :?> InputElement).PointerWheelChanged)

    let TappedEvent =
        Attributes.defineAvaloniaEvent<TappedEventArgs> "InputElement_TappedEvent" (fun target ->
            (target :?> InputElement).Tapped)

    let DoubleTappedEvent =
        Attributes.defineAvaloniaEvent<TappedEventArgs> "InputElement_DoubleTappedEvent" (fun target ->
            (target :?> InputElement).DoubleTapped)

[<Extension>]
type InputElementModifiers =
    [<Extension>]
    static member inline focusable(this: WidgetBuilder<'msg, #IFabInputElement>, focusable: bool) =
        this.AddScalar(InputElement.Focusable.WithValue(focusable))

    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabInputElement>, isEnabled: bool) =
        this.AddScalar(InputElement.IsEnabled.WithValue(isEnabled))

    [<Extension>]
    static member inline isEffectivelyEnabled
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            isEffectivelyEnabled: bool
        ) =
        this.AddScalar(InputElement.IsEffectivelyEnabled.WithValue(isEffectivelyEnabled))

    [<Extension>]
    static member inline cursor(this: WidgetBuilder<'msg, #IFabInputElement>, cursor: Cursor) =
        this.AddScalar(InputElement.Cursor.WithValue(cursor))

    [<Extension>]
    static member inline isKeyboardFocusWithin
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            isKeyboardFocusWithin: bool
        ) =
        this.AddScalar(InputElement.IsKeyboardFocusWithin.WithValue(isKeyboardFocusWithin))

    [<Extension>]
    static member inline isFocused(this: WidgetBuilder<'msg, #IFabInputElement>, isFocused: bool) =
        this.AddScalar(InputElement.IsFocused.WithValue(isFocused))

    [<Extension>]
    static member inline isHitTestVisible(this: WidgetBuilder<'msg, #IFabInputElement>, isHitTestVisible: bool) =
        this.AddScalar(InputElement.IsHitTestVisible.WithValue(isHitTestVisible))

    [<Extension>]
    static member inline isPointerOver(this: WidgetBuilder<'msg, #IFabInputElement>, isPointerOver: bool) =
        this.AddScalar(InputElement.IsPointerOver.WithValue(isPointerOver))

    [<Extension>]
    static member inline isTabStop(this: WidgetBuilder<'msg, #IFabInputElement>, isTabStop: bool) =
        this.AddScalar(InputElement.IsTabStop.WithValue(isTabStop))

    [<Extension>]
    static member inline tabIndex(this: WidgetBuilder<'msg, #IFabInputElement>, tabIndex: int) =
        this.AddScalar(InputElement.TabIndex.WithValue(tabIndex))

    [<Extension>]
    static member inline onGotFocus
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onGotFocus: GotFocusEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.GotFocusEvent.WithValue(fun args -> onGotFocus args |> box))

    [<Extension>]
    static member inline onLostFocus
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onLostFocus: RoutedEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.LostFocusEvent.WithValue(fun args -> onLostFocus args |> box))

    [<Extension>]
    static member inline onKeyDown(this: WidgetBuilder<'msg, #IFabInputElement>, onKeyDown: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyDownEvent.WithValue(fun args -> onKeyDown args |> box))

    [<Extension>]
    static member inline onKeyUp(this: WidgetBuilder<'msg, #IFabInputElement>, onKeyUp: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyUpEvent.WithValue(fun args -> onKeyUp args |> box))

    [<Extension>]
    static member inline onTextInput
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onTextInput: string -> 'msg
        ) =
        this.AddScalar(InputElement.TextInputEvent.WithValue(fun args -> onTextInput args.Text |> box))

    [<Extension>]
    static member inline onTextInputMethodClientRequested
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onTextInputMethodClientRequested: TextInputMethodClientRequestedEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.TextInputMethodClientRequestedEvent.WithValue(fun args -> onTextInputMethodClientRequested args |> box))

    [<Extension>]
    static member inline onPointerEnter
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onPointerEnter: PointerEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.PointerEnteredEvent.WithValue(fun args -> onPointerEnter args |> box))

    [<Extension>]
    static member inline onPointerExited
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onPointerExited: PointerEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.PointerExitedEvent.WithValue(fun args -> onPointerExited args |> box))

    [<Extension>]
    static member inline onPointerMoved
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onPointerMoved: PointerEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.PointerMovedEvent.WithValue(fun args -> onPointerMoved args |> box))

    [<Extension>]
    static member inline onPointerPressed
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onPointerPressed: PointerPressedEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.PointerPressedEvent.WithValue(fun args -> onPointerPressed args |> box))

    [<Extension>]
    static member inline onPointerReleased
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onPointerReleased: PointerReleasedEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.PointerReleasedEvent.WithValue(fun args -> onPointerReleased args |> box))

    [<Extension>]
    static member inline onPointerCaptureLost
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onPointerCaptureLost: PointerCaptureLostEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.PointerCaptureLostEvent.WithValue(fun args -> onPointerCaptureLost args |> box))

    [<Extension>]
    static member inline onPointerWheelChanged
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onPointerWheelChanged: PointerWheelEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.PointerWheelChangedEvent.WithValue(fun args -> onPointerWheelChanged args |> box))

    [<Extension>]
    static member inline onTap(this: WidgetBuilder<'msg, #IFabInputElement>, onTap: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.TappedEvent.WithValue(fun args -> onTap args |> box))

    [<Extension>]
    static member inline onDoubleTap
        (
            this: WidgetBuilder<'msg, #IFabInputElement>,
            onDoubleTap: RoutedEventArgs -> 'msg
        ) =
        this.AddScalar(InputElement.DoubleTappedEvent.WithValue(fun args -> onDoubleTap args |> box))
