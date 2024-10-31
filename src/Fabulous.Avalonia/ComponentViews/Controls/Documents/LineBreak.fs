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
