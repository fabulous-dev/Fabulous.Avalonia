namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous.Avalonia

module ComponentRangeBase =
    let ValueChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
