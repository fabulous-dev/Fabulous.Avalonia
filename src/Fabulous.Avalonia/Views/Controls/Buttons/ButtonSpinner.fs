namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices

type IFabButtonSpinner =
    inherit IFabSpinner

module ButtonSpinner =
    let WidgetKey = Widgets.register<ButtonSpinner>()

    let AllowSpin =
        Attributes.defineAvaloniaPropertyWithEquality ButtonSpinner.AllowSpinProperty

    let ButtonSpinnerLocation =
        Attributes.defineAvaloniaPropertyWithEquality ButtonSpinner.ButtonSpinnerLocationProperty

    let ShowButtonSpinner =
        Attributes.defineAvaloniaPropertyWithEquality ButtonSpinner.ShowButtonSpinnerProperty

[<AutoOpen>]
module ButtonSpinnerBuilders =
    type Fabulous.Avalonia.View with

        static member inline ButtonSpinner<'msg>(text: string, onSpin: SpinEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabButtonSpinner>(
                ButtonSpinner.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Spinner.Spin.WithValue(fun args -> onSpin args |> box)
            )

[<Extension>]
type ButtonSpinnerModifiers =

    [<Extension>]
    static member inline allowSpin(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: bool) =
        this.AddScalar(ButtonSpinner.AllowSpin.WithValue(value))

    [<Extension>]
    static member inline buttonSpinnerLocation(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: Location) =
        this.AddScalar(ButtonSpinner.ButtonSpinnerLocation.WithValue(value))

    [<Extension>]
    static member inline showButtonSpinner(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: bool) =
        this.AddScalar(ButtonSpinner.ShowButtonSpinner.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ButtonSpinner control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabButtonSpinner>, value: ViewRef<ButtonSpinner>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
