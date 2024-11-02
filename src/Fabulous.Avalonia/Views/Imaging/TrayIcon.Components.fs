namespace Fabulous.Avalonia

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media.Imaging
open Fabulous
open Avalonia.Controls
open Fabulous.Avalonia

module ComponentTrayIcon =
    let Clicked =
        Attributes.defineEventNoArgNoDispatch "TrayIcon_Clicked" (fun target -> (target :?> TrayIcon).Clicked)

type ComponentTrayIconModifiers =
    /// <summary>Listens to the TrayIcon Clicked event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Clicked event fires.</param>
    [<Extension>]
    static member inline onClicked(this: WidgetBuilder<'msg, #IFabTrayIcon>, msg: unit -> unit) =
        this.AddScalar(ComponentTrayIcon.Clicked.WithValue(msg))
