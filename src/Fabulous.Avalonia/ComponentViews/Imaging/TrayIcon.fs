namespace Fabulous.Avalonia.Components

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media.Imaging
open Fabulous
open Avalonia.Controls
open Fabulous.Avalonia

type IFabComponentTrayIcon =
    inherit IFabComponentElement
    inherit IFabTrayIcon

module ComponentTrayIcon =
    let Clicked =
        Attributes.defineEventNoArgNoDispatch "TrayIcon_Clicked" (fun target -> (target :?> TrayIcon).Clicked)

[<AutoOpen>]
module ComponentTrayIconBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member TrayIcon(icon: Bitmap) =
            WidgetBuilder<unit, IFabComponentTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconSource.WithValue(ImageSourceValue.Bitmap(icon)))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member TrayIcon(icon: Bitmap, text: string) =
            WidgetBuilder<unit, IFabComponentTrayIcon>(
                TrayIcon.WidgetKey,
                TrayIcon.IconSource.WithValue(ImageSourceValue.Bitmap(icon)),
                TrayIcon.ToolTipText.WithValue(text)
            )

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member TrayIcon(icon: string) =
            WidgetBuilder<unit, IFabComponentTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconSource.WithValue(ImageSourceValue.File(icon)))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member TrayIcon(icon: string, text: string) =
            WidgetBuilder<unit, IFabComponentTrayIcon>(
                TrayIcon.WidgetKey,
                TrayIcon.IconSource.WithValue(ImageSourceValue.File(icon)),
                TrayIcon.ToolTipText.WithValue(text)
            )

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member TrayIcon(icon: Stream) =
            WidgetBuilder<unit, IFabComponentTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconSource.WithValue(ImageSourceValue.Stream(icon)))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member TrayIcon(icon: Stream, text: string) =
            WidgetBuilder<unit, IFabComponentTrayIcon>(
                TrayIcon.WidgetKey,
                TrayIcon.IconSource.WithValue(ImageSourceValue.Stream(icon)),
                TrayIcon.ToolTipText.WithValue(text)
            )

type ComponentTrayIconModifiers =
    /// <summary>Listens to the TrayIcon Clicked event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Clicked event fires.</param>
    [<Extension>]
    static member inline onClicked(this: WidgetBuilder<'msg, #IFabComponentTrayIcon>, msg: unit -> unit) =
        this.AddScalar(ComponentTrayIcon.Clicked.WithValue(msg))

    /// <summary>Link a ViewRef to access the direct TrayIcon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentTrayIcon>, value: ViewRef<TrayIcon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
