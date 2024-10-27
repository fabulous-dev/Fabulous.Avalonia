namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuInlineUIContainer =
    inherit IFabMvuInline
    inherit IFabInlineUIContainer

[<AutoOpen>]
module MvuInlineUIContainerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a InlineUIContainer widget.</summary>
        /// <param name="content">The content of the InlineUIContainer.</param>
        static member InlineUIContainer(content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuInlineUIContainer>(
                InlineUIContainer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| InlineUIContainer.Children.WithValue(content.Compile()) |], ValueNone)
            )
