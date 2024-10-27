namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls.Primitives
open Fabulous.Avalonia

type IFabMvuRangeBase =
    inherit IFabMvuTemplatedControl
    inherit IFabRangeBase

module MvuRangeBase =
    let ValueChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
