namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.LogicalTree
open Fabulous
open Fabulous.Avalonia

type IFabComponentStyledElement =
    inherit IFabComponentAnimatable
    inherit IFabStyledElement

module ComponentStyledElement =

    let StylesWidget =
        ComponentAttributes.defineAvaloniaListWidgetCollection "StyledElement_StylesWidget" (fun target -> (target :?> StyledElement).Styles)

    let AttachedToLogicalTree =
        Attributes.defineEventNoDispatch<LogicalTreeAttachmentEventArgs> "StyledElement_AttachedToLogicalTree" (fun target ->
            (target :?> StyledElement).AttachedToLogicalTree)

    let DetachedFromLogicalTree =
        Attributes.defineEventNoDispatch<LogicalTreeAttachmentEventArgs> "StyledElement_DetachedFromLogicalTree" (fun target ->
            (target :?> StyledElement).DetachedFromLogicalTree)

    let ActualThemeVariantChanged =
        Attributes.defineEventNoArgNoDispatch "StyledElement_ActualThemeVariantChanged" (fun target -> (target :?> StyledElement).ActualThemeVariantChanged)

type ComponentStyledElementModifiers =
    /// <summary>Listens to the StyledElement AttachedToLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is attached to a rooted logical tree.</param>
    [<Extension>]
    static member inline onAttachedToLogicalTree(this: WidgetBuilder<'msg, #IFabComponentStyledElement>, fn: LogicalTreeAttachmentEventArgs -> unit) =
        this.AddScalar(ComponentStyledElement.AttachedToLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement DetachedFromLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is detached from a rooted logical tree.</param>
    [<Extension>]
    static member inline onDetachedFromLogicalTree(this: WidgetBuilder<'msg, #IFabComponentStyledElement>, fn: LogicalTreeAttachmentEventArgs -> unit) =
        this.AddScalar(ComponentStyledElement.DetachedFromLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabComponentStyledElement>, msg: unit -> unit) =
        this.AddScalar(ComponentStyledElement.ActualThemeVariantChanged.WithValue(msg))
