namespace Fabulous.Avalonia

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media.Imaging
open Fabulous
open Avalonia.Controls

type IFabTrayIcon =
    inherit IFabAvaloniaObject

module TrayIcon =
    let WidgetKey = Widgets.register<TrayIcon>()

    /// Performance optimization: avoid allocating a new ImageSource instance on each update
    /// we store the user value (eg. string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline private defineSourceAttribute<'model when 'model: equality> ([<InlineIfLambda>] convertModelToValue: 'model -> WindowIcon) =
        Attributes.defineScalar<'model, 'model> TrayIcon.IconProperty.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> TrayIcon

            match newValueOpt with
            | ValueNone -> target.ClearValue(TrayIcon.IconProperty)
            | ValueSome v -> target.SetValue(TrayIcon.IconProperty, convertModelToValue v) |> ignore)

    let Menu = Attributes.defineAvaloniaPropertyWidget TrayIcon.MenuProperty

    let Icon = Attributes.defineAvaloniaPropertyWithEquality TrayIcon.IconProperty

    let IconBitmap = defineSourceAttribute<Bitmap>(fun x -> WindowIcon(x))

    let IconFile =
        defineSourceAttribute<string>(fun x -> WindowIcon(ImageSource.fromString x))

    let IconStream =
        defineSourceAttribute<Stream>(fun x -> WindowIcon(ImageSource.fromStream x))

    let ToolTipText =
        Attributes.defineAvaloniaPropertyWithEquality TrayIcon.ToolTipTextProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality TrayIcon.IsVisibleProperty

    let Clicked =
        Attributes.defineEventNoArg "TrayIcon_Clicked" (fun target -> (target :?> TrayIcon).Clicked)


[<AutoOpen>]
module TrayIconBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member inline TrayIcon(icon: WindowIcon) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.Icon.WithValue(icon))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member inline TrayIcon(icon: WindowIcon, text: string) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.Icon.WithValue(icon), TrayIcon.ToolTipText.WithValue(text))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member inline TrayIcon(icon: Bitmap) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconBitmap.WithValue(icon))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member inline TrayIcon(icon: Bitmap, text: string) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconBitmap.WithValue(icon), TrayIcon.ToolTipText.WithValue(text))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member inline TrayIcon(icon: string) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconFile.WithValue(icon))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member inline TrayIcon(icon: string, text: string) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconFile.WithValue(icon), TrayIcon.ToolTipText.WithValue(text))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        static member inline TrayIcon(icon: Stream) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconStream.WithValue(icon))

        /// <summary>Creates a TrayIcon widget.</summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The tooltip text to display.</param>
        static member inline TrayIcon(icon: Stream, text: string) =
            WidgetBuilder<'msg, IFabTrayIcon>(TrayIcon.WidgetKey, TrayIcon.IconStream.WithValue(icon), TrayIcon.ToolTipText.WithValue(text))

[<Extension>]
type TrayIconModifiers =
    /// <summary>Sets the Menu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Menu value.</param>
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabTrayIcon>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(TrayIcon.Menu.WithValue(value.Compile()))

    /// <summary>Sets the IsVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsVisible value.</param>
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabTrayIcon>, value: bool) =
        this.AddScalar(TrayIcon.IsVisible.WithValue(value))

    /// <summary>Listens to the TrayIcon Clicked event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Clicked event fires.</param>
    [<Extension>]
    static member inline onClicked(this: WidgetBuilder<'msg, #IFabTrayIcon>, msg: 'msg) =
        this.AddScalar(TrayIcon.Clicked.WithValue(MsgValue msg))

    /// <summary>Link a ViewRef to access the direct TrayIcon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTrayIcon>, value: ViewRef<TrayIcon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
