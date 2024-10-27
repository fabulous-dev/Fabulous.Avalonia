namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentLayoutTransformControl =
    inherit IFabComponentDecorator
    inherit IFabLayoutTransformControl

[<AutoOpen>]
module ComponentLayoutTransformControlBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a LayoutTransformControl widget.</summary>
        /// <param name="content">The content of the LayoutTransformControl.</param>
        static member LayoutTransformControl(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentLayoutTransformControl>(
                LayoutTransformControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |], ValueNone)
            )
