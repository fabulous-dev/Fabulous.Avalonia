namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabGridSplitter =
    inherit IFabTemplatedControl

module GridSplitter =
    let WidgetKey = Widgets.register<GridSplitter>()

    let ResizeDirection =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.ResizeDirectionProperty

    let ResizeBehavior =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.ResizeBehaviorProperty

    let ShowsPreview =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.ShowsPreviewProperty

    let KeyboardIncrement =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.KeyboardIncrementProperty

    let DragIncrement =
        Attributes.defineAvaloniaPropertyWithEquality GridSplitter.DragIncrementProperty


[<AutoOpen>]
module GridSplitterBuilders =
    type Fabulous.Avalonia.View with

        static member GridSplitter(resizeDirection: GridResizeDirection) =
            WidgetBuilder<'msg, IFabGridSplitter>(
                GridSplitter.WidgetKey,
                AttributesBundle(StackList.one(GridSplitter.ResizeDirection.WithValue(resizeDirection)), ValueNone, ValueNone)
            )

[<Extension>]
type GridSplitterModifiers =
    [<Extension>]
    static member inline resizeBehavior(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: GridResizeBehavior) =
        this.AddScalar(GridSplitter.ResizeBehavior.WithValue(value))

    [<Extension>]
    static member inline showsPreview(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: bool) =
        this.AddScalar(GridSplitter.ShowsPreview.WithValue(value))

    [<Extension>]
    static member inline keyboardIncrement(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: float) =
        this.AddScalar(GridSplitter.KeyboardIncrement.WithValue(value))

    [<Extension>]
    static member inline dragIncrement(this: WidgetBuilder<'msg, #IFabGridSplitter>, value: float) =
        this.AddScalar(GridSplitter.DragIncrement.WithValue(value))
