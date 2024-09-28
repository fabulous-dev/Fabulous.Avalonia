namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuUserControl =
    inherit IFabMvuContentControl
    inherit IFabUserControl

[<AutoOpen>]
module MvuUserControlBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a UserControl widget.</summary>
        /// <param name="content">The content of the UserControl.</param>
        static member UserControl(content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuUserControl>(
                UserControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

type MvuUserControlModifiers =
    /// <summary>Link a ViewRef to access the direct UserControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuUserControl>, value: ViewRef<UserControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
