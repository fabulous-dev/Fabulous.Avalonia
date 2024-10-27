namespace Fabulous.Avalonia.Components

open Avalonia.Controls.Primitives
open Fabulous.Avalonia

type IFabComponentRangeBase =
    inherit IFabComponentTemplatedControl
    inherit IFabRangeBase

module ComponentRangeBase =
    let ValueChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
