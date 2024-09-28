namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

type IFabMvuMenuBase =
    inherit IFabMvuSelectingItemsControl
    inherit IFabMenuBase

module MvuMenuBase =
    let Opened =
        MvuAttributes.defineEvent "MenuBase_Opened" (fun target -> (target :?> MenuBase).Opened)

    let Closed =
        MvuAttributes.defineEvent "MenuBase_Closed" (fun target -> (target :?> MenuBase).Closed)

type MvuMenuBaseModifiers =
    /// <summary>Listens to the MenuOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Menu is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabMvuMenuBase>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuMenuBase.Opened.WithValue(fn))

    /// <summary>Listens to the MenuClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Menu is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabMvuMenuBase>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuMenuBase.Closed.WithValue(fn))
