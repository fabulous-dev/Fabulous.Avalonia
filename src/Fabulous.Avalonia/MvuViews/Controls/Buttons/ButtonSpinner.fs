namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices
open Fabulous.Avalonia

type IFabMvuButtonSpinner =
    inherit IFabMvuSpinner
    inherit IFabButtonSpinner

[<AutoOpen>]
module MvuButtonSpinnerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ButtonSpinner widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the ButtonSpinner is clicked.</param>
        static member ButtonSpinner(text: string, fn: SpinEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabMvuButtonSpinner>(ButtonSpinner.WidgetKey, ContentControl.ContentString.WithValue(text), MvuSpinner.Spin.WithValue(fn))
