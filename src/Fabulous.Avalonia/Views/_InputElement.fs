namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Avalonia.Input.GestureRecognizers
open Avalonia.Input.TextInput
open Avalonia.Interactivity
open Fabulous
open Fabulous.StackAllocatedCollections

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

    let GestureRecognizers =
        Attributes.defineSimpleScalarWithEquality<IGestureRecognizer seq> "InputElement_GestureRecognizers" (fun _ newValueOpt node ->
            let target = node.Target :?> InputElement

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome gestures ->
                for gesture in gestures do
                    target.GestureRecognizers.Add(gesture))

    let GotFocus =
        Attributes.defineEvent<GotFocusEventArgs> "InputElement_GotFocus" (fun target -> (target :?> InputElement).GotFocus)

    let LostFocus =
        Attributes.defineEvent<RoutedEventArgs> "InputElement_LostFocus" (fun target -> (target :?> InputElement).LostFocus)

    let KeyDown =
        Attributes.defineEvent<KeyEventArgs> "InputElement_KeyDown" (fun target -> (target :?> InputElement).KeyDown)

    let KeyUp =
        Attributes.defineEvent<KeyEventArgs> "InputElement_KeyUp" (fun target -> (target :?> InputElement).KeyUp)

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

    let DoubleTapped =
        Attributes.defineEvent<TappedEventArgs> "InputElement_DoubleTapped" (fun target -> (target :?> InputElement).DoubleTapped)

[<Extension>]
type InputElementModifiers =
    /// <summary>Set the Focusable property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline focusable(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.Focusable.WithValue(value))

    /// <summary>Set the IsEnabled property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsEnabled.WithValue(value))

    /// <summary>Set the IsEffectivelyEnabled property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isEffectivelyEnabled(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsEffectivelyEnabled.WithValue(value))

    /// <summary>Set the Cursor property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline cursor(this: WidgetBuilder<'msg, #IFabInputElement>, value: Cursor) =
        this.AddScalar(InputElement.Cursor.WithValue(value))

    /// <summary>Set the IsKeyboardFocusWithin property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isKeyboardFocusWithin(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsKeyboardFocusWithin.WithValue(value))

    /// <summary>Set the IsFocused property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isFocused(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsFocused.WithValue(value))

    /// <summary>Set the IsHitTestVisible property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isHitTestVisible(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsHitTestVisible.WithValue(value))

    /// <summary>Set the IsPointerOver property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isPointerOver(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsPointerOver.WithValue(value))

    /// <summary>Set the IsTabStop property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline isTabStop(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsTabStop.WithValue(value))

    /// <summary>Set the TabIndex property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline tabIndex(this: WidgetBuilder<'msg, #IFabInputElement>, value: int) =
        this.AddScalar(InputElement.TabIndex.WithValue(value))

    /// <summary>Listen to the GotFocus event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onGotFocus(this: WidgetBuilder<'msg, #IFabInputElement>, fn: GotFocusEventArgs -> 'msg) =
        this.AddScalar(InputElement.GotFocus.WithValue(fun args -> fn args |> box))
    
    [<Extension>]
    static member inline gestureRecognizers(this: WidgetBuilder<'msg, #IFabInputElement>, value: IGestureRecognizer seq) =
        this.AddScalar(InputElement.GestureRecognizers.WithValue(value))

    /// <summary>Listen to the LostFocus event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onLostFocus(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.LostFocus.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the KeyDown event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onKeyDown(this: WidgetBuilder<'msg, #IFabInputElement>, fn: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyDown.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the KeyUp event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onKeyUp(this: WidgetBuilder<'msg, #IFabInputElement>, fn: KeyEventArgs -> 'msg) =
        this.AddScalar(InputElement.KeyUp.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the TextInputMethodClientRequested event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onTextInputMethodClientRequested(this: WidgetBuilder<'msg, #IFabInputElement>, fn: TextInputMethodClientRequestedEventArgs -> 'msg) =
        this.AddScalar(InputElement.TextInputMethodClientRequested.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the PointerEntered event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onPointerEnter(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerEntered.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the PointerExited event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onPointerExited(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerExited.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the PointerMoved event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onPointerMoved(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerMoved.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the PointerPressed event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onPointerPressed(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerPressedEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerPressed.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the PointerReleased event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onPointerReleased(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerReleasedEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerReleased.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the PointerCaptureLost event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onPointerCaptureLost(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerCaptureLostEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerCaptureLost.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the PointerWheelChanged event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onPointerWheelChanged(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerWheelEventArgs -> 'msg) =
        this.AddScalar(InputElement.PointerWheelChanged.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the Tapped event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onTapped(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.Tapped.WithValue(fun args -> fn args |> box))

    /// <summary>Listen to the DoubleTapped event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be called when the event is raised</param>
    [<Extension>]
    static member inline onDoubleTapped(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(InputElement.DoubleTapped.WithValue(fun args -> fn args |> box))
