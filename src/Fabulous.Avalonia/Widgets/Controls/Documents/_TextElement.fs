namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTextElement =
    inherit IFabStyledElement

module TextElement =
    let Background =
        Attributes.defineAvaloniaPropertyWidget TextElement.BackgroundProperty

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontStretchProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWidget TextElement.ForegroundProperty
