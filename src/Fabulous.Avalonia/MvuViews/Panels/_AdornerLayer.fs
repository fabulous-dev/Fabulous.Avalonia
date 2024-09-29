namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuAdornerLayer =
    inherit IFabMvuCanvas
    inherit IFabAdornerLayer

type MvuAdornerLayerAttachedModifiers =
    /// <summary>Link a ViewRef to access the direct AdornerLayer control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuAdornerLayer>, value: ViewRef<AdornerLayer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
