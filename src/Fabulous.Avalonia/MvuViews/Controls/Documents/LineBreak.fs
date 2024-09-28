namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuLineBreak =
    inherit IFabMvuInline
    inherit IFabLineBreak

[<AutoOpen>]
module MvuLineBreakBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a LineBreak widget.</summary>
        static member LineBreak() =
            WidgetBuilder<unit, IFabMvuLineBreak>(LineBreak.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type MvuLineBreakModifiers =
    /// <summary>Link a ViewRef to access the direct LineBreak control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuLineBreak>, value: ViewRef<LineBreak>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
