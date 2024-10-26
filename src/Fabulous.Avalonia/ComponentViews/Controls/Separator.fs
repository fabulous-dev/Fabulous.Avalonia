namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentSeparator =
    inherit IFabComponentTemplatedControl
    inherit IFabSeparator

[<AutoOpen>]
module ComponentSeparatorBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Separator widget.</summary>
        static member Separator() =
            WidgetBuilder<unit, IFabComponentSeparator>(Separator.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type ComponentSeparatorModifiers =
    /// <summary>Link a ViewRef to access the direct Separator control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentSeparator>, value: ViewRef<Separator>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
