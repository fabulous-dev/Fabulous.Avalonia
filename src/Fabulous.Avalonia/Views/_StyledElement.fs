namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Collections
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

    let Styles =
        Attributes.defineAvaloniaListWidgetCollection "StyledElement_Styles" (fun target -> (target :?> StyledElement).Styles)

[<Extension>]
type StyledElementModifiers =
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, name: string) =
        this.AddScalar(StyledElement.Name.WithValue(name))

    [<Extension>]
    static member inline styles(this: WidgetBuilder<'msg, #IFabStyledElement>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, StyledElement.Styles)

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabElement>, fn: WidgetBuilder<'msg, #IFabElement> -> WidgetBuilder<'msg, #IFabElement>) = fn this
