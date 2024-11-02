namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous.Avalonia

module MvuRangeBase =
    let ValueChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
