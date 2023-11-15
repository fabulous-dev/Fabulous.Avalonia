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

type InputElementModifiers =
    /// <summary>Sets the Focusable property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Focusable value.</param>
    [<Extension>]
    static member inline focusable(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.Focusable.WithValue(value))

    /// <summary>Sets the IsEnabled property..</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsEnabled value.</param>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsEnabled.WithValue(value))

    /// <summary>Sets the Cursor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Cursor value.</param>
    [<Extension>]
    static member inline cursor(this: WidgetBuilder<'msg, #IFabInputElement>, value: Cursor) =
        this.AddScalar(InputElement.Cursor.WithValue(value))

    /// <summary>Sets the IsHitTestVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsHitTestVisible value.</param>
    [<Extension>]
    static member inline isHitTestVisible(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsHitTestVisible.WithValue(value))

    /// <summary>Sets the IsTabStop property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTabStop value.</param>
    [<Extension>]
    static member inline isTabStop(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsTabStop.WithValue(value))

    /// <summary>Sets the TabIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TabIndex value.</param>
    [<Extension>]
    static member inline tabIndex(this: WidgetBuilder<'msg, #IFabInputElement>, value: int) =
        this.AddScalar(InputElement.TabIndex.WithValue(value))

    /// <summary>Listens to the InputElement GotFocus event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when control receives focus.</param>
    [<Extension>]
    static member inline onGotFocus(this: WidgetBuilder<'msg, #IFabInputElement>, fn: GotFocusEventArgs -> 'msg) =
        this.AddScalar(InputElement.GotFocus.WithValue(fn))

    /// <summary>Listens to the InputElement LostFocus event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when control loses focus.</param>
    [<Extension>]
    static member inline onLostFocus(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.LostFocus.WithValue(fn))

    /// <summary>Listens to the InputElement KeyDown event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a key is pressed while the control has focus.</param>
    [<Extension>]
    static member inline onKeyDown(this: WidgetBuilder<'msg, #IFabInputElement>, fn: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyDown.WithValue(fn))

    /// <summary>Listens to the InputElement KeyUp event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a key is released while the control has focus.</param>
    [<Extension>]
    static member inline onKeyUp(this: WidgetBuilder<'msg, #IFabInputElement>, fn: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyUp.WithValue(fn))

    /// <summary>Listens to the InputElement TextInput event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a user typed some text while the control has focus.</param>
    [<Extension>]
    static member inline onTextInput(this: WidgetBuilder<'msg, #IFabInputElement>, fn: TextInputEventArgs -> 'msg) =
        this.AddScalar(InputElement.TextInput.WithValue(fn))

    /// <summary>Listens to the InputElement TextInputMethodClientRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when an input element gains input focus and input method is looking for the corresponding client.</param>
    [<Extension>]
    static member inline onTextInputMethodClientRequested(this: WidgetBuilder<'msg, #IFabInputElement>, fn: TextInputMethodClientRequestedEventArgs -> 'msg) =
        this.AddScalar(InputElement.TextInputMethodClientRequested.WithValue(fn))

    /// <summary>Listens to the InputElement PointerEntered event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when pointer enters the control.</param>
    [<Extension>]
    static member inline onPointerEntered(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerEntered.WithValue(fn))

    /// <summary>Listens to the InputElement PointerExited event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when pointer leaves the control.</param>
    [<Extension>]
    static member inline onPointerExited(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerExited.WithValue(fn))

    /// <summary>Listens to the InputElement PointerMoved event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when pointer moves over the control.</param>
    [<Extension>]
    static member inline onPointerMoved(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerMoved.WithValue(fn))

    /// <summary>Listens to the InputElement PointerPressed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the pointer is pressed over the control.</param>
    [<Extension>]
    static member inline onPointerPressed(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerPressedEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerPressed.WithValue(fn))

    /// <summary>Listens to the InputElement PointerReleased event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the pointer is released over the control.</param>
    [<Extension>]
    static member inline onPointerReleased(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerReleasedEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerReleased.WithValue(fn))

    /// <summary>Listens to the InputElement PointerCaptureLost event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when he control or its child control loses the pointer capture for any reason event will not be triggered for a parent control if capture was transferred to another child of that parent control.</param>
    [<Extension>]
    static member inline onPointerCaptureLost(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerCaptureLostEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerCaptureLost.WithValue(fn))

    /// <summary>Listens to the InputElement PointerWheelChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the pointer wheel changes.</param>
    [<Extension>]
    static member inline onPointerWheelChanged(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerWheelEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerWheelChanged.WithValue(fn))

    /// <summary>Listens to the InputElement Tapped event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a tap gesture occurs on the control.</param>
    [<Extension>]
    static member inline onTapped(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.Tapped.WithValue(fn))

    /// <summary>Listens to the InputElement Holding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a holding gesture occurs on the control.</param>
    [<Extension>]
    static member inline onHolding(this: WidgetBuilder<'msg, #IFabInputElement>, fn: HoldingRoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.Holding.WithValue(fn))

    /// <summary>Listens to the InputElement RightTapped event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a double-tap gesture occurs on the control.</param>
    [<Extension>]
    static member inline onDoubleTapped(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.DoubleTapped.WithValue(fn))
