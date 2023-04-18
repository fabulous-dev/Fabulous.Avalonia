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

    /// <summary>Sets the ValidSpinDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type ValidSpinDirections =
    /// | None = 0
    /// | Increase = 1
    /// | Decrease = 2
    /// </code>
    /// </example>
    [<Extension>]
    static member inline validSpinDirection(this: WidgetBuilder<'msg, #IFabSpinner>, value: ValidSpinDirections) =
        this.AddScalar(Spinner.ValidSpinDirection.WithValue(value))
