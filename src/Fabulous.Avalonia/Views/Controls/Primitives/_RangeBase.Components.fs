namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous.Avalonia

module ComponentRangeBase =
    let ValueChanged =
        Attributes.defineAvaloniaPropertyWithChangedEventNoDispatch' "RangeBase_ValueChanged" RangeBase.ValueProperty
