namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentViewBox =
    inherit IFabComponentControl
    inherit IFabViewBox

[<AutoOpen>]
module ComponentViewBoxBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ViewBox widget.</summary>
        /// <param name="content">The content of the ViewBox.</param>
        static member ViewBox(content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentViewBox>(
                ViewBox.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ViewBox.Child.WithValue(content.Compile()) |], ValueNone)
            )
