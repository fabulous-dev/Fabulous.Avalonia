namespace Fabulous.Avalonia

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media.Imaging
open Fabulous
open Avalonia.Controls
open Fabulous.Avalonia

module MvuTrayIcon =
    let Clicked =
        Attributes.defineEventNoArg "TrayIcon_Clicked" (fun target -> (target :?> TrayIcon).Clicked)

type MvuTrayIconModifiers =
    /// <summary>Listens to the TrayIcon Clicked event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Clicked event fires.</param>
    [<Extension>]
    static member inline onClicked(this: WidgetBuilder<'msg, #IFabTrayIcon>, msg: 'msg) =
        this.AddScalar(MvuTrayIcon.Clicked.WithValue(MsgValue msg))
