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
