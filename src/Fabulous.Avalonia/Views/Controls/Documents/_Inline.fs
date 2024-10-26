namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous

type IFabInline =
    inherit IFabTextElement

module Inline =
    let BaselineAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Inline.BaselineAlignmentProperty

type InlineModifiers =
    /// <summary>Sets the BaselineAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BaselineAlignment value.</param>
    [<Extension>]
    static member inline baselineAlignment(this: WidgetBuilder<'msg, #IFabInline>, value: BaselineAlignment) =
        this.AddScalar(Inline.BaselineAlignment.WithValue(value))
