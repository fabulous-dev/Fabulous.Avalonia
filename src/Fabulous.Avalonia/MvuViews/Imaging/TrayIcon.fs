namespace Fabulous.Avalonia.Mvu

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media.Imaging
open Fabulous
open Avalonia.Controls
open Fabulous.Avalonia

type IFabMvuTrayIcon =
    inherit IFabMvuElement
    inherit IFabTrayIcon

module MvuTrayIcon =
    let Clicked =
        Attributes.defineEventNoArg "TrayIcon_Clicked" (fun target -> (target :?> TrayIcon).Clicked)

[<AutoOpen>]
module MvuTrayIconBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member TrayIcon(icon: Bitmap) =
            WidgetBuilder<unit, IFabMvuTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconSource.WithValue(ImageSourceValue.Bitmap(icon)))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member TrayIcon(icon: Bitmap, text: string) =
            WidgetBuilder<unit, IFabMvuTrayIcon>(
                TrayIcon.WidgetKey,
                TrayIcon.IconSource.WithValue(ImageSourceValue.Bitmap(icon)),
                TrayIcon.ToolTipText.WithValue(text)
            )

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member TrayIcon(icon: string) =
            WidgetBuilder<unit, IFabMvuTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconSource.WithValue(ImageSourceValue.File(icon)))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member TrayIcon(icon: string, text: string) =
            WidgetBuilder<unit, IFabMvuTrayIcon>(
                TrayIcon.WidgetKey,
                TrayIcon.IconSource.WithValue(ImageSourceValue.File(icon)),
                TrayIcon.ToolTipText.WithValue(text)
            )

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member TrayIcon(icon: Stream) =
            WidgetBuilder<unit, IFabMvuTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconSource.WithValue(ImageSourceValue.Stream(icon)))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member TrayIcon(icon: Stream, text: string) =
            WidgetBuilder<unit, IFabMvuTrayIcon>(
                TrayIcon.WidgetKey,
                TrayIcon.IconSource.WithValue(ImageSourceValue.Stream(icon)),
                TrayIcon.ToolTipText.WithValue(text)
            )

type MvuTrayIconModifiers =
    /// <summary>Listens to the TrayIcon Clicked event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Clicked event fires.</param>
    [<Extension>]
    static member inline onClicked(this: WidgetBuilder<'msg, #IFabMvuTrayIcon>, msg: 'msg) =
        this.AddScalar(MvuTrayIcon.Clicked.WithValue(MsgValue msg))
