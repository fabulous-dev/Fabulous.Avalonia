namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentLabel =
    inherit IFabComponentContentControl
    inherit IFabLabel

[<AutoOpen>]
module ComponentLabelBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Label widget.</summary>
        /// <param name="text">The text to display.</param>
        static member inline Label(text: string) =
            WidgetBuilder<unit, IFabComponentLabel>(Label.WidgetKey, ContentControl.ContentString.WithValue(text))

        /// <summary>Creates a Label widget.</summary>
        /// <param name="content">The content to display.</param>
        static member inline Label(content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentLabel>(
                Label.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
