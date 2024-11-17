namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous


module MvuToolTip =

    let Opening = Attributes.Mvu.defineRoutedEvent "ToolTip_TipWidget" ToolTip.ToolTipOpeningEvent
    
    let Closing = Attributes.Mvu.defineRoutedEventNoArg "ToolTip_TipWidget" ToolTip.ToolTipClosingEvent

type MvuToolTipModifiers =
    /// <summary>Listens to the Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">The TooltipOpening event handler.</param>
    [<Extension>]
    static member inline tooltipOpening(this: WidgetBuilder<'msg, #IFabToolTip>, fn : CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(MvuToolTip.Opening.WithValue(fn))

    /// <summary>Listens to the Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">The TooltipClosing event handler.</param>
    [<Extension>]
    static member inline tooltipClosing(this: WidgetBuilder<'msg, #IFabToolTip>, fn : 'msg) =
        this.AddScalar(MvuToolTip.Closing.WithValue(MsgValue fn))