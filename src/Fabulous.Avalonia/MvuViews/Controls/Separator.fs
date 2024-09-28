namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuSeparator =
    inherit IFabMvuTemplatedControl
    inherit IFabSeparator

[<AutoOpen>]
module MvuSeparatorBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Separator widget.</summary>
        static member Separator() =
            WidgetBuilder<unit, IFabMvuSeparator>(Separator.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type MvuSeparatorModifiers =
    /// <summary>Link a ViewRef to access the direct Separator control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuSeparator>, value: ViewRef<Separator>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
