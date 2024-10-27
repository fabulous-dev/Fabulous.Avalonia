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
            WidgetBuilder<'msg, IFabComponentLabel>(Label.WidgetKey, ContentControl.ContentString.WithValue(text))

        /// <summary>Creates a Label widget.</summary>
        /// <param name="content">The content to display.</param>
        static member inline Label(content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentLabel>(
                Label.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentLabelModifiers =
    /// <summary>Link a ViewRef to access the direct Label control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentLabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
