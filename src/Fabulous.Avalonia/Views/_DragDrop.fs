namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Avalonia.Interactivity
open Fabulous

module DragDrop =
    let DragEnter =
        Attributes.defineRoutedEvent<DragEventArgs> "DragDrop_DragEnter" DragDrop.DragEnterEvent

    let DragLeave =
        Attributes.defineRoutedEvent<DragEventArgs> "DragDrop_DragLeave" DragDrop.DragLeaveEvent

    let DragOver =
        Attributes.defineRoutedEvent<DragEventArgs> "DragDrop_DragOver" DragDrop.DragOverEvent

    let Drop =
        Attributes.defineRoutedEvent<DragEventArgs> "DragDrop_Drop" DragDrop.DropEvent

    let AllowDrop =
        Attributes.defineAvaloniaPropertyWithEquality DragDrop.AllowDropProperty

[<Extension>]
type DragDropModifiers =
    [<Extension>]
    static member inline onDragEnter(this: WidgetBuilder<'msg, #IFabInteractive>, onDragEnter: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.DragEnter.WithValue(fun args -> onDragEnter args |> box))

    [<Extension>]
    static member inline onDragLeave(this: WidgetBuilder<'msg, #IFabInteractive>, onDragLeave: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.DragLeave.WithValue(fun args -> onDragLeave args |> box))

    [<Extension>]
    static member inline onDragOver(this: WidgetBuilder<'msg, #IFabInteractive>, onDragOver: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.DragOver.WithValue(fun args -> onDragOver args |> box))

    [<Extension>]
    static member inline onDrop(this: WidgetBuilder<'msg, #IFabInteractive>, onDrop: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.Drop.WithValue(fun args -> onDrop args |> box))

    [<Extension>]
    static member inline allowDrop(this: WidgetBuilder<'msg, #IFabInteractive>, allowDrop: bool) =
        this.AddScalar(DragDrop.AllowDrop.WithValue(allowDrop))
