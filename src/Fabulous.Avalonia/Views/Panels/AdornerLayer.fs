namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabAdornerLayer =
    inherit IFabCanvas

module AdornerLayer =
    let WidgetKey = Widgets.register<AdornerLayer>()

    let Adorner = Attributes.defineAvaloniaPropertyWidget AdornerLayer.AdornerProperty

[<AutoOpen>]
module AdornerLayerBuilders =
    type Fabulous.Avalonia.View with

        static member inline AdornerLayer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabAdornerLayer>(
                AdornerLayer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| AdornerLayer.Adorner.WithValue(content.Compile()) |], ValueNone)
            )
