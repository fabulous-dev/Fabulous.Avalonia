namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuInline =
    inherit IFabMvuTextElement
    inherit IFabInline

module MvuInline =
    let TextDecorations =
        MvuAttributes.defineAvaloniaListWidgetCollection "Inline_TextDecorations" (fun target ->
            let target = target :?> Inline

            if target.TextDecorations = null then
                let newColl = TextDecorationCollection()
                target.TextDecorations <- newColl
                newColl
            else
                target.TextDecorations)
