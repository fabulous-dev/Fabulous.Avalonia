namespace Fabulous.Avalonia.Mvu

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media.Imaging
open Avalonia.Platform
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuWindow =
    inherit IFabMvuWindowBase
    inherit IFabWindow

module MvuWindow =
    let WindowClosing =
        Attributes.defineEvent "Window_Closing" (fun target -> (target :?> Window).Closing)

    let WindowClosed =
        MvuAttributes.defineRoutedEvent "Window_Closed" Window.WindowClosedEvent

    let WindowOpened =
        MvuAttributes.defineRoutedEvent "Window_Opened" Window.WindowOpenedEvent

[<AutoOpen>]
module MvuWindowBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Window widget.</summary>
        /// <param name="content">The content of the window.</param>
        static member Window(content: WidgetBuilder<'msg, #IFabMvuElement>) =
            WidgetBuilder<unit, IFabMvuWindow>(
                Window.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a Window widget.</summary>
        static member Window<'msg, 'childMarker when 'msg: equality>() =
            SingleChildBuilder<'msg, IFabMvuWindow, 'childMarker>(Window.WidgetKey, ContentControl.ContentWidget)

type MvuWindowModifiers =
    /// <summary>Listens to the Window WindowClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closing.</param>
    [<Extension>]
    static member inline onWindowClosing(this: WidgetBuilder<unit, #IFabMvuWindow>, fn: WindowClosingEventArgs -> unit) =
        this.AddScalar(MvuWindow.WindowClosing.WithValue(fn))

    /// <summary>Listens to the Window WindowClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onWindowClosed(this: WidgetBuilder<unit, #IFabMvuWindow>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuWindow.WindowClosed.WithValue(fn))

    /// <summary>Listens to the Window WindowOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onWindowOpened(this: WidgetBuilder<'msg, #IFabMvuWindow>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuWindow.WindowOpened.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct Window control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuWindow>, value: ViewRef<Window>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
