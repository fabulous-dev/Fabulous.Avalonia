namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous

type IFabInline =
    inherit IFabTextElement

module Inline =
    let TextDecorations =
        Attributes.defineAvaloniaListWidgetCollection "Inline_TextDecorations" (fun target ->
            let target = target :?> Inline

            if target.TextDecorations = null then
                let newColl = TextDecorationCollection()
                target.TextDecorations <- newColl
                newColl
            else
                target.TextDecorations)

    let BaselineAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Inline.BaselineAlignmentProperty

[<Extension>]
type InlineModifiers =
    [<Extension>]
    static member inline baselineAlignment(this: WidgetBuilder<'msg, #IFabInline>, value: BaselineAlignment) =
        this.AddScalar(Inline.BaselineAlignment.WithValue(value))
