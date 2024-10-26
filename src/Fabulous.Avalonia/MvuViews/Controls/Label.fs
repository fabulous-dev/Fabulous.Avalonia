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
        static member inline Label(content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuLabel>(
                Label.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type MvuLabelModifiers =
    /// <summary>Link a ViewRef to access the direct Label control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuLabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
