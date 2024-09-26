namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentUserControl =
    inherit IFabComponentContentControl
    inherit IFabUserControl

[<AutoOpen>]
module ComponentUserControlBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a UserControl widget.</summary>
        /// <param name="content">The content of the UserControl.</param>
        static member UserControl(content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentUserControl>(
                UserControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentUserControlModifiers =
    /// <summary>Link a ViewRef to access the direct UserControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentUserControl>, value: ViewRef<UserControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
