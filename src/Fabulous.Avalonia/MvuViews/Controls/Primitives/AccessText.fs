namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuAccessText =
    inherit IFabMvuTextBlock
    inherit IFabTextBlock

[<AutoOpen>]
module MvuAccessTextBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a AccessText widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="showAccessKey">Whether to underline the access key in the text.</param>
        static member inline AccessText(text: string, showAccessKey: bool) =
            WidgetBuilder<unit, IFabMvuAccessText>(AccessText.WidgetKey, TextBlock.Text.WithValue(text), AccessText.ShowAccessKey.WithValue(showAccessKey))
