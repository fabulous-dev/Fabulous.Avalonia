namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.LogicalTree
open Fabulous
open Fabulous.Avalonia

type IFabMvuStyledElement =
    inherit IFabMvuElement
    inherit IFabAnimatable

module MvuStyledElement =
    let StylesWidget =
        MvuAttributes.defineAvaloniaListWidgetCollection "StyledElement_StylesWidget" (fun target -> (target :?> StyledElement).Styles)

    let AttachedToLogicalTree =
        MvuAttributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_AttachedToLogicalTree" (fun target ->
            (target :?> StyledElement).AttachedToLogicalTree)

    let DetachedFromLogicalTree =
        MvuAttributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_DetachedFromLogicalTree" (fun target ->
            (target :?> StyledElement).DetachedFromLogicalTree)

    let ActualThemeVariantChanged =
        MvuAttributes.defineEventNoArg "StyledElement_ActualThemeVariantChanged" (fun target -> (target :?> StyledElement).ActualThemeVariantChanged)

type MvuStyledElementModifiers =
    /// <summary>Listens to the StyledElement AttachedToLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is attached to a rooted logical tree.</param>
    [<Extension>]
    static member inline onAttachedToLogicalTree(this: WidgetBuilder<'msg, #IFabMvuStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(MvuStyledElement.AttachedToLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement DetachedFromLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is detached from a rooted logical tree.</param>
    [<Extension>]
    static member inline onDetachedFromLogicalTree(this: WidgetBuilder<'msg, #IFabMvuStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(MvuStyledElement.DetachedFromLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabMvuStyledElement>, msg: 'msg) =
        this.AddScalar(MvuStyledElement.ActualThemeVariantChanged.WithValue(MsgValue msg))
