namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.LogicalTree
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

    let Styles =
        Attributes.defineAvaloniaListWidgetCollection "StyledElement_Styles" (fun target -> (target :?> StyledElement).Styles)

    let AttachedToLogicalTree =
        Attributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_AttachedToLogicalTree" (fun target ->
            (target :?> StyledElement).AttachedToLogicalTree)

    let DetachedFromLogicalTree =
        Attributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_DetachedFromLogicalTree" (fun target ->
            (target :?> StyledElement).DetachedFromLogicalTree)

[<Extension>]
type StyledElementModifiers =
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, name: string) =
        this.AddScalar(StyledElement.Name.WithValue(name))

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabElement>, fn: WidgetBuilder<'msg, #IFabElement> -> WidgetBuilder<'msg, #IFabElement>) = fn this

    [<Extension>]
    static member inline onAttachedToLogicalTree(this: WidgetBuilder<'msg, #IFabStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(StyledElement.AttachedToLogicalTree.WithValue(fun args -> fn args |> box))

    [<Extension>]
    static member inline onDetachedFromLogicalTree(this: WidgetBuilder<'msg, #IFabStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(StyledElement.DetachedFromLogicalTree.WithValue(fun args -> fn args |> box))

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
