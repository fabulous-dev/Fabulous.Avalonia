namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
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

[<Extension>]
type AdornerLayerModifiers =
    /// <summary>Link a ViewRef to access the direct AdornerLayer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAdornerLayer>, value: ViewRef<AdornerLayer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
