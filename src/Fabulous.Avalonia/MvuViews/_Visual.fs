namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuVisual =
    inherit IFabMvuStyledElement
    inherit IFabVisual

module MvuVisual =
    let AttachedToVisualTree =
        Attributes.defineEvent "VisualAttachedToVisualTree" (fun target -> (target :?> Visual).AttachedToVisualTree)

    let DetachedFromVisualTree =
        Attributes.defineEvent "VisualAttachedToVisualTree" (fun target -> (target :?> Visual).DetachedFromVisualTree)

type MvuVisualModifiers =
    /// <summary>Listens to the Visual AttachedToVisualTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control is attached to a rooted visual tree.</param>
    [<Extension>]
    static member inline onAttachedToVisualTree(this: WidgetBuilder<'msg, #IFabMvuVisual>, fn: VisualTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(MvuVisual.AttachedToVisualTree.WithValue(fn))

    /// <summary>Listens to the Visual DetachedFromVisualTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control is detached from a rooted visual tree.</param>
    [<Extension>]
    static member inline onDetachedFromVisualTree(this: WidgetBuilder<'msg, #IFabMvuVisual>, fn: VisualTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(MvuVisual.DetachedFromVisualTree.WithValue(fn))

type MvuVisualExtraModifiers =
    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabMvuVisual>, value: Color) =
        VisualModifiers.opacityMask(this, View.SolidColorBrush(value))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabMvuVisual>, value: string) =
        VisualModifiers.opacityMask(this, View.SolidColorBrush(value))