namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous

type IFabMenuBase =
    inherit IFabSelectingItemsControl

module MenuBase =
    let Opened =
        Attributes.defineEvent "MenuBase_Opened" (fun target -> (target :?> MenuBase).Opened)

    let Closed =
        Attributes.defineEvent "MenuBase_Closed" (fun target -> (target :?> MenuBase).Closed)

type MenuBaseModifiers =
    /// <summary>Listens to the MenuOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Menu is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabMenuBase>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MenuBase.Opened.WithValue(fn))

    /// <summary>Listens to the MenuClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Menu is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabMenuBase>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MenuBase.Closed.WithValue(fn))
