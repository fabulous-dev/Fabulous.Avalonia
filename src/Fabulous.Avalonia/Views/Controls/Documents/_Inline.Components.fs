namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous.Avalonia

module ComponentInline =
    let TextDecorations =
        Attributes.defineAvaloniaListWidgetCollectionNoLifecycle "Inline_TextDecorations" (fun target ->
            let target = target :?> Inline

            if target.TextDecorations = null then
                let newColl = TextDecorationCollection()
                target.TextDecorations <- newColl
                newColl
            else
                target.TextDecorations)
