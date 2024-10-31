namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentAccessText =
    inherit IFabComponentTextBlock
    inherit IFabTextBlock

[<AutoOpen>]
module ComponentAccessTextBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a AccessText widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="showAccessKey">Whether to underline the access key in the text.</param>
        static member inline AccessText(text: string, showAccessKey: bool) =
            WidgetBuilder<unit, IFabComponentAccessText>(
                AccessText.WidgetKey,
                TextBlock.Text.WithValue(text),
                AccessText.ShowAccessKey.WithValue(showAccessKey)
            )
