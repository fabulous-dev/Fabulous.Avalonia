namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuLabel =
    inherit IFabMvuContentControl
    inherit IFabLabel

[<AutoOpen>]
module MvuLabelBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Label widget.</summary>
        /// <param name="text">The text to display.</param>
        static member inline Label(text: string) =
            WidgetBuilder<'msg, IFabMvuLabel>(Label.WidgetKey, ContentControl.ContentString.WithValue(text))

        /// <summary>Creates a Label widget.</summary>
        /// <param name="content">The content to display.</param>
        static member inline Label(content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuLabel>(
                Label.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
