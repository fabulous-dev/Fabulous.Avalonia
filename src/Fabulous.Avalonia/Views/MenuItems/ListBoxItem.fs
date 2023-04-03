namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabListBoxItem =
    inherit IFabContentControl

module ListBoxItem =
    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality ListBoxItem.IsSelectedProperty
