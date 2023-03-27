namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabRefreshContainer =
    inherit IFabContentControl

module RefreshContainer =
    let WidgetKey = Widgets.register<RefreshContainer>()

    let RefreshRequested =
        Attributes.defineEvent<RefreshRequestedEventArgs> "RefreshContainer_RefreshRequested" (fun target -> (target :?> RefreshContainer).RefreshRequested)

    let Visualizer =
        Attributes.defineAvaloniaPropertyWidget RefreshContainer.VisualizerProperty

    let PullDirection =
        Attributes.defineAvaloniaPropertyWithEquality RefreshContainer.PullDirectionProperty

[<AutoOpen>]
module RefreshContainerBuilders =
    type Fabulous.Avalonia.View with

        static member RefreshContainer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRefreshContainer>(
                RefreshContainer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type RefreshContainerModifiers =
    [<Extension>]
    static member inline pullDirection(this: WidgetBuilder<'msg, #IFabRefreshContainer>, value: PullDirection) =
        this.AddScalar(RefreshContainer.PullDirection.WithValue(value))

    [<Extension>]
    static member inline visualizer(this: WidgetBuilder<'msg, #IFabRefreshContainer>, content: WidgetBuilder<'msg, IFabRefreshVisualizer>) =
        this.AddWidget(RefreshContainer.Visualizer.WithValue(content.Compile()))

    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabRefreshContainer>, onRefreshRequested: RefreshRequestedEventArgs -> 'msg) =
        this.AddScalar(RefreshContainer.RefreshRequested.WithValue(fun args -> onRefreshRequested args |> box))

    /// <summary>Link a ViewRef to access the direct RefreshContainer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRefreshContainer>, value: ViewRef<RefreshContainer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
