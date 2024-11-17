namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous

module ComponentToolTip =

    let Opening = Attributes.Component.defineRoutedEvent "ToolTip_TipWidget" ToolTip.ToolTipOpeningEvent
    
    let Closing = Attributes.Component.defineRoutedEventNoArg "ToolTip_TipWidget" ToolTip.ToolTipClosingEvent

type ComponentToolTipModifiers =
    /// <summary>Listens to the Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">The TooltipOpening event handler.</param>
    [<Extension>]
    static member inline tooltipOpening(this: WidgetBuilder<'msg, #IFabToolTip>, fn : CancelRoutedEventArgs -> unit) =
        this.AddScalar(ComponentToolTip.Opening.WithValue(fn))

    /// <summary>Listens to the Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">The TooltipClosing event handler.</param>
    [<Extension>]
    static member inline tooltipClosing(this: WidgetBuilder<'msg, #IFabToolTip>, fn : unit -> unit) =
        this.AddScalar(ComponentToolTip.Closing.WithValue(fn))