namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabBlurEffect =
    inherit IFabEffect

module BlurEffect =
    let WidgetKey = Widgets.register<BlurEffect>()

    let Radius = Attributes.defineAvaloniaPropertyWithEquality BlurEffect.RadiusProperty

type BlurEffectModifiers =

    /// <summary>Link a ViewRef to access the direct BlurEffect control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBlurEffect>, value: ViewRef<BlurEffect>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
