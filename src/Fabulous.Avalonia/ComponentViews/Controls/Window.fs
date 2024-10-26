namespace Fabulous.Avalonia.Components

open System.IO
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media.Imaging
open Avalonia.Platform
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentWindow =
    inherit IFabComponentWindowBase
    inherit IFabWindow

module ComponentWindow =
    let WindowClosing =
        Attributes.defineEventNoDispatch "Window_Closing" (fun target -> (target :?> Window).Closing)

    let WindowClosed =
        ComponentAttributes.defineRoutedEvent "Window_Closed" Window.WindowClosedEvent

    let WindowOpened =
        ComponentAttributes.defineRoutedEvent "Window_Opened" Window.WindowOpenedEvent

[<AutoOpen>]
module ComponentWindowBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Window widget.</summary>
        /// <param name="content">The content of the window.</param>
        static member Window(content: WidgetBuilder<'msg, #IFabComponentElement>) =
            WidgetBuilder<unit, IFabComponentWindow>(
                Window.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a Window widget.</summary>
        static member Window<'msg, 'childMarker when 'msg: equality>() =
            SingleChildBuilder<'msg, IFabComponentWindow, 'childMarker>(Window.WidgetKey, ContentControl.ContentWidget)

type ComponentWindowModifiers =
    /// <summary>Listens to the Window WindowClosing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closing.</param>
    [<Extension>]
    static member inline onWindowClosing(this: WidgetBuilder<unit, #IFabComponentWindow>, fn: WindowClosingEventArgs -> unit) =
        this.AddScalar(ComponentWindow.WindowClosing.WithValue(fn))

    /// <summary>Listens to the Window WindowClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onWindowClosed(this: WidgetBuilder<unit, #IFabComponentWindow>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentWindow.WindowClosed.WithValue(fn))

    /// <summary>Listens to the Window WindowOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onWindowOpened(this: WidgetBuilder<'msg, #IFabComponentWindow>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentWindow.WindowOpened.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct Window control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentWindow>, value: ViewRef<Window>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
