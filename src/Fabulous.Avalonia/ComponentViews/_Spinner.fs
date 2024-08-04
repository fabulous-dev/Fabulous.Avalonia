namespace Fabulous.Avalonia.Components

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentSpinner =
    inherit IFabComponentContentControl
    inherit IFabSpinner

module ComponentSpinner =
    let Spin =
        ComponentAttributes.defineEvent<SpinEventArgs> "Spinner_Spin" (fun target -> (target :?> Spinner).Spin)
