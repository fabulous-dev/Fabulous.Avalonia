namespace Fabulous.Avalonia.Mvu

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
            WidgetBuilder<'msg, IFabMvuSeparator>(Separator.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
