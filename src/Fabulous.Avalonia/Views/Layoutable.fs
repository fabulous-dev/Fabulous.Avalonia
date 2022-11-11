namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Layout
open Fabulous

type IFabLayoutable = inherit IFabVisual

module Layoutable =
    let HorizontalAlignment = Attributes.defineStyledWithEquality Layoutable.HorizontalAlignmentProperty
    let VerticalAlignment = Attributes.defineStyledWithEquality Layoutable.VerticalAlignmentProperty
    
[<Extension>]
type LayoutableModifiers =
    [<Extension>]
    static member inline horizontalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: HorizontalAlignment) =
        this.AddScalar(Layoutable.HorizontalAlignment.WithValue(value))
        
    [<Extension>]
    static member inline verticalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: VerticalAlignment) =
        this.AddScalar(Layoutable.VerticalAlignment.WithValue(value))

