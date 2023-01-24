namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous

type IFaDashStyle =
    inherit IFabAnimatable

module DashStyle =
    let WidgetKey = Widgets.register<DashStyle>()

    let Dashes =
        Attributes.defineSimpleScalarWithEquality<float list> "DashStyle_Dashes" (fun _ newValueOpt node ->
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

        static member DashStyle(dashes: float list, offset: float) =
            WidgetBuilder<'msg, IFaDashStyle>(DashStyle.WidgetKey, DashStyle.Dashes.WithValue(dashes), DashStyle.Offset.WithValue(offset))
