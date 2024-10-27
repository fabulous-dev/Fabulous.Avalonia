namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuLayoutTransformControl =
    inherit IFabMvuDecorator
    inherit IFabLayoutTransformControl

[<AutoOpen>]
module MvuLayoutTransformControlBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a LayoutTransformControl widget.</summary>
        /// <param name="content">The content of the LayoutTransformControl.</param>
        static member LayoutTransformControl(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuLayoutTransformControl>(
                LayoutTransformControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |], ValueNone)
            )
