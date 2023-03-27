namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous

type IFabThumb =
    inherit IFabTemplatedControl

module Thumb =
    let DragStarted =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragStarted" (fun target -> (target :?> Thumb).DragStarted)

    let DragDelta =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragDelta" (fun target -> (target :?> Thumb).DragDelta)

    let DragCompleted =
        Attributes.defineEvent<VectorEventArgs> "Thumb_DragCompleted" (fun target -> (target :?> Thumb).DragCompleted)
