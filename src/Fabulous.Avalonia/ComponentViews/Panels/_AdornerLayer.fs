namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentAdornerLayer =
    inherit IFabComponentCanvas
    inherit IFabAdornerLayer

type ComponentAdornerLayerAttachedModifiers =
    /// <summary>Link a ViewRef to access the direct AdornerLayer control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentAdornerLayer>, value: ViewRef<AdornerLayer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
