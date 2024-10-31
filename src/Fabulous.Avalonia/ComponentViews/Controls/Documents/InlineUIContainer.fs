namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentInlineUIContainer =
    inherit IFabComponentInline
    inherit IFabInlineUIContainer

[<AutoOpen>]
module ComponentInlineUIContainerBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a InlineUIContainer widget.</summary>
        /// <param name="content">The content of the InlineUIContainer.</param>
        static member InlineUIContainer(content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentInlineUIContainer>(
                InlineUIContainer.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| InlineUIContainer.Children.WithValue(content.Compile()) |], ValueNone)
            )
