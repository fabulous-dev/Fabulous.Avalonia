namespace Fabulous.Avalonia.Components

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices
open Fabulous.Avalonia

type IFabComponentButtonSpinner =
    inherit IFabComponentSpinner
    inherit IFabButtonSpinner

[<AutoOpen>]
module ButtonSpinnerBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ButtonSpinner widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the ButtonSpinner is clicked.</param>
        static member ButtonSpinner(text: string, fn: SpinEventArgs -> unit) =
            WidgetBuilder<unit, IFabComponentButtonSpinner>(
                ButtonSpinner.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentSpinner.Spin.WithValue(fn)
            )
