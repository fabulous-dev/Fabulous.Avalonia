namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous

type IFabControl =
    inherit IFabInputElement

module Control =

    let Tag =
        Attributes.defineAvaloniaProperty<string, obj> Control.TagProperty box ScalarAttributeComparers.equalityCompare

    let ContextMenu =
        Attributes.defineAvaloniaPropertyWidget Control.ContextMenuProperty

    let ContextFlyout =
        Attributes.defineAvaloniaPropertyWidget Control.ContextFlyoutProperty

    let FlowDirection =
        Attributes.defineAvaloniaPropertyWithEquality Control.FlowDirectionProperty

    let RequestBringIntoView =
        Attributes.defineRoutedEvent "Control_RequestBringIntoView" Control.RequestBringIntoViewEvent

    let ContextRequested =
        Attributes.defineEvent "Control_ContextRequested" (fun target -> (target :?> Control).ContextRequested)

    let Loaded =
        Attributes.defineEvent "Control_Loaded" (fun target -> (target :?> Control).Loaded)

    let UnLoaded =
        Attributes.defineEvent "Control_UnLoaded" (fun target -> (target :?> Control).Unloaded)

    let SizeChanged =
        Attributes.defineEvent "Control_SizeChanged" (fun target -> (target :?> Control).SizeChanged)

[<Extension>]
type ControlModifiers =
    /// <summary>Sets the ContextFlyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContextFlyout value</param>
    [<Extension>]
    static member inline contextFlyout(this: WidgetBuilder<'msg, #IFabControl>, value: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(Control.ContextFlyout.WithValue(value.Compile()))

    /// <summary>Sets the Tag property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Tag value</param>
    [<Extension>]
    static member inline tag(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(Control.Tag.WithValue(value))

    /// <summary>Sets the FlowDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FlowDirection value</param>
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabControl>, value: FlowDirection) =
        this.AddScalar(Control.FlowDirection.WithValue(value))

    /// <summary>Listens to the Control ContextRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the user has completed a context input gesture, such as a right-click.</param>
    [<Extension>]
    static member inline onContextRequested(this: WidgetBuilder<'msg, #IFabControl>, fn: ContextRequestedEventArgs -> 'msg) =
        this.AddScalar(Control.ContextRequested.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the Control RequestBringIntoView event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when an element wishes to be scrolled into view.</param>
    [<Extension>]
    static member inline onRequestBringIntoView(this: WidgetBuilder<'msg, #IFabControl>, fn: RequestBringIntoViewEventArgs -> 'msg) =
        this.AddScalar(Control.RequestBringIntoView.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the Control Loaded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control has been fully constructed in the visual tree and both
    /// layout and render are complete.</param>
    [<Extension>]
    static member inline onLoaded(this: WidgetBuilder<'msg, #IFabControl>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(Control.Loaded.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the Control UnLoaded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control is removed from the visual tree.</param>
    [<Extension>]
    static member inline onUnLoaded(this: WidgetBuilder<'msg, #IFabControl>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(Control.UnLoaded.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the Control SizeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's size changes.</param>
    [<Extension>]
    static member inline onSizeChanged(this: WidgetBuilder<'msg, #IFabControl>, fn: SizeChangedEventArgs -> 'msg) =
        this.AddScalar(Control.SizeChanged.WithValue(fun args -> fn args |> box))
