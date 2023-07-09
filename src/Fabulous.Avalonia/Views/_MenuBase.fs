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

[<Extension>]
type MenuBaseModifiers =
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabMenuBase>, onOpened: RoutedEventArgs -> 'msg) =
        this.AddScalar(MenuBase.Opened.WithValue(fun args -> onOpened args |> box))

    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabMenuBase>, onClosed: RoutedEventArgs -> 'msg) =
        this.AddScalar(MenuBase.Closed.WithValue(fun args -> onClosed args |> box))
