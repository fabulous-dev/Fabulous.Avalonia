namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia

type IFabMvuRangeBase =
    inherit IFabMvuTemplatedControl
    inherit IFabRangeBase

module MvuRangeBase =
    let ValueChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
