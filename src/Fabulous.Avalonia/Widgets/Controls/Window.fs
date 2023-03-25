namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Platform
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabWindow =
    inherit IFabWindowBase

module Window =
    let WidgetKey = Widgets.register<Window>()

    let SizeToContent =
        Attributes.defineAvaloniaPropertyWithEquality Window.SizeToContentProperty

    let ExtendClientAreaToDecorationsHint =
        Attributes.defineAvaloniaPropertyWithEquality Window.ExtendClientAreaToDecorationsHintProperty

    let ExtendClientAreaChromeHints =
        Attributes.defineAvaloniaPropertyWithEquality Window.ExtendClientAreaChromeHintsProperty

    let ExtendClientAreaTitleBarHeightHint =
        Attributes.defineAvaloniaPropertyWithEquality Window.ExtendClientAreaTitleBarHeightHintProperty

    let SystemDecorations =
        Attributes.defineAvaloniaPropertyWithEquality Window.SystemDecorationsProperty

    let ShowActivated =
        Attributes.defineAvaloniaPropertyWithEquality Window.ShowActivatedProperty

    let ShowInTaskbar =
        Attributes.defineAvaloniaPropertyWithEquality Window.ShowInTaskbarProperty

    let WindowState =
        Attributes.defineAvaloniaPropertyWithEquality Window.WindowStateProperty

    let Title = Attributes.defineAvaloniaPropertyWithEquality Window.TitleProperty

    let Icon = Attributes.defineAvaloniaPropertyWithEquality Window.IconProperty

    let WindowStartupLocation =
        Attributes.defineAvaloniaPropertyWithEquality Window.WindowStartupLocationProperty

    let CanResize =
        Attributes.defineAvaloniaPropertyWithEquality Window.CanResizeProperty

    let WindowClosing =
        Attributes.defineEvent "Window_Closing" (fun target -> (target :?> Window).Closing)


[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Avalonia.View with

        static member Window(content: WidgetBuilder<'msg, #IFabElement>) =
            WidgetBuilder<'msg, IFabWindow>(
                Window.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type WindowModifiers =
    [<Extension>]
    static member inline sizeToContent(this: WidgetBuilder<'msg, #IFabWindow>, value: SizeToContent) =
        this.AddScalar(Window.SizeToContent.WithValue(value))

    [<Extension>]
    static member inline extendClientAreaToDecorationsHint(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.ExtendClientAreaToDecorationsHint.WithValue(value))

    [<Extension>]
    static member inline extendClientAreaChromeHints(this: WidgetBuilder<'msg, #IFabWindow>, value: ExtendClientAreaChromeHints) =
        this.AddScalar(Window.ExtendClientAreaChromeHints.WithValue(value))

    [<Extension>]
    static member inline extendClientAreaTitleBarHeightHint(this: WidgetBuilder<'msg, #IFabWindow>, value: float) =
        this.AddScalar(Window.ExtendClientAreaTitleBarHeightHint.WithValue(value))

    [<Extension>]
    static member inline systemDecorations(this: WidgetBuilder<'msg, #IFabWindow>, value: SystemDecorations) =
        this.AddScalar(Window.SystemDecorations.WithValue(value))

    [<Extension>]
    static member inline showActivated(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.ShowActivated.WithValue(value))

    [<Extension>]
    static member inline showInTaskbar(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.ShowInTaskbar.WithValue(value))

    [<Extension>]
    static member inline windowState(this: WidgetBuilder<'msg, #IFabWindow>, value: WindowState) =
        this.AddScalar(Window.WindowState.WithValue(value))

    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IFabWindow>, value: string) =
        this.AddScalar(Window.Title.WithValue(value))

    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabWindow>, value: WindowIcon) =
        this.AddScalar(Window.Icon.WithValue(value))

    [<Extension>]
    static member inline windowStartupLocation(this: WidgetBuilder<'msg, #IFabWindow>, value: WindowStartupLocation) =
        this.AddScalar(Window.WindowStartupLocation.WithValue(value))

    [<Extension>]
    static member inline canResize(this: WidgetBuilder<'msg, #IFabWindow>, value: bool) =
        this.AddScalar(Window.CanResize.WithValue(value))

    [<Extension>]
    static member inline onWindowClosing(this: WidgetBuilder<'msg, #IFabWindow>, onWindowClosing: WindowClosingEventArgs -> 'msg) =
        this.AddScalar(Window.WindowClosing.WithValue(fun args -> onWindowClosing args |> box))
