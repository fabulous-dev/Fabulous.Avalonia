namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentMaskedTextBox =
    inherit IFabComponentTextBox
    inherit IFabMaskedTextBox

module ComponentMaskedTextBox =
    let TextChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "MaskedTextBox_TextChanged" MaskedTextBox.TextProperty

[<AutoOpen>]
module ComponentMaskedTextBoxBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a MaskedTextBox widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="mask">The mask to apply.</param>
        /// <param name="fn">Raised when the text changes.</param>
        static member inline MaskedTextBox(text: string, mask: string, fn: string -> unit) =
            WidgetBuilder<unit, IFabComponentMaskedTextBox>(
                MaskedTextBox.WidgetKey,
                MaskedTextBox.Mask.WithValue(mask),
                ComponentMaskedTextBox.TextChanged.WithValue(ComponentValueEventData.create text fn)
            )
