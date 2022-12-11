namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabInlineUIContainer =
    inherit IFabInline

module InlineUIContainer =
    let WidgetKey = Widgets.register<InlineUIContainer> ()
    
    let Children =
        Attributes.defineAvaloniaPropertyWidget InlineUIContainer.ChildProperty
    
[<AutoOpen>]
module InlineUIContainerBuilders =
    type Fabulous.Avalonia.View with
        static member InlineUIContainer(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabInlineUIContainer>(
                InlineUIContainer.WidgetKey,
                AttributesBundle(
                    StackList.empty (),
                    ValueSome [| InlineUIContainer.Children.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
