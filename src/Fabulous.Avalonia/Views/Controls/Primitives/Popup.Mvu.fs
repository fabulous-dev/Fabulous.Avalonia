namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module MvuPopup =
    let Closed =
        Attributes.defineEvent "Popup_Closed" (fun target -> (target :?> Popup).Closed)

    let Opened =
        Attributes.defineEventNoArg "Popup_Opened" (fun target -> (target :?> Popup).Opened)

type MvuPopupModifiers =
    /// <summary>Listens to the Popup Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabPopup>, msg: 'msg) =
        this.AddScalar(MvuPopup.Closed.WithValue(fun _ -> msg))

    /// <summary>Listens to the Popup Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabPopup>, msg: 'msg) =
        this.AddScalar(MvuPopup.Opened.WithValue(MsgValue msg))
