namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabMvuSpinner =
    inherit IFabMvuContentControl
    inherit IFabSpinner

module MvuSpinner =
    let Spin =
        Attributes.defineEvent<SpinEventArgs> "Spinner_Spin" (fun target -> (target :?> Spinner).Spin)
