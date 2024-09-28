namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia

type IFabMvuDragDrop =
    inherit IFabMvuElement
    inherit IFabInteractive

module MvuDragDrop =
    let DragEnter =
        MvuAttributes.defineRoutedEvent<DragEventArgs> "DragDrop_DragEnter" DragDrop.DragEnterEvent

    let DragLeave =
        MvuAttributes.defineRoutedEvent<DragEventArgs> "DragDrop_DragLeave" DragDrop.DragLeaveEvent

    let DragOver =
        MvuAttributes.defineRoutedEvent<DragEventArgs> "DragDrop_DragOver" DragDrop.DragOverEvent

    let Drop =
        MvuAttributes.defineRoutedEvent<DragEventArgs> "DragDrop_Drop" DragDrop.DropEvent

    let AllowDrop =
        Attributes.defineAvaloniaPropertyWithEquality DragDrop.AllowDropProperty

type MvuDragDropModifiers =
    /// <summary>Listens to the DragDrop DragEnter event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation enters the element.</param>
    [<Extension>]
    static member inline onDragEnter(this: WidgetBuilder<unit, #IFabMvuDragDrop>, fn: DragEventArgs -> unit) =
        this.AddScalar(MvuDragDrop.DragEnter.WithValue(fn))

    /// <summary>Listens to the DragDrop DragLeave event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation leaves the element.</param>
    [<Extension>]
    static member inline onDragLeave(this: WidgetBuilder<unit, #IFabMvuDragDrop>, fn: DragEventArgs -> unit) =
        this.AddScalar(MvuDragDrop.DragLeave.WithValue(fn))

    /// <summary>Listens to the DragDrop DragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is in progress over the element.</param>
    [<Extension>]
    static member inline onDragOver(this: WidgetBuilder<unit, #IFabMvuDragDrop>, fn: DragEventArgs -> unit) =
        this.AddScalar(MvuDragDrop.DragOver.WithValue(fn))

    /// <summary>Listens to the DragDrop Drop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is dropped on the element.</param>
    [<Extension>]
    static member inline onDrop(this: WidgetBuilder<unit, #IFabMvuDragDrop>, fn: DragEventArgs -> unit) =
        this.AddScalar(MvuDragDrop.Drop.WithValue(fn))
