namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices

type IFabSpinner =
    inherit IFabContentControl

module Spinner =

    let ValidSpinDirection =
        Attributes.defineAvaloniaPropertyWithEquality Spinner.ValidSpinDirectionProperty

    let Spin =
        Attributes.defineEvent<SpinEventArgs> "Spinner_Spin" (fun target -> (target :?> Spinner).Spin)

[<Extension>]
type SpinnerModifiers =

    [<Extension>]
    static member inline validSpinDirection(this: WidgetBuilder<'msg, #IFabSpinner>, value: ValidSpinDirections) =
        this.AddScalar(Spinner.ValidSpinDirection.WithValue(value))

    [<Extension>]
    static member inline onSpin(this: WidgetBuilder<'msg, #IFabSpinner>, onSpin: SpinEventArgs -> 'msg) =
        this.AddScalar(Spinner.Spin.WithValue(fun args -> onSpin args |> box))
