namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous

type IFabControl =
    inherit IFabInputElement

module Control =

    let Tag =
        Attributes.defineAvaloniaProperty<string, obj> Control.TagProperty box ScalarAttributeComparers.equalityCompare

    let ContextMenu =
        Attributes.defineAvaloniaPropertyWidget Control.ContextMenuProperty

    let ContextFlyout =
        Attributes.defineAvaloniaPropertyWidget Control.ContextFlyoutProperty

    let FlowDirection =
        Attributes.defineAvaloniaPropertyWithEquality Control.FlowDirectionProperty

    let ContextRequested =
        Attributes.defineEvent "Control_ContextRequested" (fun target -> (target :?> Control).ContextRequested)

    let Loaded =
        Attributes.defineEvent "Control_Loaded" (fun target -> (target :?> Control).Loaded)

    let UnLoaded =
        Attributes.defineEvent "Control_UnLoaded" (fun target -> (target :?> Control).Unloaded)

    let SizeChanged =
        Attributes.defineEvent "Control_SizeChanged" (fun target -> (target :?> Control).SizeChanged)

[<Extension>]
type ControlModifiers =
    [<Extension>]
    static member inline contextFlyout(this: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabPopupFlyoutBase>) =
        this.AddWidget(Control.ContextMenu.WithValue(content.Compile()))

    [<Extension>]
    static member inline tag(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(Control.Tag.WithValue(value))

    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabControl>, value: FlowDirection) =
        this.AddScalar(Control.FlowDirection.WithValue(value))

    [<Extension>]
    static member inline onContextRequested(this: WidgetBuilder<'msg, #IFabControl>, onContextRequested: ContextRequestedEventArgs -> 'msg) =
        this.AddScalar(Control.ContextRequested.WithValue(fun args -> onContextRequested args |> box))

    [<Extension>]
    static member inline onLoaded(this: WidgetBuilder<'msg, #IFabControl>, onLoaded: bool -> 'msg) =
        this.AddScalar(
            Control.Loaded.WithValue(fun args ->
                let control = args.Source :?> Control
                onLoaded control.IsLoaded |> box)
        )

    [<Extension>]
    static member inline onUnLoaded(this: WidgetBuilder<'msg, #IFabControl>, onUnLoaded: bool -> 'msg) =
        this.AddScalar(
            Control.UnLoaded.WithValue(fun args ->
                let control = args.Source :?> Control
                onUnLoaded control.IsLoaded |> box)
        )

    [<Extension>]
    static member inline onSizeChanged(this: WidgetBuilder<'msg, #IFabControl>, onSizeChanged: SizeChangedEventArgs -> 'msg) =
        this.AddScalar(Control.SizeChanged.WithValue(fun args -> onSizeChanged args |> box))
