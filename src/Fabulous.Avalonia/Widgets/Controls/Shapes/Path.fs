namespace Fabulous.Avalonia

open System.Collections.Generic
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabPath =
    inherit IFabShape

module Path =
    let WidgetKey = Widgets.register<Path> ()

    let Data = Attributes.defineAvaloniaPropertyWidget Path.DataProperty

[<AutoOpen>]
module PathBuilders =
    type Fabulous.Avalonia.View with

        static member Path(content: WidgetBuilder<'msg, IFabGeometry>) =
            WidgetBuilder<'msg, IFabPath>(
                Path.WidgetKey,
                AttributesBundle(StackList.empty (), ValueSome [| Path.Data.WithValue(content.Compile()) |], ValueNone)
            )
