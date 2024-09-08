﻿namespace Fabulous.Avalonia.Components

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

        /// <summary>Creates a ButtonSpinner widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the ButtonSpinner is clicked.</param>
        static member ButtonSpinner(text: string, fn: SpinEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabButtonSpinner>(ButtonSpinner.WidgetKey, ContentControl.ContentString.WithValue(text), Spinner.Spin.WithValue(fn))

type ButtonSpinnerModifiers =

    /// <summary>Sets the AllowSpin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AllowSpin value.</param>
    [<Extension>]
    static member inline allowSpin(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: bool) =
        this.AddScalar(ButtonSpinner.AllowSpin.WithValue(value))

    /// <summary>Sets the ButtonSpinnerLocation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ButtonSpinnerLocation value.</param>
    [<Extension>]
    static member inline buttonSpinnerLocation(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: Location) =
        this.AddScalar(ButtonSpinner.ButtonSpinnerLocation.WithValue(value))

    /// <summary>Sets the ShowButtonSpinner property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowButtonSpinner value.</param>
    [<Extension>]
    static member inline showButtonSpinner(this: WidgetBuilder<'msg, #IFabButtonSpinner>, value: bool) =
        this.AddScalar(ButtonSpinner.ShowButtonSpinner.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ButtonSpinner control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabButtonSpinner>, value: ViewRef<ButtonSpinner>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
