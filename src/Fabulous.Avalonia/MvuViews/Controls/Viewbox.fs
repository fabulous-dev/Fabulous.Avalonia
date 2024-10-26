namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuViewBox =
    inherit IFabMvuControl
    inherit IFabViewBox

[<AutoOpen>]
module MvuViewBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ViewBox widget.</summary>
        /// <param name="content">The content of the ViewBox.</param>
        static member ViewBox(content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuViewBox>(
                ViewBox.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ViewBox.Child.WithValue(content.Compile()) |], ValueNone)
            )
