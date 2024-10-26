namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous

type IFabDashStyle =
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

type DashStyleModifiers =

    /// <summary>Link a ViewRef to access the direct DashStyle control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDashStyle>, value: ViewRef<DashStyle>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
