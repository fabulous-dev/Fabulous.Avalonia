namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentLineBreak =
    inherit IFabComponentInline
    inherit IFabLineBreak

[<AutoOpen>]
module ComponentLineBreakBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a LineBreak widget.</summary>
        static member LineBreak() =
            WidgetBuilder<unit, IFabComponentLineBreak>(LineBreak.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type ComponentLineBreakModifiers =
    /// <summary>Link a ViewRef to access the direct LineBreak control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentLineBreak>, value: ViewRef<LineBreak>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
