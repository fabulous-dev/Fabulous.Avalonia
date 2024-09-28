namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuViewBox =
    inherit IFabMvuControl
    inherit IFabViewBox

[<AutoOpen>]
module MvuViewBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ViewBox widget.</summary>
        /// <param name="content">The content of the ViewBox.</param>
        static member ViewBox(content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuViewBox>(
                ViewBox.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ViewBox.Child.WithValue(content.Compile()) |], ValueNone)
            )

type MvuViewBoxModifiers =
    /// <summary>Link a ViewRef to access the direct ViewBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuViewBox>, value: ViewRef<Viewbox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
