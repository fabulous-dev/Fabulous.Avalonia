namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.LogicalTree
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

    let Styles =
        Attributes.defineAvaloniaListWidgetCollection "StyledElement_Styles" (fun target -> (target :?> StyledElement).Styles)

    let Classes =
        Attributes.defineSimpleScalarWithEquality<string list> "StyledElement_Classes" (fun _ newValueOpt node ->
            let target = node.Target :?> StyledElement

            match newValueOpt with
            | ValueNone -> target.Classes.Clear()
            | ValueSome classes ->
                let coll = AvaloniaList<string>()
                classes |> List.iter coll.Add
                target.Classes.AddRange coll)

    let AttachedToLogicalTree =
        Attributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_AttachedToLogicalTree" (fun target ->
            (target :?> StyledElement).AttachedToLogicalTree)

    let DetachedFromLogicalTree =
        Attributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_DetachedFromLogicalTree" (fun target ->
            (target :?> StyledElement).DetachedFromLogicalTree)

    let ActualThemeVariantChanged =
        Attributes.defineEventNoArg "StyledElement_ActualThemeVariantChanged" (fun target -> (target :?> StyledElement).ActualThemeVariantChanged)

[<Extension>]
type StyledElementModifiers =
    /// <summary>Sets the Name property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Name value.</param>
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.Name.WithValue(value))

    /// <summary>Sets the Classes property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Classes value.</param>
    [<Extension>]
    static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string list) =
        this.AddScalar(StyledElement.Classes.WithValue(value))

    /// <summary>Sets the Classes property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Classes value.</param>
    [<Extension>]
    static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.Classes.WithValue([ value ]))

    /// <summary>Sets the Style property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">The Style value.</param>
    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabElement>, fn: WidgetBuilder<'msg, #IFabElement> -> WidgetBuilder<'msg, #IFabElement>) = fn this

    /// <summary>Listens to the StyledElement AttachedToLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is attached to a rooted logical tree.</param>
    [<Extension>]
    static member inline onAttachedToLogicalTree(this: WidgetBuilder<'msg, #IFabStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(StyledElement.AttachedToLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement DetachedFromLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is detached from a rooted logical tree.</param>
    [<Extension>]
    static member inline onDetachedFromLogicalTree(this: WidgetBuilder<'msg, #IFabStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(StyledElement.DetachedFromLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabStyledElement>, msg: 'msg) =
        this.AddScalar(StyledElement.ActualThemeVariantChanged.WithValue(MsgValue msg))

[<Extension>]
type StyledElementCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>, x: WidgetBuilder<'msg, #IFabStyle>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabStyle>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
