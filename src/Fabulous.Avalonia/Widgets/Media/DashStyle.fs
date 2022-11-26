namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFaDashStyle =
    inherit IFabAnimatable

module DashStyle =
    let WidgetKey = Widgets.register<DashStyle>()
    
    let Dashes =
        Attributes.defineSimpleScalarWithEquality<float list>
            "DashStyle_Dashes"
            (fun _ newValueOpt node ->
                let target = node.Target :?> AvaloniaObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(DashStyle.DashesProperty)
                | ValueSome points ->
                    let coll = AvaloniaList<float>()
                    points |> List.iter coll.Add
                    target.SetValue(DashStyle.DashesProperty, coll) |> ignore)
    
    let Offset = Attributes.defineAvaloniaPropertyWithEquality DashStyle.OffsetProperty
    
        
[<AutoOpen>]
module DashStyleBuilders =
    type Fabulous.Avalonia.View with
        static member DashStyle(dashes: float list) =
            WidgetBuilder<'msg, IFaDashStyle>(
                DashStyle.WidgetKey,
                AttributesBundle(
                    StackList.one(DashStyle.Dashes.WithValue(dashes)),
                    ValueNone,
                    ValueNone)
                )

[<Extension>]             
type DashStyleModifiers =
    [<Extension>]
    static member inline thickness(this: WidgetBuilder<'msg, #IFaDashStyle>, value: float) =
        this.AddScalar(DashStyle.Offset.WithValue(value))
