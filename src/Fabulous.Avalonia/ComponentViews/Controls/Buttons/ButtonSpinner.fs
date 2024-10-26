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

type ComponentButtonSpinnerModifiers =
    /// <summary>Link a ViewRef to access the direct ButtonSpinner control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentButtonSpinner>, value: ViewRef<ButtonSpinner>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
