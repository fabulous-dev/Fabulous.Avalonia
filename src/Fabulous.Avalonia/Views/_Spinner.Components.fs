namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

module ComponentSpinner =
    let Spin =
        Attributes.defineEventNoDispatch<SpinEventArgs> "Spinner_Spin" (fun target -> (target :?> Spinner).Spin)
