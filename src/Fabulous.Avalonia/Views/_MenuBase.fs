namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabMenuBase =
    inherit IFabSelectingItemsControl

module MenuBase =
    let IsOpen = Attributes.defineAvaloniaPropertyWithEquality MenuBase.IsOpenProperty

    let MenuOpened =
        Attributes.defineEvent "MenuBase_MenuOpened" (fun target -> (target :?> MenuBase).MenuOpened)

    let MenuClosed =
        Attributes.defineEvent "MenuBase_MenuClosed" (fun target -> (target :?> MenuBase).MenuClosed)


[<Extension>]
type MenuBaseModifiers =
    [<Extension>]
    static member inline isOpen(this: WidgetBuilder<'msg, #IFabMenuBase>, value: bool) =
        this.AddScalar(MenuBase.IsOpen.WithValue(value))

    [<Extension>]
    static member inline onMenuOpened(this: WidgetBuilder<'msg, #IFabMenuBase>, onMenuOpened: bool -> 'msg) =
        this.AddScalar(
            MenuBase.MenuOpened.WithValue(fun args ->
                let control = args.Source :?> MenuBase
                onMenuOpened control.IsOpen |> box)
        )

    [<Extension>]
    static member inline onMenuClosed(this: WidgetBuilder<'msg, #IFabMenuBase>, onMenuClosed: bool -> 'msg) =
        this.AddScalar(
            MenuBase.MenuClosed.WithValue(fun args ->
                let control = args.Source :?> MenuBase
                onMenuClosed control.IsOpen |> box)
        )
