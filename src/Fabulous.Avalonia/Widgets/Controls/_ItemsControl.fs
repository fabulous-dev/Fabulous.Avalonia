namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =
    let Items =
        Attributes.defineListWidgetCollection "ItemsControl_Items" (fun target ->
            (target :?> ItemsControl).Items :?> IList<_>)

    let ItemCount =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.ItemCountProperty

[<Extension>]
type ItemsControlModifiers =
    [<Extension>]
    static member inline itemsCount(this: WidgetBuilder<'msg, #IFabItemsControl>, value) =
        this.AddScalar(ItemsControl.ItemCount.WithValue(value))
