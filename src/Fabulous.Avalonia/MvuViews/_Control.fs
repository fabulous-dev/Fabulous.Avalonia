namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

type IFabMvuControl =
    inherit IFabMvuInputElement
    inherit IFabControl

module MvuControl =

    let RequestBringIntoView =
        MvuAttributes.defineRoutedEvent "Control_RequestBringIntoView" Control.RequestBringIntoViewEvent

    let ContextRequested =
        MvuAttributes.defineEvent "Control_ContextRequested" (fun target -> (target :?> Control).ContextRequested)

    let Loaded =
        MvuAttributes.defineEvent "Control_Loaded" (fun target -> (target :?> Control).Loaded)

    let UnLoaded =
        MvuAttributes.defineEvent "Control_UnLoaded" (fun target -> (target :?> Control).Unloaded)

    let SizeChanged =
        MvuAttributes.defineEvent "Control_SizeChanged" (fun target -> (target :?> Control).SizeChanged)

type MvuControlModifiers =
    /// <summary>Listens to the Control ContextRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the user has completed a context input gesture, such as a right-click.</param>
    [<Extension>]
    static member inline onContextRequested(this: WidgetBuilder<unit, #IFabMvuControl>, fn: ContextRequestedEventArgs -> unit) =
        this.AddScalar(MvuControl.ContextRequested.WithValue(fn))

    /// <summary>Listens to the Control RequestBringIntoView event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when an element wishes to be scrolled into view.</param>
    [<Extension>]
    static member inline onRequestBringIntoView(this: WidgetBuilder<unit, #IFabMvuControl>, fn: RequestBringIntoViewEventArgs -> unit) =
        this.AddScalar(MvuControl.RequestBringIntoView.WithValue(fn))

    /// <summary>Listens to the Control Loaded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control has been fully constructed in the visual tree and both
    /// layout and render are complete.</param>
    [<Extension>]
    static member inline onLoaded(this: WidgetBuilder<unit, #IFabMvuControl>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuControl.Loaded.WithValue(fn))

    /// <summary>Listens to the Control UnLoaded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control is removed from the visual tree.</param>
    [<Extension>]
    static member inline onUnLoaded(this: WidgetBuilder<unit, #IFabMvuControl>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuControl.UnLoaded.WithValue(fn))

    /// <summary>Listens to the Control SizeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's size changes.</param>
    [<Extension>]
    static member inline onSizeChanged(this: WidgetBuilder<unit, #IFabMvuControl>, fn: SizeChangedEventArgs -> unit) =
        this.AddScalar(MvuControl.SizeChanged.WithValue(fn))
