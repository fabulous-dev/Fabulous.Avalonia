namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
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
    /// <summary>Listens to the DragDrop DragEnter event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation enters the element.</param>
    [<Extension>]
    static member inline onDragEnter(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.DragEnter.WithValue(fn))

    /// <summary>Listens to the DragDrop DragLeave event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation leaves the element.</param>
    [<Extension>]
    static member inline onDragLeave(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.DragLeave.WithValue(fn))

    /// <summary>Listens to the DragDrop DragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is in progress over the element.</param>
    [<Extension>]
    static member inline onDragOver(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.DragOver.WithValue(fn))

    /// <summary>Listens to the DragDrop Drop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is dropped on the element.</param>
    [<Extension>]
    static member inline onDrop(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(DragDrop.Drop.WithValue(fn))

    /// <summary>Sets the AllowDrop property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AllowDrop value.</param>
    [<Extension>]
    static member inline allowDrop(this: WidgetBuilder<'msg, #IFabInteractive>, value: bool) =
        this.AddScalar(DragDrop.AllowDrop.WithValue(value))
