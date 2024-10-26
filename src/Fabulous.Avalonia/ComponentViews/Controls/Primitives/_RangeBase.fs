namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia

type IFabComponentRangeBase =
    inherit IFabComponentTemplatedControl
    inherit IFabRangeBase

module ComponentRangeBase =
    let ValueChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty
