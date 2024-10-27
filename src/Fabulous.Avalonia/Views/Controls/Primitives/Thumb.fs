namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabThumb =
    inherit IFabTemplatedControl

module Thumb =
    let WidgetKey = Widgets.register<Thumb>()


type ThumbModifiers =

    /// <summary>Link a ViewRef to access the direct Thumb control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabThumb>, value: ViewRef<Thumb>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
