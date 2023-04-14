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
    /// <summary>Set the ContextFlyout widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="widget">The widget to set</param>
    /// <example>
    /// <code lang="fsharp">
    /// Border(TextBlock("Flyout that can be applied to any control."))
    ///    .contextFlyout(
    ///        MenuFlyout() {
    ///            MenuItem("Menu Item")
    ///            ...
    ///        }
    ///    )
    /// </code>
    /// </example>
    [<Extension>]
    static member inline contextFlyout(this: WidgetBuilder<'msg, #IFabControl>, widget: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(Control.ContextFlyout.WithValue(widget.Compile()))

    /// <summary>Set the Tag property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline tag(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(Control.Tag.WithValue(value))

    /// <summary>Set the FlowDirection property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type FlowDirection =
    /// | LeftToRight = 0
    /// | RightToLeft = 1
    /// </code>
    /// </example>
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabControl>, value: FlowDirection) =
        this.AddScalar(Control.FlowDirection.WithValue(value))

    /// <summary>Listens to the ContextRequested event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be call when the event is raised</param>
    [<Extension>]
    static member inline onContextRequested(this: WidgetBuilder<'msg, #IFabControl>, fn: ContextRequestedEventArgs -> 'msg) =
        this.AddScalar(Control.ContextRequested.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the Loaded event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be call when the event is raised</param>
    [<Extension>]
    static member inline onLoaded(this: WidgetBuilder<'msg, #IFabControl>, fn: bool -> 'msg) =
        this.AddScalar(
            Control.Loaded.WithValue(fun args ->
                let control = args.Source :?> Control
                fn control.IsLoaded |> box)
        )

    /// <summary>Listens to the UnLoaded event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be call when the event is raised</param>
    [<Extension>]
    static member inline onUnLoaded(this: WidgetBuilder<'msg, #IFabControl>, fn: bool -> 'msg) =
        this.AddScalar(
            Control.UnLoaded.WithValue(fun args ->
                let control = args.Source :?> Control
                fn control.IsLoaded |> box)
        )

    /// <summary>Listens to the SizeChanged event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to be call when the event is raised</param>
    [<Extension>]
    static member inline onSizeChanged(this: WidgetBuilder<'msg, #IFabControl>, fn: SizeChangedEventArgs -> 'msg) =
        this.AddScalar(Control.SizeChanged.WithValue(fun args -> fn args |> box))
