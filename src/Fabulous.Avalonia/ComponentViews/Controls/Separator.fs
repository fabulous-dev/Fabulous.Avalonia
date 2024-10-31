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
